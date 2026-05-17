using idobrin_aspnet_logic.DTOs.Category;

namespace idobrin_aspnet_logic.DTOs.Products;

public record ProductWithCategoriesReturn(int Id, string Name, float Price, IEnumerable<CategoryReturn> Categories);