using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTO.Request;

public sealed record BudgetRequestDto
{
    [Required(ErrorMessage = "O campo clienteId é obrigatório")]
    public int? ClienteId { get; set; }

    [Required(ErrorMessage = "O campo veiculoId é obrigatório")]
    public int? VeiculoId { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "O orçamento deve ter pelo menos um item")]
    public required List<ItemRequestDto> Itens { get; set; }
}
