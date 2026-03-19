using DockingApiService.DataModels;
using DockingDataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DockingApiService.Controllers;

[Route("protein")]
[ApiController]
[ResponseCache(Duration = 600)]
public class ProteinController : ControllerBase
{
    private readonly ComputationContext _ctx;
    private readonly IWebHostEnvironment _env;

    public ProteinController(ComputationContext ctx, IWebHostEnvironment env)
    {
        _ctx = ctx;
        _env = env;
    }

    /// <summary>
    /// Gets the information of the protein for a given <paramref name="id"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/protein/5HT1A_HUMAN
    /// 
    /// </remarks>
    /// <param name="id">The protein identifier. e.g. "5HT1A_HUMAN", "CNR2_HUMAN" or "SMO_HUMAN".</param>
    /// <returns>A instance represents the protein.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the protein does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("{id:required}")]
    public async Task<ActionResult<Protein>> GetOne(string id)
    {
        Protein protein = await _ctx.GetProteins()
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);
        if (protein == null)
            return NotFound();
        return protein;
    }

    /// <summary>
    /// Gets the full list of the proteins.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/protein
    /// 
    /// </remarks>
    /// <returns>The list of proteins.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Protein>>> List()
    {
        Protein[] proteins = await _ctx.Proteins
            .Include(o => o.ProteinDomains)
            .ThenInclude(o => o.Domain)
            .AsNoTracking()
            .ToArrayAsync();
        return proteins;
    }

    /// <summary>
    /// Gets the full list of the proteins in details.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/protein/list/detailed
    /// 
    /// </remarks>
    /// <returns>The list of proteins in details.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list/detailed")]
    public async Task<ActionResult<IEnumerable<Protein>>> ListDetailed()
    {
        Protein[] proteins = await _ctx.Proteins
            .Include(o => o.ProteinDomains)
            .ThenInclude(o => o.Domain)
            .Include(o => o.Properties)
            .Include(o => o.Cavities)
            .ThenInclude(o => o.Structures)
            .Include(o => o.Tags)
            .AsNoTracking()
            .ToArrayAsync();
        return proteins;
    }

    /// <summary>
    /// Gets the detailed integrity information of all proteins.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/protein/integrity
    ///     
    /// </remarks>
    /// <returns>A list of integrity objects of the proteins.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("integrity")]
    public async Task<ActionResult<IEnumerable<TargetIntegrity>>> Integrity()
    {
        string receptorsDir = Path.Combine(_env.ContentRootPath, "Workspace", "Receptors");

        // TODO: eliminate code duplication here and in DomainController.cs
        IAsyncEnumerable<Protein> proteins = _ctx.Proteins
            .Include(o => o.Cavities)
            .AsNoTracking()
            .AsAsyncEnumerable();

        List<TargetIntegrity> targetInts = new();

        await foreach (Protein protein in proteins)
        {
            string proteinDir = Path.Combine(receptorsDir, protein.Id);
            TargetIntegrity tarInt = new()
            {
                Cavities = new CavityIntegrity[protein.Cavities.Count],
                Protein = protein,
            };

            for (int k = 0; k < protein.Cavities.Count; k++)
            {
                Cavity cavity = protein.Cavities[k];
                string cavityDir = Path.Combine(proteinDir, cavity.BindingSite);

                tarInt.Cavities[k] = new CavityIntegrity
                {
                    CavityId = cavity.Id,
                    BindingSite = cavity.BindingSite,
                    Structures = new StructureIntegrity[cavity.StructureCount],
                };

                for (int i = 0; i < cavity.StructureCount; i++)
                {
                    string structureName = $"model_{i + 1}";
                    tarInt.Cavities[k].Structures[i] = new StructureIntegrity();
                    tarInt.Cavities[k].Structures[i].Validate(Path.Combine(cavityDir, structureName), structureName);
                }
            }

            if (protein.HasActiveChemblCompounds)
            {
                tarInt.ChemblCompounds = new ChemblCompoundsIntegrity();
                tarInt.ChemblCompounds.Validate(proteinDir, protein.Id);
            }

            if (protein.HasTrainedModels)
            {
                tarInt.TrainedModels = new TrainedModelsIntegrity();
                tarInt.TrainedModels.Validate(proteinDir, protein.Id);
            }

            targetInts.Add(tarInt);
        }

        return targetInts;
    }

    /// <summary>
    /// Gets the full list of the proteins included in the domain specified by <paramref name="domainId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/protein/by-domain/dakb-gpcrs
    /// 
    /// </remarks>
    /// <param name="domainId">The identifier of the query domain.</param>
    /// <param name="tagId">The tag to filter the proteins in the domain.</param>
    /// <returns>The list of proteins in the given domain.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("by-domain/{domainId:required}/{tagId?}")]
    public async Task<ActionResult<IEnumerable<Protein>>> ListByDomain(string domainId, string tagId)
    {
        if (string.IsNullOrEmpty(tagId))
        {
            Protein[] proteins = await _ctx.Proteins
                .Where(o => o.ProteinDomains.Any(p => p.DomainId == domainId))
                .Include(o => o.Properties)
                .Include(o => o.Cavities)
                .Include(o => o.Tags)
                .AsNoTracking()
                .ToArrayAsync();
            return proteins;
        }
        else
        {
            Protein[] proteins = await _ctx.Proteins
                .Where(o => o.ProteinDomains.Any(p => p.DomainId == domainId))
                .Where(o => o.Tags.Any(p => p.Id == tagId))
                .Include(o => o.Properties)
                .Include(o => o.Cavities)
                .Include(o => o.Tags)
                .AsNoTracking()
                .ToArrayAsync();
            return proteins;
        }
    }

    /// <summary>
    /// Gets the name of a protein tag.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/protein/tag/HIV
    /// 
    /// </remarks>
    /// <param name="tagId">The tag identifier to look for name with.</param>
    /// <returns>The name of a protein tag.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("tag/{tagId}")]
    public async Task<ActionResult<string>> GetTagName(string tagId)
    {
        ProteinTag tag = await _ctx.ProteinTags
            .FirstOrDefaultAsync(o => o.Id == tagId);
        return tag?.Name;
    }

    /// <summary>
    /// Gets all tags used for any protein in the given domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/protein/tags/dakb-gpcrs
    /// 
    /// </remarks>
    /// <param name="domainId">The identifier of the query domain.</param>
    /// <returns>The tags used in the given domain.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("tags/{domainId}")]
    public async Task<ActionResult<IEnumerable<ProteinTag>>> GetTags(string domainId)
    {
        ProteinTag[] tags = await _ctx.Proteins
            .Where(o => o.ProteinDomains.Any(p => p.DomainId == domainId))
            .SelectMany(o => o.Tags)
            .Distinct()
            .AsNoTracking()
            .ToArrayAsync();
        return tags;
    }
}
