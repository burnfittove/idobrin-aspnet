namespace idobrin_aspnet_logic.DTOs;

public record CartProductsCreate(int CartId, int ProductId, int Quantity, float TotalPrice);