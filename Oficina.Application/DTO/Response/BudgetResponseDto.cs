namespace Oficina.Application.DTO.Response;

public sealed record BudgetResponseDto
{
    public int? ClienteId { get; set; }
    public int? VeiculoId { get; set; }
    public List<ItemResponseDto> Itens { get; set; }
    public decimal Total { get; set; }
}
