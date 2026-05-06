namespace Oficina.Domain.Entities;

public class Budget
{
    public int? ClienteId { get; private set; }
    public int? VeiculoId { get; private set; }
    public IReadOnlyList<Item> Itens { get; }
    public decimal Total { get; private set; }

    public Budget(int? clienteId, int? veiculoId, List<Item> itens)
    {
        ClienteId = clienteId;
        VeiculoId = veiculoId;
        Itens = itens;
        Total = Itens.Sum(i => i.Quantidade * i.ValorUnitario);
    }
}
