using GroceryShop.DAL.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace GroceryShop.DAL.Initializers;

public static class DataInitializer
{
    public static IEnumerable<User> Users { get; set; }
    public static IEnumerable<Category> Categories { get; set; }
    public static IEnumerable<Supplier> Suppliers { get; set; }
    public static IEnumerable<Product> Products { get; set; }
    public static IEnumerable<Role> Roles { get; set; }
    public static IEnumerable<IdentityUserRole<Guid>> IdentityUserRoles { get; set; }

    static DataInitializer()
    {
        GetCategories();
        GetSuppliers();
        GetProducts();
        GetRoles();
        GetUsers();
        GetIdentityRoles();
    }
    private static void GetCategories()
    {
        Categories = new List<Category>
        {
            new() { Id = Guid.NewGuid(), Name = "Fruits and Vegetables" },
            new() { Id = Guid.NewGuid(), Name = "Meat and Poultry" },
            new() { Id = Guid.NewGuid(), Name = "Confectionery" },
            new() { Id = Guid.NewGuid(), Name = "Groceries" },
            new() { Id = Guid.NewGuid(), Name = "Pet Food" }
        };
    }

    private static void GetSuppliers()
    {
        Suppliers = new List<Supplier>
        {
            new() { Id = Guid.NewGuid(), Name = "GreenGrocer Inc.", ContactNumber = "555-123-4567" },
            new() { Id = Guid.NewGuid(), Name = "FarmFresh Foods", ContactNumber = "555-987-6543" },
            new() { Id = Guid.NewGuid(), Name = "Poultry Paradise", ContactNumber = "555-789-0123" },
            new() { Id = Guid.NewGuid(), Name = "Dairy Delight", ContactNumber = "555-234-5678" },
            new() { Id = Guid.NewGuid(), Name = "Seafood Sensations", ContactNumber = "555-876-5432" }
        };
    }

    private static void GetProducts()
    {
        Products = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(), Name = "Apple", CategoryId = Categories.ElementAt(0).Id,
                SupplierId = Suppliers.ElementAt(0).Id, StockQuantity = 100, Price = 1.50m,
                Description = "Fresh and delicious apple"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Banana", CategoryId = Categories.ElementAt(0).Id,
                SupplierId = Suppliers.ElementAt(0).Id, StockQuantity = 150, Price = 0.75m,
                Description = "Ripe and sweet banana"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Chicken Breast", CategoryId = Categories.ElementAt(1).Id,
                SupplierId = Suppliers.ElementAt(2).Id, StockQuantity = 50, Price = 5.99m,
                Description = "Fresh chicken breast, skinless and boneless"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Ground Beef", CategoryId = Categories.ElementAt(1).Id,
                SupplierId = Suppliers.ElementAt(2).Id, StockQuantity = 80, Price = 7.49m,
                Description = "Lean ground beef, perfect for burgers and meatballs"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Chocolate Bar", CategoryId = Categories.ElementAt(2).Id,
                SupplierId = Suppliers.ElementAt(1).Id, StockQuantity = 120, Price = 2.25m,
                Description = "Creamy milk chocolate bar"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Gummy Bears", CategoryId = Categories.ElementAt(2).Id,
                SupplierId = Suppliers.ElementAt(1).Id, StockQuantity = 200, Price = 1.99m,
                Description = "Assorted fruit-flavored gummy bears"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Flour", CategoryId = Categories.ElementAt(3).Id,
                SupplierId = Suppliers.ElementAt(3).Id, StockQuantity = 300, Price = 3.49m,
                Description = "All-purpose flour for baking and cooking"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Rice", CategoryId = Categories.ElementAt(3).Id,
                SupplierId = Suppliers.ElementAt(3).Id, StockQuantity = 250, Price = 2.99m,
                Description = "Long-grain white rice, great for side dishes"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Dog Food", CategoryId = Categories.ElementAt(4).Id,
                SupplierId = Suppliers.ElementAt(4).Id, StockQuantity = 100, Price = 12.99m,
                Description = "Nutritious dry dog food, suitable for all breeds"
            },
            new()
            {
                Id = Guid.NewGuid(), Name = "Cat Food", CategoryId = Categories.ElementAt(4).Id,
                SupplierId = Suppliers.ElementAt(4).Id, StockQuantity = 80, Price = 9.99m,
                Description = "Wholesome wet cat food, made with real meat and fish"
            },
        };
    }

    private static void GetRoles()
    {
        Roles = new List<Role>
        {
            new() { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN" },
            new() { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER" }
        };
    }

    private static void GetUsers()
    {
        Users = new List<User>
        {
            new()
            {
                Id = Guid.NewGuid(),
                UserName = "Admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "1234"),
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new()
            {
                Id = Guid.NewGuid(),
                UserName = "user",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "1111"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        };
    }

    private static void GetIdentityRoles()
    {
        IdentityUserRoles = new List<IdentityUserRole<Guid>>
        {
            new() { UserId = Users.ElementAt(0).Id, RoleId = Roles.ElementAt(0).Id },
            new() { UserId = Users.ElementAt(1).Id, RoleId = Roles.ElementAt(1).Id }
        };
    }
}