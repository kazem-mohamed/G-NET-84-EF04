using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace G_NET_84_EF04;

public class BankContextFactory : IDesignTimeDbContextFactory<BankContext>
{
    public BankContext CreateDbContext(string[] args)
    {
        const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NationalBank;Trusted_Connection=True;TrustServerCertificate=True;";
        return new BankContext(new DbContextOptionsBuilder<BankContext>().UseSqlServer(connectionString).Options);
    }
}
