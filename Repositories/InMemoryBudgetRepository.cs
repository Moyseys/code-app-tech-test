using GarageBudgetApi.Models;
using System.Collections.Concurrent;

namespace GarageBudgetApi.Repositories;

public sealed class InMemoryBudgetRepository : IBudgetRepository
{
    private readonly ConcurrentDictionary<int, BudgetResponse> budgets = new();
    private int currentId = 0;

    public int GetNextId()
    {
        return Interlocked.Increment(ref currentId);
    }

    public void Add(BudgetResponse budget)
    {
        budgets[budget.Id] = budget;
    }

    public BudgetResponse? GetById(int id)
    {
        budgets.TryGetValue(id, out var budget);
        return budget;
    }
}