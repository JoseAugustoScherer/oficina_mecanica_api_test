using System.ComponentModel.DataAnnotations;

namespace Oficina.Domain.Entities;

public class Item
{
    [Required(ErrorMessage = "A descrição do item é obrigatória")]
    public string Descricao { get; private set; }

    [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
    public int Quantidade { get; private set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor unitário deve ser maior que zero")]
    public decimal ValorUnitario { get; private set; }

    public Item(string descricao, int quantidade, decimal valorUnitario)
    {
        Descricao = descricao;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public void SetDescricao(string descricao) => Descricao = descricao;
    public void SetQuantidade(int quantidade) => Quantidade = quantidade;
    public void SetValorUnitario(decimal valorUnitario) => ValorUnitario = valorUnitario;
}
