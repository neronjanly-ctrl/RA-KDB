using ChemicalFunctions;
using CommonTools;
using DockingApiService.DataModels;
using DockingDataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DockingApiService.Controllers;

[Route("result")]
[ApiController]
public class ResultController : ControllerBase
{
    private readonly ComputationContext _ctx;
    private readonly IWebHostEnvironment _env;

    public ResultController(ComputationContext ctx, IWebHostEnvironment env)
    {
        _ctx = ctx;
        _env = env;
    }

    /// <summary>
    /// Gets the result for the identifier combination of <paramref name="jobId"/>, <paramref name="cavityId"/> and <paramref name="ligandId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/5/40989e2baefd4374/3fe9e69acf8571e1
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to fetch the results of with.</param>
    /// <param name="cavityId">The hexadecimal identifier of the protein cavity.</param>
    /// <param name="ligandId">The hexadecimal identifier of the ligand.</param>
    /// <returns>A <see cref="Result"/> object for the query arguments.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("{jobId:int}/{cavityId:length(16)}/{ligandId:length(16)}")]
    public async Task<ActionResult<Result>> GetOne(int jobId, string cavityId, string ligandId)
    {
        long lcavityId = cavityId.ParseId(), lligandId = ligandId.ParseId();

        Result result = await _ctx.Results
            .Include(o => o.Cavity)
            .ThenInclude(o => o.Protein)
            .ThenInclude(o => o.Properties)
            .Include(o => o.Ligand)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.JobId == jobId && o.CavityId == lcavityId && o.LigandId == lligandId);

        if (result == null)
            return NotFound();

