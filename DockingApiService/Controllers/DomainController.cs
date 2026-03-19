using DockingApiService.DataModels;
using DockingDataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace DockingApiService.Controllers;

[Route("domain")]
[ApiController]
public class DomainController : Controller
{
    private readonly ComputationContext _ctx;
    private readonly IWebHostEnvironment _env;

    public DomainController(ComputationContext ctx, IWebHostEnvironment env)
    {
        _ctx = ctx;
        _env = env;
    }

    /// <summary>
    /// Gets short information of a domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/domain/dakb-gpcrs
    ///     
    /// </remarks>
    /// <returns>A plain domain object.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("{domainId:required}")]
    public async Task<ActionResult<Domain>> GetOne(string domainId)
    {
        Domain domain = await _ctx.Domains
            .Where(o => o.Id == domainId)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return domain;
    }

    /// <summary>
    /// Gets properties of a domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/domain/dakb-gpcrs/props
    ///     
    /// </remarks>
    /// <returns>An object containing the properties of the domain.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("{domainId:required}/props")]
    public async Task<ActionResult<CompProperties>> Properties(string domainId)
    {
        var data = await _ctx.GetDomainProteins(domainId)
            .Select(o => new { a = o.HasActiveChemblCompounds, c = o.HasChemblCompounds, t = o.HasTrainedModels })
            .AsNoTracking()
            .ToArrayAsync();

        CompProperties props = new();
        foreach (var i in data)
        {
            props.HasActiveChemblCompounds |= i.a;
            props.HasChemblCompounds |= i.c;
            props.HasTrainedModels |= i.t;
        }

        return props;
    }

    /// <summary>
    /// Gets information of a domain that includes information of proteins and jobs for each domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/domain/dakb-gpcrs/detailed
    ///     
    /// </remarks>
    /// <returns>A domain object with proteins and jobs.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("{domainId:required}/detailed")]
    public async Task<ActionResult<Domain>> GetOneDetailed(string domainId)
    {
        Domain domain = await _ctx.Domains
            .Where(o => o.Id == domainId)
            .Include(o => o.DomainProteins)
            .ThenInclude(o => o.Protein)
            .ThenInclude(o => o.Properties)
            .Include(o => o.DomainJobs)
            .ThenInclude(o => o.Job)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return domain;
    }

    /// <summary>
    /// Gets a summary list of domains that contains only fields of domainId, name, fullName and proteinCount.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/domain/list
    ///     
    /// </remarks>
    /// <returns>A list of domains.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list")]
    public async Task<ActionResult<IEnumerable<Domain>>> List()
    {
        Domain[] domains = await _ctx.Domains
            .AsNoTracking()
            .ToArrayAsync();

        return domains;
    }

    /// <summary>
    /// Gets a full list of domains that includes information of proteins and jobs for each domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/domain/list/detailed
    ///     
    /// </remarks>
    /// <returns>A list of domains with proteins and jobs.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("list/detailed")]
    public async Task<ActionResult<IEnumerable<Domain>>> ListDetailed()
    {
        Domain[] jobs = await _ctx.Domains
            .Include(o => o.DomainProteins)
            .ThenInclude(o => o.Protein)
            .ThenInclude(o => o.Properties)
            .Include(o => o.DomainJobs)
            .ThenInclude(o => o.Job)
            .AsNoTracking()
            .ToArrayAsync();

        return jobs;
    }

    private async Task<bool> ValidateProteins(IQueryable<Protein> proteins)
    {
        // No structure in some proteins
        if (await proteins
            .AnyAsync(o => o.StructureCount == 0))
            return false;

        // No structure in some cavities in some proteins
        if (await proteins
            .SelectMany(o => o.Cavities)
            .AnyAsync(o => o.StructureCount == 0))
            return false;

        // Check for computation and visualization resources
        string receptorsDir = Path.Combine(_env.ContentRootPath, "Workspace", "Receptors");

        return proteins
            .SelectMany(o => o.Cavities)
            .Include(o => o.Protein)
            .AsNoTracking()
            .AsEnumerable()
            .All(o =>
            {
                string proteinDir = Path.Combine(receptorsDir, o.Protein.Id);

                // Check only when ActiveChemblCompounds is on
                if (o.Protein.HasActiveChemblCompounds)
                {
                    ChemblCompoundsIntegrity cci = new();
                    cci.Validate(proteinDir, o.Protein.Id);
                    if (!cci.IsReadyForComputation())
                        return false;
                }

                // Check only when HasTrainedModels is on
                if (o.Protein.HasTrainedModels)
                {
                    TrainedModelsIntegrity tmi = new();
                    tmi.Validate(proteinDir, o.Protein.Id);
                    if (!tmi.IsReadyForComputation())
                        return false;
                }

                string cavityDir = Path.Combine(proteinDir, o.BindingSite);

                // Check each model structure
                for (int i = 0; i < o.StructureCount; i++)
                {
                    string structureName = $"model_{i + 1}";
                    StructureIntegrity si = new();
                    si.Validate(Path.Combine(cavityDir, structureName), structureName);
                    if (!si.IsReadyForComputation() || !si.IsReadyForVisualization())
                        return false;
                }

                return true;
            });
    }

