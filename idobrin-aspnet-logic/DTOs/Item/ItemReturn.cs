using idobrin_aspnet_logic.DTOs.Products;

namespace idobrin_aspnet_logic.DTOs.Item;

public record ItemReturn(int Id, int Quantity, decimal Price, ProductReturn Product);