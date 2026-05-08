using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GarageBudgetApi.Models;

public sealed class BudgetItemRequest : IValidatableObject
{
    [JsonPropertyName("descricao")]
    public string? Description { get; set; }

    [JsonPropertyName("quantidade")]
    public int Quantity { get; set; }

    [JsonPropertyName("valorUnitario")]
    public decimal UnitPrice { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Description))
        {
            yield return new ValidationResult("Each item must have a description.", [nameof(Description)]);
        }

        if (Quantity <= 0)
        {
            yield return new ValidationResult("Each item quantity must be greater than zero.", [nameof(Quantity)]);
        }

        if (UnitPrice <= 0)
        {
            yield return new ValidationResult("Each item unit price must be greater than zero.", [nameof(UnitPrice)]);
        }
    }
}