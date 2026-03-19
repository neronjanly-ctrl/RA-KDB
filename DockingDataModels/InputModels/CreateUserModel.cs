using System.ComponentModel.DataAnnotations;

namespace DockingDataModels;

/// <summary>
/// The input model for creating a user.
/// </summary>
public class CreateUserModel
{
    /// <summary>
    /// The email address of the user.
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    /// <summary>
    /// The full name of the user.
    /// </summary>
    [Required]
    public string Name { get; set; }
}
