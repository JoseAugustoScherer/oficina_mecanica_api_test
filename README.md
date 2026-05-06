# Oficina Mecânica API

API REST em .NET 8 para gerenciamento de orçamentos de uma oficina mecânica.

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Swagger / OpenAPI

## Estrutura do projeto

```
Oficina/
├── Oficina.Domain/         # Entidades de domínio
│   └── Entities/
│       ├── Budget.cs       # Orçamento
│       └── Item.cs         # Item do orçamento
├── Oficina.Application/    # DTOs de entrada e saída
│   └── DTO/
│       ├── Request/
│       │   ├── BudgetRequestDto.cs
│       │   └── ItemRequestDto.cs
│       └── Response/
│           ├── BudgetResponseDto.cs
│           └── ItemResponseDto.cs
└── Oficina.WebApi/         # Controllers e configuração
    └── Controller/
        └── BudgetController.cs
```

## Como executar

```bash
cd Oficina.WebApi
dotnet run
```

Acesse a documentação interativa em: `http://localhost:5161/swagger`

## Endpoints

### Cadastrar orçamento

`POST /api/budget`

**Body:**
```json
{
  "clienteId": 10,
  "veiculoId": 25,
  "itens": [
    {
      "descricao": "Troca de óleo",
      "quantidade": 1,
      "valorUnitario": 120.00
    },
    {
      "descricao": "Filtro de óleo",
      "quantidade": 1,
      "valorUnitario": 45.00
    }
  ]
}
```

**Resposta (201 Created):**
```json
{
  "clienteId": 10,
  "veiculoId": 25,
  "itens": [
    {
      "descricao": "Troca de óleo",
      "quantidade": 1,
      "valorUnitario": 120.00
    },
    {
      "descricao": "Filtro de óleo",
      "quantidade": 1,
      "valorUnitario": 45.00
    }
  ],
  "total": 165.00
}
```

## Regras de validação

| Campo | Regra |
|---|---|
| `clienteId` | Obrigatório |
| `veiculoId` | Obrigatório |
| `itens` | Pelo menos 1 item |
| `itens[].descricao` | Obrigatório |
| `itens[].quantidade` | Maior que zero |
| `itens[].valorUnitario` | Maior que zero |

O campo `total` é calculado automaticamente pela API como a soma de `quantidade * valorUnitario` de cada item.

Dados inválidos retornam `400 Bad Request` com mensagem descritiva.
