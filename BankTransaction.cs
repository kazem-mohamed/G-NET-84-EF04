namespace G_NET_84_EF04;

public class BankTransaction
{
    public string TransactionNumber { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public string? Note { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public Account Account { get; set; } = null!;
}
