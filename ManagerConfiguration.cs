using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF04;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.Property(manager => manager.FullName).HasMaxLength(150).IsRequired();
        builder.Property(manager => manager.Email).HasMaxLength(200).IsRequired();
        builder.Property(manager => manager.PhoneNumber).HasMaxLength(30).IsRequired();
        builder.Property(manager => manager.BranchCode).HasMaxLength(20).IsRequired();
        builder.HasOne(manager => manager.Branch)
            .WithOne(branch => branch.Manager)
            .HasForeignKey<Manager>(manager => manager.BranchCode)
            .HasPrincipalKey<Branch>(branch => branch.Code)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Manager { Id = 1, FullName = "Mona Ahmed", Email = "mona.manager@bank.example", PhoneNumber = "01111111111", HireDate = new DateTime(2020, 1, 15), BranchCode = "CAI-01" },
            new Manager { Id = 2, FullName = "Nile Trading Manager", Email = "manager@bank.example", PhoneNumber = "01222222222", HireDate = new DateTime(2021, 6, 1), BranchCode = "ALX-01" });
    }
}
