#nullable disable
public partial class MasterUsers
{
    public int id { get; set; }
    public string email { get; set; }
    public long customerId { get; set; }
    public DateTime? createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
}