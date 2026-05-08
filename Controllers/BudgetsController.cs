using GarageBudgetApi.Models;
using GarageBudgetApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GarageBudgetApi.Controllers;

[ApiController]
[Route("api/budgets")]
public sealed class BudgetsController(IBudgetService budgetService) : ControllerBase
{
    private readonly IBudgetService budgetService = budgetService;

    [HttpPost]
    public ActionResult<BudgetResponse> Create([FromBody] BudgetCreateRequest request)
    {
        var budget = budgetService.CreateBudget(request);

        return CreatedAtAction(nameof(GetById), new { id = budget.Id }, budget);
    }

    [HttpGet("{id:int}")]
    public ActionResult<BudgetResponse> GetById(int id)
    {
        var budget = budgetService.GetBudgetById(id);

        if (budget is null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Budget not found",
                Detail = $"No budget was found for id {id}."
            });
        }

        return Ok(budget);
    }
}