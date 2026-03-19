using System;
using System.ComponentModel.DataAnnotations;

namespace GenericComputationPlatform.DataModels;

public class GuestbookPost
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    [EmailAddress]
    public string AuthorEmail { get; set; }
    public string Reply { get; set; }
    public string RepliedBy { get; set; }
    public DateTimeOffset CreatedTime { get; set; }
    public DateTimeOffset RepliedTime { get; set; }
}
