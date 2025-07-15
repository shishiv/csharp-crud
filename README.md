# Sistema de Cadastro de Livros - C# CRUD

Este é um sistema de cadastro de livros desenvolvido em C# que permite realizar operações CRUD (Create, Read, Update, Delete) em uma base de dados MySQL.

## 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (versão 8.0 ou superior)
- Um cliente MySQL (MySQL Workbench, phpMyAdmin, ou linha de comando)

## 🗄️ Configuração do Banco de Dados

1. **Criar o banco de dados:**
```sql
CREATE DATABASE aulas;
USE aulas;
```

2. **Criar a tabela de livros:**
```sql
CREATE TABLE livros (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    autor VARCHAR(255) NOT NULL,
    editora VARCHAR(255) NOT NULL,
    ano INT NOT NULL,
    isbn VARCHAR(50) NOT NULL,
    genero VARCHAR(100) NOT NULL
);
```

3. **Configurar a conexão:**
   - Por padrão, o sistema está configurado para conectar ao MySQL em:
     - Servidor: `127.0.0.1` (localhost)
     - Banco: `aulas`
     - Usuário: `root`
     - Senha: (vazia)
   
   Se suas configurações forem diferentes, edite o arquivo `src/Data/BdComum.cs` e altere a string de conexão.

## 🚀 Como Executar

### Opção 1: Usando o .NET CLI (Recomendado)

1. **Abra o terminal na pasta raiz do projeto**
2. **Restaure as dependências:**
```bash
dotnet restore
```

3. **Execute o projeto:**
```bash
dotnet run
```

### Opção 2: Compilar e Executar

1. **Compile o projeto:**
```bash
dotnet build
```

2. **Execute o arquivo compilado:**
```bash
dotnet bin/Debug/net8.0/CSharpCrud.dll
```

## 📁 Estrutura do Projeto

```
csharp-crud/
├── src/
│   ├── Data/
│   │   └── BdComum.cs          # Classe para conexão com o banco de dados
│   ├── Models/
│   │   └── Livro.cs            # Modelo da entidade Livro e operações CRUD
│   └── Program.cs              # Programa principal com menu de opções
├── CSharpCrud.csproj           # Arquivo de projeto .NET
├── README.md                   # Este arquivo
├── BdComum.cs                  # (arquivo antigo - pode ser removido)
├── Livro.cs                    # (arquivo antigo - pode ser removido)
└── program.cs                  # (arquivo antigo - pode ser removido)
```

## 🎯 Funcionalidades

O sistema oferece as seguintes funcionalidades através de um menu interativo:

1. **Listar todos os livros** - Exibe todos os livros cadastrados
2. **Buscar livro por título** - Permite buscar livros pelo título (busca parcial)
3. **Inserir novo livro** - Cadastra um novo livro no sistema
4. **Alterar livro existente** - Permite editar os dados de um livro
5. **Excluir livro** - Remove um livro do sistema (com confirmação)
6. **Relatório: quantidade total de livros** - Mostra o total de livros cadastrados
7. **Relatório: livros por ano** - Lista livros publicados após um ano específico

## 🔧 Resolução de Problemas

### Erro de Conexão com o Banco
- Verifique se o MySQL está rodando
- Confirme as credenciais de conexão no arquivo `BdComum.cs`
- Certifique-se de que o banco `aulas` existe

### Erro de Dependências
```bash
dotnet restore
```

### Recompilar o Projeto
```bash
dotnet clean
dotnet build
```

## 🆕 Melhorias Implementadas

- **Organização em namespaces**: Código organizado com namespaces apropriados
- **Estrutura de pastas**: Separação clara entre Data, Models e Program
- **Arquivo de projeto .NET**: Configuração adequada com dependências
- **Documentação**: README completo com instruções de uso

## 📝 Notas

- Este projeto foi desenvolvido como exemplo educativo para demonstrar operações CRUD básicas
- As validações implementadas são básicas e podem ser expandidas conforme necessário
- A interface é textual/console para simplicidade do exemplo

## 🤝 Contribuição

Sinta-se à vontade para contribuir com melhorias no código, documentação ou novas funcionalidades!
