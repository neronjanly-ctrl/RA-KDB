using System.ComponentModel.DataAnnotations;

namespace DockingDataModels;

/// <summary>
/// The input model for creating a user.
/// </summary>
public class CreateDomainModel
{
    /// <summary>
    /// The identifier of the domain.
    /// </summary>
    [Required]
    public string Id { get; set; }

    /// <summary>
    /// The name of the domain.
    /// </summary>
    [Required]
    public string Name { get; set; }
}