    /// <summary>
    /// Gets the detailed integrity information of the proteins in the specific domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/domain/dakb/integrity
    ///     
    /// </remarks>
    /// <returns>A list of integrity objects of the proteins.</returns>
    /// <response code="200">Sucessful operation.</response>
    [ProducesResponseType(200)]
    [HttpGet("{domainId:required}/integrity")]
    public async Task<ActionResult<IEnumerable<TargetIntegrity>>> Integrity(string domainId)
    {
        if (!await _ctx.Domains.AnyAsync(o => o.Id == domainId))
            return NotFound();

        string receptorsDir = Path.Combine(_env.ContentRootPath, "Workspace", "Receptors");

        IAsyncEnumerable<Protein> proteins = _ctx.Domains
            .Where(o => o.Id == domainId)
            .SelectMany(o => o.DomainProteins)
            .Include(o => o.Protein.Cavities)
            .Select(o => o.Protein)
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
    /// Sets the description and the citations of a specific domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT api/domain/dakb
    ///     {
    ///         "Name": "Drug Abuse Knowledgebase",
    ///         "Keywords": ["DA", "CKB"],
    ///         "Description": "This is Drug Abuse Knowledgebase",
    ///         "Citations": "Maozi Chen. Title. Journal. 2019."
    ///     }
    ///     
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to update for</param>
    /// <param name="model">Parameters as defined in <seealso cref="UpdateDomainModel"/>. See sample request for more.</param>
    /// <response code="404">Domain not found.</response>
    /// <response code="204">Sucessful operation.</response>
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    [HttpPut("{domainId:required}")]
    public async Task<ActionResult> Update(string domainId, UpdateDomainModel model)
    {
        Domain domain = await _ctx.Domains.FirstOrDefaultAsync(o => o.Id == domainId);
        if (domain == null)
            return NotFound();

        domain.Name = model.Name;
        domain.Keywords = model.Keywords;
        domain.Description = model.Description;
        domain.Citation = model.Citations;

        await _ctx.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Creates a new domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST api/domain
    ///     
    /// </remarks>
    /// <param name="model">Parameters as defined in <seealso cref="CreateDomainModel"/>. See sample request for more.</param>
    /// <response code="409">Domain identifier already exists.</response>
    /// <response code="201">Sucessful created.</response>
    [ProducesResponseType(409)]
    [ProducesResponseType(201)]
    [HttpPost]
    public async Task<ActionResult<Domain>> Create(CreateDomainModel model)
    {
        Domain domain = await _ctx.Domains.FirstOrDefaultAsync(o => o.Id == model.Id);
        if (domain != null)
            return Conflict();

        domain = new Domain();
        domain.Init(model.Id, model.Name, false);

        await _ctx.Domains.AddAsync(domain);
        await _ctx.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOne), new { domainId = model.Id }, domain);
    }

