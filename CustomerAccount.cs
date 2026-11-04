namespace G_NET_84_EF04;

public class CustomerAccount
{
    public string AccountNumber { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public OwnershipType OwnershipType { get; set; }
    public DateTime OwnershipStartDate { get; set; }
    public AccountStatus AccountStatus { get; set; }
    public Account Account { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}
