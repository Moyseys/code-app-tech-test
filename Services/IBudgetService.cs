using GarageBudgetApi.Models;

namespace GarageBudgetApi.Services;

public interface IBudgetService
{
    BudgetResponse CreateBudget(BudgetCreateRequest request);

    BudgetResponse? GetBudgetById(int id);
}