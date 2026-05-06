using System.ComponentModel.DataAnnotations;

namespace Oficina.Application.DTO.Request;

public sealed record ItemRequestDto(
    [Required(ErrorMessage = "A descrição do item é obrigatória")]
    string Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
    int Quantidade,

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor unitário deve ser maior que zero")]
    decimal ValorUnitario
);
