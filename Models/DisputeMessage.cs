public class DisputeMessage
{
    public Guid Id { get; set; }

    public Guid DisputeId { get; set; }
    public string Message { get; set; } = default!;

    public DateTime CreatedAt { get; set; }

    // Navigation Properties
    public Dispute? Dispute { get; set; }
}
