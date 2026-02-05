public class KYCStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // Navigation Properties
    public ICollection<KYCRequest>? KYCRequests { get; set; }
}
