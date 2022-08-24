#nullable disable
public class Products
{
    public int id { get; set; }
    public int sambaId { get; set; }
    public string sambaName { get; set; }
    public string displayName { get; set; }
    public int? sortOrder { get; set; }
    public string displayPicture { get; set; }
    public decimal? price { get; set; }
    public bool isActive { get; set; }
    public int? masterUserId { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public int? categoryId { get; set; }
    public string desc { get; set; }
    public string allergens { get; set; }
}