        return result;
    }

    /// <summary>
    /// Gets a partial list of results for the job specified by <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/for-job-5/0/20
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to fetch the results of with.</param>
    /// <param name="offset">The zero-based starting position in all results of the specific job.</param>
    /// <param name="count">The number of results to retrieve.</param>
    /// <returns>A list of <see cref="Result"/> objects that represents the results of the specific job.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("for-job-{jobId:int}/{offset:int}/{count:int}")]
    public async Task<ActionResult<IEnumerable<Result>>> List(int jobId, int offset, int count)
    {
        if (!await _ctx.Jobs.AnyAsync(o => o.Id == jobId))
            return NotFound();

        // filter, project and materialize
        Result[] results = await _ctx.GetJobResults(jobId)
            .OrderBy(o => o.Cavity.ProteinId)
            .Skip(offset)
            .Take(count)
            .Include(o => o.Cavity)
            .ThenInclude(o => o.Protein)
            .AsNoTracking()
            .ToArrayAsync();

        return results;
    }

    /// <summary>
    /// Gets a full list of results for the job specified by <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/for-job-5
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to fetch the results of with.</param>
    /// <returns>A list of <see cref="Result"/> objects that represents the results of the specific job.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("for-job-{jobId:int}")]
    public async Task<ActionResult<IEnumerable<Result>>> List(int jobId)
    {
        if (!await _ctx.Jobs.AnyAsync(o => o.Id == jobId))
            return NotFound();

        // filter, project and materialize
        Result[] results = await _ctx.GetJobResults(jobId)
            .OrderBy(o => o.Cavity.ProteinId)
            .Include(o => o.Cavity)
            .ThenInclude(o => o.Protein)
            .ThenInclude(o => o.Properties)
            .Include(o => o.Ligand)
            .AsNoTracking()
            .ToArrayAsync();

        return results;
    }

    /// <summary>
    /// Gets a filtered list of results for a specified <paramref name="cavityId"/> for the job specified by <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/for-job-5/for-cavity-40989e2baefd4374
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to fetch the results of with.</param>
    /// <param name="cavityId">The hex encoded identifier of the protein cavity to fetch the results of with.</param>
    /// <returns>A list of <see cref="Result"/> objects that represents the results of the specific job and the specific <paramref name="cavityId"/>.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("for-job-{jobId:int}/for-cavity-{cavityId:length(16)}")]
    public async Task<ActionResult<IEnumerable<Result>>> ListForCavity(int jobId, string cavityId)
    {
        long cid = cavityId.ParseId();
        if (!await _ctx.Jobs.AnyAsync(o => o.Id == jobId))
            return NotFound();

        // filter, project and materialize
        Result[] results = await _ctx.GetJobResultsForCavity(jobId, cid)
            .OrderBy(o => o.Cavity.ProteinId)
            .Include(o => o.Cavity)
            .ThenInclude(o => o.Protein)
            .Include(o => o.Ligand)
            .AsNoTracking()
            .ToArrayAsync();

        return results;
    }

    /// <summary>
    /// Gets a filtered list of results for a specified <paramref name="ligandId"/> for the job specified by <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/for-job-5/for-ligand-4b24a5712e7b3623
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier to fetch the results of with.</param>
    /// <param name="ligandId">The lowercased 16-bit hexadecimal identifier of the ligand.</param>
    /// <returns>A list of <see cref="Result"/> objects that represents the results of the specific job and the specific <paramref name="ligandId"/>.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("for-job-{jobId:int}/for-ligand-{ligandId:length(16)}")]
    public async Task<ActionResult<IEnumerable<Result>>> ListForLigand(int jobId, string ligandId)
    {
        if (!await _ctx.Jobs.AnyAsync(o => o.Id == jobId))
            return NotFound();

        // filter, project and materialize
        Result[] results = await _ctx.GetJobResultsForLigand(jobId, ligandId.ParseId())
            .OrderBy(o => o.Cavity.ProteinId)
            .Include(o => o.Cavity)
            .ThenInclude(o => o.Protein)
            .AsNoTracking()
            .ToArrayAsync();

        return results;
    }

    /// <summary>
    /// Gets the resulting 3D ligand model in PDBQT for docking the ligand specified by <paramref name="ligandId"/> and the <paramref name="proteinId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/4b24a5712e7b3623/5HT1A_HUMAN/3fe9e69acf8571e1
    /// 
    /// </remarks>
    /// <param name="ligandId">The lowercased 16-bit hexadecimal identifier of the ligand.</param>
    /// <param name="proteinId">The identifier of the protein to fetch the model with.</param>
    /// <param name="dockingId">The lowercased 16-bit hexadecimal identifier of the docking to fetch the model with.</param>
    /// <returns>A <see cref="FileObject"/> that represents the resulting 3D ligand model.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the file does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("{ligandId:length(16)}/{proteinId:required}/{dockingId:length(16)}")]
    public async Task<ActionResult<FileObject>> GetConformation(string ligandId, string proteinId, string dockingId)
    {
        string dir = Path.Combine("Workspace", "Output", ligandId, proteinId, dockingId);
        string fpLigand = Path.Combine(dir, "ligand.pdbqt");
        string fpLigandFixed = Path.Combine(dir, "fixed_ligand.pdbqt");

        if (System.IO.File.Exists(fpLigandFixed))
            fpLigand = fpLigandFixed;
        else if (!System.IO.File.Exists(fpLigand))
            return NotFound();

        return new FileObject
        {
            Content = await System.IO.File.ReadAllTextAsync(fpLigand),
            MimeType = ChemicalFormat.PDBQT.GetMimeType().MimeType,
            FileName = $"{proteinId}-conf_{dockingId}-ligand_{ligandId}.pdbqt",
        };
    }

    /// <summary>
    /// Gets the resulting 3D receptor-ligand complex model in PDBQT for docking the ligand specified by <paramref name="ligandId"/> and the <paramref name="proteinId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/complex/4b24a5712e7b3623/5HT1A_HUMAN/3fe9e69acf8571e1
    /// 
    /// </remarks>
    /// <param name="ligandId">The lowercased 16-bit hexadecimal identifier of the ligand.</param>
    /// <param name="proteinId">The identifier of the protein to fetch the model with.</param>
    /// <param name="dockingId">The lowercased 16-bit hexadecimal identifier of the docking to fetch the model with.</param>
    /// <returns>A <see cref="FileObject"/> that represents the resulting 3D ligand model.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the file does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("complex/{ligandId:length(16)}/{proteinId:required}/{dockingId:length(16)}")]
    public async Task<ActionResult<FileObject>> GetComplexedConformation(string ligandId, string proteinId, string dockingId)
    {
        string dir = Path.Combine("Workspace", "Output", ligandId, proteinId, dockingId);
        string fpLigand = Path.Combine(dir, "ligand.pdbqt");
        string fpLigandFixed = Path.Combine(dir, "fixed_ligand.pdbqt");

        if (System.IO.File.Exists(fpLigandFixed))
            fpLigand = fpLigandFixed;
        else if (!System.IO.File.Exists(fpLigand))
            return NotFound();

        Docking docking = await _ctx.Dockings.FirstOrDefaultAsync(o => o.Id == dockingId.ParseId());
        if (docking == null)
            return NotFound();

        string dir2 = Path.Combine("Workspace", "Receptors", proteinId, docking.BindingCavity, $"model_{docking.StructureIndex + 1}");
        string fpProtein = Path.Combine(dir2, "AminoAcids.pdbqt");
        string fpProteinFixed = Path.Combine(dir2, "AminoAcids_fixed.pdbqt");

        if (System.IO.File.Exists(fpProteinFixed))
            fpProtein = fpProteinFixed;
        else if (!System.IO.File.Exists(fpProtein))
            return NotFound();

        return new FileObject
        {
            Content = System.IO.File.ReadAllText(fpLigand) + System.IO.File.ReadAllText(fpProtein),
            MimeType = ChemicalFormat.PDBQT.GetMimeType().MimeType,
            FileName = $"{proteinId}-conf_{dockingId}-complex_{ligandId}.pdbqt",
        };
    }

    /// <summary>
    /// Gets the resulting 3D ligand model in PDBQT for docking the ligand specified by <paramref name="ligandId"/> and the <paramref name="proteinId"/>.
    /// This API is kept for existing conformation output only. All new conformations should use <seealso cref="GetConformation(string, string, string)"/> to fetch instead.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/result/4b24a5712e7b3623/5HT1A_HUMAN/1
    /// 
    /// </remarks>
    /// <param name="ligandId">The lowercased 16-bit hexadecimal identifier of the ligand.</param>
    /// <param name="proteinId">The identifier of the protein to fetch the model with.</param>
    /// <param name="modelId">The index of the docking model.</param>
    /// <returns>A <see cref="FileObject"/> that represents the resulting 3D ligand model.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the file does not exist.</response>
    [Obsolete]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("{ligandId:length(16)}/{proteinId:required}/{modelId:int}")]
    public async Task<ActionResult<FileObject>> GetConformationLegacy(string ligandId, string proteinId, int modelId)
    {
        string filepath = Path.Combine("Workspace", "Output", ligandId, proteinId, $"model_{modelId}-ligand.pdbqt");

        if (!System.IO.File.Exists(filepath))
            return NotFound();

        return new FileObject
        {
            Content = await System.IO.File.ReadAllTextAsync(filepath),
            MimeType = ChemicalFormat.PDBQT.GetMimeType().MimeType,
            FileName = $"{proteinId}-model_{modelId}-ligand_{ligandId}.pdbqt",
        };
    }

    /// <summary>
    /// Permanently deletes the results of the job specified by <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// The job must be in the Finished or Failed status.
    /// 
    /// Sample request:
    /// 
    ///     DELETE api/result/for-job-5
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier of the job to delete results for.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    /// <response code="400">If the job is not in the Finished or Failed status.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpDelete("for-job-{jobId:int}")]
    public async Task<ActionResult> Delete(int jobId)
    {
        Job job = await _ctx.Jobs.FirstOrDefaultAsync(o => o.Id == jobId);
        if (job == null)
            return NotFound();

        if (job.Status != RunningStatus.Finished && job.Status != RunningStatus.Failed)
            return ValidationProblem();

        string[] domainIds = await _ctx.GetJobDomains(jobId).Select(o => o.Id).ToArrayAsync();
        int[] stages = await _ctx.CalcStagesForDomains(domainIds);

        job.ResetProgress(stages);

        _ctx.Results.RemoveRange(_ctx.GetJobResults(jobId));
        await _ctx.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Permanently deletes the job cache of the job specified by <paramref name="jobId"/>.
    /// </summary>
    /// <remarks>
    /// The job must be in the Finished or Failed status. The job cache includes docking results, docked ligand models and some other information generated during docking and prediction.
    /// 
    /// Sample request:
    /// 
    ///     DELETE api/result/for-job-5/cache
    /// 
    /// </remarks>
    /// <param name="jobId">The numeric identifier of the job to delete job cache for.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    /// <response code="400">If the job is not in the Finished or Failed status.</response>
    /// <response code="404">If the job does not exist.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [HttpDelete("for-job-{jobId:int}/cache")]
    public async Task<ActionResult> DeleteCache(int jobId)
    {
        Job job = await _ctx.Jobs.FirstOrDefaultAsync(o => o.Id == jobId);
        if (job == null)
            return NotFound();

        if (job.Status != RunningStatus.Finished && job.Status != RunningStatus.Failed)
            return ValidationProblem();

        string[] ligands = await _ctx.GetJobLigands(jobId).Select(o => o.Id.StringifyId()).ToArrayAsync();
        string[] proteins = await _ctx.GetJobProteins(jobId).Select(o => o.Id).ToArrayAsync();

        string workdir = Path.Combine(_env.ContentRootPath, "Workspace", "Output");
        try
        {
            foreach (string ligand in ligands)
            {
                foreach (string protein in proteins)
                {
                    Directory.Delete(Path.Combine(workdir, ligand, protein), true);
                }
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return Conflict(ex);
        }
    }
}
