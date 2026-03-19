using CommonTools;
using DockingApiService.DataModels;
using DockingDataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DockingApiService.Controllers;

[Route("cavity")]
[ApiController]
[ResponseCache(Duration = 600)]
public class CavityController : ControllerBase
{
    private readonly ComputationContext _ctx;

    public CavityController(ComputationContext ctx)
    {
        _ctx = ctx;
    }

    /// <summary>
    /// Gets the information of the protein cavity for a given <paramref name="cavityId"/>.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET api/cavity/6d2c809cadb57f9a
    /// 
    /// </remarks>
    /// <param name="cavityId">The 64-bit hexadecimal cavity identifier. e.g. 6d2c809cadb57f9a.</param>
    /// <returns>A instance representing the protein cavity.</returns>
    /// <response code="200">Sucessful operation.</response>
    /// <response code="404">If the cavity does not exist.</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [HttpGet("{cavityId:required}")]
    public async Task<ActionResult<Cavity>> GetOne(string cavityId)
    {
        long cavityIdl = cavityId.ParseId();

        Cavity cavity = await _ctx.GetCavities()
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == cavityIdl);

        if (cavity == null)
            return NotFound();

        return cavity;
    }
}
