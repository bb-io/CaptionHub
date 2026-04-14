using Blackbird.Applications.Sdk.Common;

namespace Apps.CaptionHub.Models.Entities;

public class FolderEntity
{
    [Display("Folder ID")]
    public int Id { get; set; }

    public string Name { get; set; }

    [Display("Slug")]
    public string Slug { get; set; }

    [Display("Parent folder ID")]
    public int? ParentFolderId { get; set; }

    [Display("Projects count")]
    public int ProjectsCount { get; set; }

    [Display("Children count")]
    public int ChildrenCount { get; set; }
}
