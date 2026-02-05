public class Limit
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public decimal DailyLimit { get; set; }

    // Navigation Properties
    public User? User { get; set; }
}
