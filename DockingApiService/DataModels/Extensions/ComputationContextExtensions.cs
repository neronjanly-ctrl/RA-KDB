using DockingDataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockingApiService.DataModels;

public static class ComputationContextExtensions
{
    public static IQueryable<Cavity> GetCavities(this ComputationContext context)
    {
        // get all cavities for a protein
        IIncludableQueryable<Cavity, List<Structure>> cavities = context.Cavities
            .Include(o => o.Protein)
            .ThenInclude(o => o.Properties)
            .Include(o => o.Structures);
        return cavities;
    }

    public static IQueryable<Protein> GetProteins(this ComputationContext context)
    {
        // get proteins with properties loaded
        IIncludableQueryable<Protein, ProteinProperties> proteins = context.Proteins
            .Include(o => o.Properties);
        return proteins;
    }

    public static IQueryable<Cavity> GetProteinCavities(this ComputationContext context, string proteinId)
    {
        // get all cavities for a protein
        IQueryable<Cavity> cavities = context.Proteins
            .Where(o => o.Id == proteinId)
            .SelectMany(o => o.Cavities);
        return cavities;
    }

    public static IQueryable<Domain> GetProteinDomains(this ComputationContext context, string proteinId)
    {
        // get all domains the protein is in
        IQueryable<Domain> domains = context.Proteins
            .Where(o => o.Id == proteinId)
            .SelectMany(o => o.ProteinDomains)
            .Select(o => o.Domain);
        return domains;
    }

    #region Get for jobs

    public static IQueryable<Job> GetJobs(this ComputationContext context)
    {
        // get jobs with ligands and domains loaded
        IIncludableQueryable<Job, Domain> jobs = context.Jobs
            .Include(o => o.User)
            .Include(o => o.JobLigands)
            .ThenInclude(o => o.Ligand)
            .Include(o => o.JobDomains)
            .ThenInclude(o => o.Domain);
        return jobs;
    }

    public static IQueryable<Job> GetJobs(this ComputationContext context, string domainId)
    {
        // get jobs in a specific domain with ligands and domains loaded
        // no include after select for now: https://github.com/dotnet/efcore/issues/16752
        IIncludableQueryable<Job, Domain> jobs = context.Jobs
            .Where(o => o.JobDomains.Any(p => p.DomainId == domainId))
            .Include(o => o.User)
            .Include(o => o.JobLigands)
            .ThenInclude(o => o.Ligand)
            .Include(o => o.JobDomains)
            .ThenInclude(o => o.Domain);
        return jobs;
    }

    public static IQueryable<Job> GetUserJobs(this ComputationContext context, string userId)
    {
        // get jobs for a specific user with ligands and domains loaded
        IIncludableQueryable<Job, Domain> jobs = context.Jobs
            .Where(o => o.UserId == userId)
            .Include(o => o.User)
            .Include(o => o.JobLigands)
            .ThenInclude(o => o.Ligand)
            .Include(o => o.JobDomains)
            .ThenInclude(o => o.Domain);
        return jobs;
    }

    public static IQueryable<Domain> GetJobDomains(this ComputationContext context, int jobId)
    {
        // get all domains for a job
        IQueryable<Domain> domains = context.Jobs
            .Where(o => o.Id == jobId)
            .SelectMany(o => o.JobDomains)
            .Select(o => o.Domain);
        return domains;
    }

    public static IQueryable<Ligand> GetJobLigands(this ComputationContext context, int jobId)
    {
        // get all ligands for a job
        IQueryable<Ligand> ligands = context.Jobs
            .Where(o => o.Id == jobId)
            .SelectMany(o => o.JobLigands)
            .Select(o => o.Ligand)
            .Distinct();
        return ligands;
    }

    public static IQueryable<Protein> GetJobProteins(this ComputationContext context, int jobId)
    {
        // get all proteins for a job
        IQueryable<Protein> proteins = context.GetJobDomains(jobId)
            .SelectMany(o => o.DomainProteins)
            .Select(o => o.Protein)
            .Distinct();
        return proteins;
    }

    public static async Task<IQueryable<Cavity>> GetJobCavities(this ComputationContext context, int jobId)
    {
        // get all protein cavities for a job
        long[] cavityIds = await context.GetJobDomains(jobId)
            .SelectMany(o => o.DomainProteins)
            .Select(o => o.Protein)
            .SelectMany(o => o.Cavities)
            .Select(o => o.Id)
            .Distinct()
            .ToArrayAsync();
        IIncludableQueryable<Cavity, Protein> cavities = context.Cavities
            .Where(o => cavityIds.Contains(o.Id))
            .Include(o => o.Protein);
        return cavities;
    }

