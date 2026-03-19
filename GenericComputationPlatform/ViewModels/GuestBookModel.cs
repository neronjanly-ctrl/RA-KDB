using GenericComputationPlatform.DataModels;

namespace GenericComputationPlatform.ViewModels;

public class GuestBookModel : Paginated
{
    public GuestbookPost[] Posts { get; set; }
}
