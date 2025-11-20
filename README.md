# 📋 Pausinha Software - API Documentation

## 🎯 Sobre o Projeto
O **Pausinha Software** é uma solução inteligente que promove bem-estar, movimento e equilíbrio para colaboradores de empresas modernas — tanto em escritórios corporativos quanto em home offices.

**Tema:** O Futuro do Trabalho e o Bem-Estar Corporativo

---

## 👥 Integrantes do Projeto
- **Caio Hideki** — RM553630  
- **Jorge Booz** — RM552700  
- **Mateus Tibão** — RM553267

---

## 🚀 Tecnologias Utilizadas
- **.NET 10.0** – Framework principal  
- **Entity Framework Core** – ORM e acesso a dados  
- **SQLite** – Banco de dados para desenvolvimento  
- **Swagger / OpenAPI** – Documentação automática da API  
- **ASP.NET Core Web API** – Framework web da aplicação  

---

## 📁 Estrutura do Projeto
```
Pausinha.api/
├── Controllers/           # Controladores REST
├── Entities/              # Entidades de domínio
├── Infrastructure/        # Persistência e repositórios  
├── Application/           # Serviços e regras de negócio
├── Program.cs             # Configuração da aplicação
└── appsettings.json       # Configurações
```

---

## 🗃️ Modelo de Dados

### **Entidades Principais**
- **Company** – Empresas cadastradas  
- **Employee** – Colaboradores das empresas  
- **BreakConfig** – Configurações de pausas  
- **BreakSession** – Registros de pausas realizadas  

---

## 🔌 Endpoints da API

### 📊 **Companies**
- `GET /api/Companies` – Listar empresas  
- `GET /api/Companies/{id}` – Buscar empresa por ID  
- `POST /api/Companies` – Criar nova empresa  
- `PUT /api/Companies/{id}` – Atualizar empresa  
- `DELETE /api/Companies/{id}` – Remover empresa  

### 👥 **Employees**
- `GET /api/Employees` – Listar colaboradores  
- `GET /api/Employees/{id}` – Buscar colaborador por ID  
- `POST /api/Employees` – Criar novo colaborador  
- `PUT /api/Employees/{id}` – Atualizar colaborador  
- `DELETE /api/Employees/{id}` – Remover colaborador  

### ⏰ **Break Sessions**
- `GET /api/BreakSessions` – Listar pausas registradas  
- `POST /api/BreakSessions` – Registrar nova pausa  
- `GET /api/BreakSessions/{id}` – Buscar pausa por ID  

---

## 🛠️ Configuração e Execução

### **Pré-requisitos**
- .NET 10.0 SDK  
- Visual Studio 2022 ou VS Code  

### **Executar Localmente**

#### 1. Clone o repositório
```bash
git clone https://github.com/jorgebooz/pausinha-csharp
cd pausinha-csharp
```

#### 2. Navegue até o projeto API
```bash
cd Pausinha.api
```

#### 3. Execute as migrations
```bash
dotnet ef database update
```

#### 4. Execute a aplicação
```bash
dotnet run
```

#### 5. Acesse a documentação
```
https://localhost:7014/swagger
```

---

## 🧰 Comandos Úteis
```bash
# Criar nova migration
dotnet ef migrations add [NomeMigration]

# Atualizar banco de dados
dotnet ef database update

# Limpar e recriar banco
dotnet ef database drop --force
dotnet ef database update
```

---

## 🎨 Exemplos de Uso

### Criar Empresa
```json
POST /api/Companies
{
  "name": "Tech Solutions",
  "cnpj": "12345678000195"
}
```

### Criar Colaborador
```json
POST /api/Employees
{
  "name": "João Silva",
  "email": "joao@empresa.com",
  "workMode": 1,
  "companyId": "guid-da-empresa"
}
```

### Registrar Pausa
```json
POST /api/BreakSessions
{
  "startTime": "2024-01-15T10:00:00",
  "endTime": "2024-01-15T10:10:00",
  "breakType": "Stretching",
  "employeeId": "guid-do-colaborador"
}
```

---

## 📊 WorkMode (Modo de Trabalho)
- **0 – Office (Presencial)**  
- **1 – HomeOffice (Remoto)**  

---

## 🔒 Considerações de Segurança
- Dados armazenados localmente (SQLite)  
- Estrutura preparada para autenticação JWT  
- Compatível com LGPD  

---

## 🚀 Próximas Funcionalidades
- Relatórios de bem-estar  
- Integração com Microsoft Teams / Slack  
- Sistema de gamificação  
- Módulo de visão computacional para validação de pausas  

---

## 📞 Suporte
Para dúvidas ou problemas, abra uma *issue* no repositório do projeto.

---

## 📄 Licença
Este projeto é desenvolvido para fins acadêmicos.

---

Desenvolvido com ❤️ para um futuro do trabalho mais humano e saudável.
