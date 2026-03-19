namespace DockingDataModels;

public class FileObject
{
    /// <summary>
    /// The content of the file.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// The MIME type of the file.
    /// </summary>
    public string MimeType { get; set; }

    /// <summary>
    /// The name of the file.
    /// </summary>
    public string FileName { get; set; }
}
