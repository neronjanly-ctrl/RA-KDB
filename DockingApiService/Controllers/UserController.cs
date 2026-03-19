using DockingApiService.DataModels;
using DockingDataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DockingApiService.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ComputationContext _ctx;

    public UserController(ComputationContext ctx)
    {
        _ctx = ctx;
    }

    /// <summary>
    /// Puts a user in the database with its email address.
    /// </summary>
    /// <remarks>
    /// The email and its internal ID are a reversable one-to-one mapping. Sample request:
    /// 
    ///     PUT api/ligand
    ///     {
    ///       "Email": "john.smith@example.com",
    ///       "Name": "John Smith"
    ///     }
    /// 
    /// </remarks>
    /// <param name="model">Parameters as defined in CreateUserModel. See sample request for more.</param>
    /// <returns>No return value.</returns>
    /// <response code="204">Sucessful operation.</response>
    [ProducesResponseType(204)]
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CreateUserModel model)
    {
        User user = await _ctx.Users
            .Where(o => o.Email == model.Email.Trim().ToLower())
            .SingleOrDefaultAsync();

        if (user == null)
        {
            user = new User();
            user.Init(model.Email, model.Name);
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }

        return NoContent();
    }
}
