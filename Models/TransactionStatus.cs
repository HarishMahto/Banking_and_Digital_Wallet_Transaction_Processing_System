public class TransactionStatus
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // Navigation Properties
    public ICollection<Transaction>? Transactions { get; set; }
}
