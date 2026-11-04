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
    }
}
