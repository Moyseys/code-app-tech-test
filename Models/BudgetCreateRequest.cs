using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GarageBudgetApi.Models;

public sealed class BudgetCreateRequest : IValidatableObject
{
    [JsonPropertyName("clienteId")]
    public int? ClienteId { get; set; }

    [JsonPropertyName("veiculoId")]
    public int? VehicleId { get; set; }

    [JsonPropertyName("itens")]
    public List<BudgetItemRequest>? Items { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!ClienteId.HasValue || ClienteId <= 0)
        {
            yield return new ValidationResult("Customer id is required and must be greater than zero.", [nameof(ClienteId)]);
        }

        if (!VehicleId.HasValue || VehicleId <= 0)
        {
            yield return new ValidationResult("Vehicle id is required and must be greater than zero.", [nameof(VehicleId)]);
        }

        if (Items is null || Items.Count == 0)
        {
            yield return new ValidationResult("At least one item is required.", [nameof(Items)]);
        }
    }
}