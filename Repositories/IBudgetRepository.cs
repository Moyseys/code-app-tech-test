using GarageBudgetApi.Models;

namespace GarageBudgetApi.Repositories;

public interface IBudgetRepository
{
    int GetNextId();

    void Add(BudgetResponse budget);

    BudgetResponse? GetById(int id);
}