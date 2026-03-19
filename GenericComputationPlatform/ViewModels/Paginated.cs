namespace GenericComputationPlatform.ViewModels;

public class Paginated
{
    public int PageNum { get; set; }
    public int PageCount => (TotalCount - 1) / PageSize + 1;
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
