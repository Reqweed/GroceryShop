using System.Text.Json;

namespace GroceryShop.DAL.Entities.ErrorModels;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Path { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}