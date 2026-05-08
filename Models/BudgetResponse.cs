namespace GarageBudgetApi.Models;

public sealed record BudgetResponse(
    int Id,
    int ClienteId,
    int VehicleId,
    IReadOnlyCollection<BudgetItemResponse> Items,
    decimal TotalAmount,
    DateTimeOffset CreatedAtUtc);