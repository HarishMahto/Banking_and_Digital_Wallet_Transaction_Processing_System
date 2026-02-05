public class Reversal
{
    public Guid Id { get; set; }

    public Guid OriginalTransactionId { get; set; }
    public Guid ReversalTransactionId { get; set; }

    public DateTime CreatedAt { get; set; }
}