    public static IQueryable<Result> GetJobResults(this ComputationContext context, int jobId)
    {
        // get all results for a job
        return context.Jobs
            .Where(o => o.Id == jobId)
            .SelectMany(o => o.Results);
    }

    public static IQueryable<Result> GetJobResultsForCavity(this ComputationContext context, int jobId, long cavityId)
    {
        // get all results of a protein for a job
        return context.GetJobResults(jobId)
            .Where(o => o.CavityId == cavityId);
    }

    public static IQueryable<Result> GetJobResultsForLigand(this ComputationContext context, int jobId, long ligandId)
    {
        // get all results of a ligand for a job
        return context.GetJobResults(jobId)
            .Where(o => o.LigandId == ligandId);
    }

    #endregion

    public static IQueryable<Job> GetDomainJobs(this ComputationContext context, string domainId)
    {
        // get all jobs for a domain
        return context.Domains
            .Where(o => o.Id == domainId)
            .SelectMany(o => o.DomainJobs)
            .Select(o => o.Job);
    }

    public static IQueryable<Job> GetDomainJobs(this ComputationContext context, string[] domainIds)
    {
        // get all jobs for a domain
        return context.Domains
            .Where(o => domainIds.Contains(o.Id))
            .SelectMany(o => o.DomainJobs)
            .Select(o => o.Job)
            .Distinct();
    }

    public static IQueryable<Protein> GetDomainProteins(this ComputationContext context, string domainId)
    {
        // get all proteins for a domain
        return context.Domains
            .Where(o => o.Id == domainId)
            .SelectMany(o => o.DomainProteins)
            .Select(o => o.Protein);
    }

    public static IQueryable<Protein> GetDomainProteins(this ComputationContext context, string[] domainIds)
    {
        // get all proteins for multiple domains
        return context.Domains
            .Where(o => domainIds.Contains(o.Id))
            .SelectMany(o => o.DomainProteins)
            .Select(o => o.Protein)
            .Distinct();
    }

    public static IQueryable<Cavity> GetDomainCavities(this ComputationContext context, string domainId)
    {
        // get all protein cativies for a domain
        return context.Domains
            .Where(o => o.Id == domainId)
            .SelectMany(o => o.DomainProteins)
            .SelectMany(o => o.Protein.Cavities)
            .Include(o => o.Protein);
    }

    public static IQueryable<Cavity> GetDomainCativies(this ComputationContext context, string[] domainIds)
    {
        // get all protein cavities for multiple domains
        return context.Domains
            .Where(o => domainIds.Contains(o.Id))
            .SelectMany(o => o.DomainProteins)
            .SelectMany(o => o.Protein.Cavities)
            .Include(o => o.Protein)
            .Distinct();
    }

    public static IQueryable<Result> GetCavityResults(this ComputationContext context, long cavityId)
    {
        // get all proteins for a protein cavity
        return context.Cavities
            .Where(o => o.Id == cavityId)
            .SelectMany(o => o.Results);
    }

    public static IQueryable<Result> GetLigandResults(this ComputationContext context, long ligandId)
    {
        // get all proteins for a ligand
        return context.Ligands
            .Where(o => o.Id == ligandId)
            .SelectMany(o => o.Results);
    }

    public static async Task<int[]> CalcStagesForDomains(this ComputationContext context, string[] domainIds)
    {
        var cavityMeta = await context.GetDomainCativies(domainIds)
            .Select(o => new { o.StructureCount, o.Protein.HasActiveChemblCompounds, o.Protein.HasChemblCompounds, o.Protein.HasTrainedModels })
            .ToArrayAsync();

        // stage[0]: docking stages
        // stage[1]: hunting stages
        // stage[2]: prediction stages
        if (cavityMeta.Length == 0)
            return new int[3];

        int[] stages = cavityMeta
            .Select(o => new[] { o.StructureCount, o.HasActiveChemblCompounds ? 1 : 0, o.HasTrainedModels ? 1 : 0 })
            .Aggregate((a, b) => new[] { a[0] + b[0], a[1] + b[1], a[2] + b[2] });

        return stages;
    }
}
