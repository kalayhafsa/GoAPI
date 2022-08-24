#nullable disable
public partial class Devices
{
    public long id { get; set; }
    public long customerId { get; set; }
    public string licenseType { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public string serialNumber { get; set; }
    public bool isActive { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public long licenseId { get; set; }
}