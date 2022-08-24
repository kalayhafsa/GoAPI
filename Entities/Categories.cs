#nullable disable
public class Categories
{
    public int id { get; set; }
    public int sambaId { get; set; }
    public string sambaName { get; set; }
    public string displayName { get; set; }
    public int? parentId { get; set; }
    public int? sortOrder { get; set; }
    public string displayPicture { get; set; }
    public bool isActive { get; set; }
    public int? masterUserId { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}