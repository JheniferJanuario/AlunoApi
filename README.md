# API de Gerenciamento de Alunos

Este projeto consiste em uma API desenvolvida em **ASP.NET Core Web API** para realizar o gerenciamento de alunos.  
A aplicação foi construída utilizando o padrão **Arquitetura Hexagonal (Ports and Adapters)**, com o objetivo de manter a lógica de negócio separada das tecnologias externas.



# Objetivo do Projeto

O objetivo do projeto é demonstrar a organização de um sistema utilizando **camadas bem definidas**, onde a regra de negócio não depende diretamente de banco de dados, interface ou frameworks.

A aplicação permite:

- Matricular alunos
- Listar alunos cadastrados
- Buscar aluno pelo nome



# Estrutura do Projeto

O projeto foi dividido em quatro camadas principais para separar responsabilidades.

## Domain

A camada **Domain** representa o núcleo da aplicação.

Ela contém:

- A entidade **Aluno**
- A interface **IAlunoRepository**

Essa camada define **o que o sistema precisa**, mas não como será implementado.

A camada Domain **não depende de nenhuma outra camada do projeto**, garantindo que a lógica principal do sistema permaneça isolada.



## Application

A camada **Application** contém a lógica de negócio da aplicação.

Nela está a classe:

- **AlunoService**

Essa classe é responsável por:

- Aplicar as regras de negócio
- Validar os dados antes de salvar
- Utilizar a interface do repositório para acessar os dados



## Infrastructure

A camada **Infrastructure** contém a implementação concreta do repositório.

Aqui está a classe:

- **AlunoRepository**

Nesse projeto foi utilizada **uma lista em memória** para armazenar os alunos, simulando um banco de dados.

Essa classe implementa a interface **IAlunoRepository**, que foi definida na camada Domain.



## API

A camada **API** é responsável por expor os endpoints da aplicação.

Ela contém:

- Controllers
- Configuração da Injeção de Dependência
- Configuração do Swagger

O controller recebe as requisições e chama o **AlunoService**, que aplica as regras de negócio.



# Regras de Negócio

As regras foram implementadas manualmente no método **Matricular** da classe `AlunoService`.

As validações realizadas são:

### Presença

O campo **FirstName** não pode ser nulo ou vazio.

### Extensão

O **FirstName** deve ter no máximo **50 caracteres**.

### Domínio do Email

O email deve obrigatoriamente terminar com:

```
@faculdade.edu
```

### Unicidade do Email

Antes de salvar um novo aluno, o sistema verifica no repositório se já existe um aluno com o mesmo email.

Caso exista, o cadastro não é permitido.



# Fluxo de Funcionamento

O fluxo da aplicação segue o padrão da Arquitetura Hexagonal:

## Endpoints da API

### Matricular aluno

Endpoint:

```
POST /api/aluno
```

Exemplo de requisição:

```json
{
  "firstName": "Maria",
  "email": "maria@faculdade.edu"
}
```

---

### Listar alunos

Endpoint:

```
GET /api/aluno
```

Retorna todos os alunos cadastrados.

---

### Buscar aluno por nome

Endpoint:

```
GET /api/aluno/nome/{nome}
```

Exemplo:

```
GET /api/aluno/nome/maria
```

Se não existir aluno com esse nome, o sistema retorna:

```
Aluno não está matriculado
```



# Tecnologias Utilizadas

- .NET
- ASP.NET Core Web API
- Swagger
- Git
- GitHub

---

# Padrões Utilizados

- Arquitetura Hexagonal (Ports and Adapters)
- Injeção de Dependência
