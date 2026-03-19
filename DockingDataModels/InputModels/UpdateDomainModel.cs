namespace DockingDataModels;

/// <summary>
/// The input model for updating a domain.
/// </summary>
public class UpdateDomainModel
{
    /// <summary>
    /// A new name for the domain
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A new description in MarkDown for the domain
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Some new citations in MarkDown for the domain
    /// </summary>
    public string Citations { get; set; }

    /// <summary>
    /// Some new keywords for the domain
    /// </summary>
    public string[] Keywords { get; set; }
}
