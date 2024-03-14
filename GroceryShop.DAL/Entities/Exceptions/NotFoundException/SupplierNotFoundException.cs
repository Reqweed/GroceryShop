namespace GroceryShop.DAL.Entities.Exceptions.NotFoundException;

public class SupplierNotFoundException : NotFoundException
{
    public SupplierNotFoundException() : base("Suppliers not found.") { }
    public SupplierNotFoundException(Guid idSupplier) : base($"Supplier with ID ({idSupplier}) not found.") { }

}