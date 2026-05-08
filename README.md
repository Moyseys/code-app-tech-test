# GarageBudgetApi

## Breve descrição

Uma API simples para gerenciar orçamentos. Contém controladores, modelos, repositório em memória e serviço de negócio.

## Pré-requisitos

- .NET SDK 9.0 ou superior

## Como compilar e executar

1. Restaurar dependências e compilar:

```bash
dotnet build
```

2. Executar a aplicação:

```bash
dotnet run
```

A URL e a porta serão exibidas no console (ex.: http://localhost:5000).

## API

Os endpoints principais estão em [Controllers/BudgetsController.cs](Controllers/BudgetsController.cs). Use ferramentas como `curl` ou Postman para testar.

Exemplo (GET):

```bash
curl http://localhost:5000/budgets
```

Exemplo (POST):

Envie um novo orçamento com JSON contendo `name` e `items` (cada item com `name` e `amount`). Exemplo:

```bash
curl -X POST http://localhost:5000/budgets \
  -H "Content-Type: application/json" \
  -d '{"name":"Orçamento Exemplo","items":[{"name":"Item A","amount":100.0}]}'
```

Resposta esperada: código `201 Created` com o objeto criado.
