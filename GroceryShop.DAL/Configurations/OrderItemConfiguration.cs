using GroceryShop.DAL.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryShop.DAL.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Quality).IsRequired(); 
        
        builder.HasOne(o => o.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}