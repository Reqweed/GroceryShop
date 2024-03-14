using GroceryShop.DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryShop.DAL.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Address).IsRequired();
        builder.Property(o => o.OrderStatus).IsRequired().HasConversion<string>();
        builder.Property(o => o.TotalPrice).IsRequired().HasPrecision(18, 2);
    }
}