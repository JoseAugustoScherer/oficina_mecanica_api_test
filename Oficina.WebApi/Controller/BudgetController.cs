using Microsoft.AspNetCore.Mvc;
using Oficina.Application.DTO.Request;
using Oficina.Application.DTO.Response;
using Oficina.Domain.Entities;

namespace Oficina.WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] BudgetRequestDto request)
    {
        var itens = request.Itens
            .Select(i => new Item(i.Descricao, i.Quantidade, i.ValorUnitario))
            .ToList();

        var orcamento = new Budget(request.ClienteId, request.VeiculoId, itens);

        var response = new BudgetResponseDto
        {
            ClienteId = orcamento.ClienteId,
            VeiculoId = orcamento.VeiculoId,
            Total = orcamento.Total,
            Itens = orcamento.Itens
                .Select(i => new ItemResponseDto(i.Descricao, i.Quantidade, i.ValorUnitario))
                .ToList()
        };

        return Created(string.Empty, response);
    }
}
