# 🧮 Calculadora SQIA

Este projeto implementa uma API para cálculo de investimentos pós-fixados com base em uma série histórica de cotações do indexador **SQI**. O sistema aplica o conceito de **juros compostos** diários com base na **taxa anual** fornecida diariamente, desconsiderando finais de semana e feriados.

## ✅ O que o projeto resolve?

Permite calcular, com base em uma data inicial, data final e valor investido:

- O **fator acumulado** de rendimento no período;
- O **valor atualizado** com base nas cotações armazenadas no banco;
- Um histórico detalhado do cálculo (caso desejado);
- Tudo isso respeitando regras como dias úteis e ausência de cotação para fins de semana.

---

## 🚀 Como executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Podman](https://podman.io/) ou Docker
- [DBeaver](https://dbeaver.io/) ou outro client SQL
- Visual Studio 2022 ou outro editor compatível

### Clonando o repositório

```bash
git clone https://github.com/seu-usuario/calculadora-sqia.git
cd calculadora-sqia
```

### Subindo os containers

```bash
podman compose up -d
```

> Isso irá subir o SQL Server na porta `1435`.

### Rodando as migrations

No **Package Manager Console** do Visual Studio:

```powershell
Update-Database -Project Sinqia.CalculadoraSQIA.Infrastructure -StartupProject Sinqia.CalculadoraSQIA.Api
```

### Rodando a aplicação

No terminal:

```bash
dotnet run --project Sinqia.CalculadoraSQIA/Sinqia.CalculadoraSQIA.Api.csproj
```

Acesse: [https://localhost:5000/swagger](https://localhost:5000/swagger)

---

## 📌 Exemplo de uso (Swagger)

**Endpoint**: `POST /v1/investimentos/calcular`

**Body de exemplo**:

```json
{
  "valorInvestido": 10000,
  "dataAplicacao": "2025-03-13",
  "dataFinal": "2025-03-21"
}
```

**Retorno**:

```json
{
  "valorAtualizado": 10027.40632967,
  "fatorAcumulado": 1.0027406329672246
}
```

---

## 🧠 Tecnologias e práticas utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server (em container Podman)
- Clean Architecture (camadas bem separadas)
- Boas práticas: logs, validações, tratamento de exceções
- Swagger para documentação da API