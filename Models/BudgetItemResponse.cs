namespace GarageBudgetApi.Models;

public sealed record BudgetItemResponse(
    string Description,
    int Quantity,
    decimal UnitPrice,
    decimal TotalAmount);