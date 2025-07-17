Este projeto tem como objetivo aplicar conceitos modernos de engenharia de software utilizando o ecossistema .NET. Ele serve como base para construção de aplicações backend escaláveis e robustas, seguindo os princípios da **Clean Architecture**, **Domain-Driven Design (DDD)** com **Domínio Rico**, e **Minimal API** do .NET, com **persistência de dados em MongoDB**.

## 🎯 Objetivo

Criar uma arquitetura sólida e extensível que:

- Separe corretamente responsabilidades (camadas de domínio, aplicação, infraestrutura e apresentação)
- Utilize princípios de DDD com foco em modelagem rica de domínio
- Use Minimal APIs do .NET para endpoints enxutos e performáticos
- Persista os dados em uma base NoSQL (MongoDB)
- Sirva como base para novos módulos e funcionalidades

---

## 📐 Arquitetura

O projeto está organizado em camadas seguindo os princípios da Clean Architecture:

```
/src
│
├── Domain          → Entidades ricas, Value Objects, Aggregates, Interfaces de Repositório
├── Application     → Casos de uso, DTOs, Serviços de Aplicação
├── Infrastructure  → Repositórios MongoDB, configurações, implementações técnicas
├── API             → Endpoints (Minimal API), injeção de dependências, middlewares
```

---

## 🧠 Tecnologias e Conceitos

- **.NET 8** com **Minimal API**
- **Clean Architecture**
- **Domain-Driven Design (DDD)** com Domínio Rico
- **MongoDB** como banco de dados
- **Injeção de Dependência** com `Microsoft.Extensions.DependencyInjection`
- **Validação** com FluentValidation (opcional)
- **Mapeamento de objetos** com Mapster (opcional)
- **Tratamento de erros global**, filtros e middlewares customizados

---

## 🚀 Como executar

> ⚠️ Pré-requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/download) e [MongoDB](https://www.mongodb.com/try/download/community)

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/nome-do-repo.git

# Acesse o diretório
cd nome-do-repo

# Restaure os pacotes
dotnet restore

# Execute a aplicação
dotnet run --project src/API
```

A API estará disponível em: `https://localhost:5001` (ou conforme configuração do `launchSettings.json`)

---

## 🛠️ Estrutura de um Módulo (Exemplo: Cliente)

- `Domain/Entities/Cliente.cs`: Entidade com lógica rica
- `Domain/ValueObjects/Cpf.cs`: Value Object validando CPF
- `Application/UseCases/Clientes`: Casos de uso (Ex: CriarCliente)
- `Infrastructure/Persistence/Mongo/Repositories/ClienteRepository.cs`: Implementação do repositório
- `API/Endpoints/ClientesEndpoints.cs`: Rotas da Minimal API

---

## 📦 Roadmap

- [x] Setup inicial com Minimal API
- [x] Organização por camadas
- [x] Primeiro módulo: Cadastro de Cliente
- [ ] Autenticação e Autorização (JWT)
- [ ] Testes automatizados
- [ ] Integração com serviços externos
- [ ] CI/CD

---

## 🤝 Contribuição

Sinta-se à vontade para abrir *issues*, enviar *pull requests* ou sugerir melhorias. Vamos evoluir esse projeto juntos!

---

## 📄 Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](./LICENSE) para mais detalhes.
