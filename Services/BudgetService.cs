using GarageBudgetApi.Models;
using GarageBudgetApi.Repositories;

namespace GarageBudgetApi.Services;

public sealed class BudgetService(IBudgetRepository budgetRepository) : IBudgetService
{
    private readonly IBudgetRepository budgetRepository = budgetRepository;

    public BudgetResponse CreateBudget(BudgetCreateRequest request)
    {
        var items = request.Items!
            .Select(item => new BudgetItemResponse(item.Description!.Trim(), item.Quantity, item.UnitPrice, item.Quantity * item.UnitPrice))
            .ToList();

        var totalAmount = items.Sum(item => item.TotalAmount);

        var budget = new BudgetResponse(
            budgetRepository.GetNextId(),
            request.ClienteId!.Value,
            request.VehicleId!.Value,
            items,
            totalAmount,
            DateTimeOffset.UtcNow);

        budgetRepository.Add(budget);

        return budget;
    }

    public BudgetResponse? GetBudgetById(int id)
    {
        return budgetRepository.GetById(id);
    }
}