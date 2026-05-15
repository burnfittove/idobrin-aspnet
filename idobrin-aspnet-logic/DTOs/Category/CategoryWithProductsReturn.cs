using idobrin_aspnet_logic.DTOs.Products;

namespace idobrin_aspnet_logic.DTOs.Category;

public record CategoryWithProductsReturn(int Id, string Name, IEnumerable<ProductReturn> products);