    /// <summary>
    /// Publishes a specific domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT api/domain/dakb/public
    ///     
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to publish</param>
    /// <response code="409">Domain can not be published.</response>
    /// <response code="404">Domain not found.</response>
    /// <response code="204">Sucessful operation.</response>
    [ProducesResponseType(409)]
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    [HttpPut("{domainId:required}/public")]
    public async Task<ActionResult> Publish(string domainId)
    {
        Domain domain = await _ctx.Domains.FirstOrDefaultAsync(o => o.Id == domainId);
        if (domain == null)
            return NotFound();

        // Already public
        if (domain.IsPublic)
            return NoContent();

        // No protein in the domain
        if (domain.ProteinCount == 0)
            return Conflict();

        // Enforce validation rules to every protein workload in the domain
        if (!await ValidateProteins(_ctx.Domains
            .Where(o => o.Id == domainId)
            .SelectMany(o => o.DomainProteins)
            .Select(o => o.Protein)))
            return Conflict();

        domain.IsPublic = true;
        await _ctx.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a specific domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE api/domain/dakb
    ///     
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to delete</param>
    /// <response code="409">Domain should not be deleted.</response>
    /// <response code="404">Domain not found.</response>
    /// <response code="204">Sucessful operation.</response>
    [ProducesResponseType(409)]
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    [HttpDelete("{domainId:required}")]
    public async Task<ActionResult> Delete(string domainId)
    {
        Domain domain = await _ctx.Domains.FirstOrDefaultAsync(o => o.Id == domainId);
        if (domain == null)
            return NotFound();

        if (domain.ProteinCount > 0 || domain.IsPublic)
            return Conflict();

        _ctx.Domains.Remove(domain);
        await _ctx.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Adds some proteins to a specific domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT api/domain/dakb/proteins
    ///     
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to add proteins with</param>
    /// <param name="proteinIds">The identifiers of proteins to be added to the domain</param>
    /// <response code="409">Some proteins have issues.</response>
    /// <response code="404">Domain or some proteins not found.</response>
    /// <response code="400">Invalid arguments.</response>
    /// <response code="204">Sucessful operation.</response>
    [ProducesResponseType(409)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [HttpPut("{domainId:required}/proteins")]
    public async Task<ActionResult> AddProteins(string domainId, string[] proteinIds)
    {
        if (string.IsNullOrWhiteSpace(domainId)
            || domainId.Trim().Length != domainId.Length
            || proteinIds == null
            || proteinIds.Length == 0
            || proteinIds.Any(o => string.IsNullOrWhiteSpace(o) || o.Trim().Length != o.Length)
            || proteinIds.Length != proteinIds.Select(o => o.ToUpper()).Distinct().Count())
            return BadRequest();

        Domain domain = await _ctx.Domains.Include(o => o.DomainProteins).FirstOrDefaultAsync(o => o.Id == domainId);
        if (domain == null)
            return NotFound();

        // Validate protein IDs
        if (domain.IsPublic)
        {
            // Be strict on public: fail if some IDs don't exist
            if (await _ctx.Proteins.CountAsync(o => proteinIds.Contains(o.Id)) != proteinIds.Length)
                return NotFound();
        }
        else
        {
            // Keep only valid IDs
            proteinIds = await _ctx.Proteins.Where(o => proteinIds.Contains(o.Id)).Select(o => o.Id).ToArrayAsync();
        }

        // Excludes existing protein IDs
        string[] existingIds = await _ctx.Domains
            .Where(o => o.Id == domainId)
            .SelectMany(o => o.DomainProteins)
            .Select(o => o.Protein)
            .Where(o => proteinIds.Contains(o.Id))
            .Select(o => o.Id)
            .ToArrayAsync();

        proteinIds = proteinIds.Except(existingIds).ToArray();

        // No more IDs remaining
        if (proteinIds.Length == 0)
            return NoContent();

        // Public domain requires the adding proteins to be valid (same rules in publishing)
        if (domain.IsPublic && !await ValidateProteins(_ctx.Proteins.Where(o => proteinIds.Contains(o.Id))))
            return Conflict();

        // Add the proteins
        foreach (string proteinId in proteinIds)
        {
            domain.DomainProteins.Add(new DomainProtein { DomainId = domainId, ProteinId = proteinId });
        }
        domain.ProteinCount += proteinIds.Length;

        _ctx.Proteins.Where(o => proteinIds.Contains(o.Id)).Update(o => new { DomainCount = o.DomainCount + 1 });
        await _ctx.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a protein from a specific domain.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE api/domain/dakb/5HT1A_HUMAN
    ///     
    /// </remarks>
    /// <param name="domainId">The identifier of the domain to delete the protein from</param>
    /// <param name="proteinId">The identifier of protein to be deleted from the domain</param>
    /// <response code="404">Domain or protein not found.</response>
    /// <response code="204">Sucessful operation.</response>
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    [HttpDelete("{domainId:required}/{proteinId:required}")]
    public async Task<ActionResult> DeleteProtein(string domainId, string proteinId)
    {
        DomainProtein domainProtein = await _ctx.Domains
            .SelectMany(o => o.DomainProteins)
            .Where(o => o.DomainId == domainId && o.ProteinId == proteinId)
            .Include(o => o.Domain)
            .Include(o => o.Protein)
            .FirstOrDefaultAsync();

        if (domainProtein == null)
            return NotFound();

        domainProtein.Domain.ProteinCount--;
        domainProtein.Protein.DomainCount--;

        _ctx.Remove(domainProtein);
        await _ctx.SaveChangesAsync();

        return NoContent();
    }
}