# Acelerador

Código para facilitar (acelerar) a criação de API's REST utilizando dotnet core 6. 
Possui apenas um projeto contendo todas as camadas (Aplicação/Infraestrutura/Domínio).

---

## Importante

A maior motivação de se criar esse repositório foi pra estudar e aplicar meus conhecimentos em dotnet.
Estou tentando fazer tudo com implementações próprias com a única finalidade de aprender e me divertir enquanto isso.
Nada aqui é pensado, em primeiro lugar, na eficiência ou numa "boa arquitetura", seja lá o que isso seja.

---

## Features

### Banco SQL

O acelerador está preparado para bancos de dados SQL. Basta criar um novo DbContext implementnado o SqlDbContext.
Nesse exemplo, o DbContext utiliza o SQLite.

**OBSERVAÇÃO**  
Não utilize o SQLite em produção. Ele aqui está somente como em exemplo para se criar o seu próprio context
utilizando SQL Server, Postgres ou MySQL.

### CRUD genérico

Para agilizar a criação de CRUDS, uma Application genérica foi criada com os principais métodos.

### Validação de entidades

Implementação própria.

## TODO

- Testes
- Automapper
- Autenticação / Autorização
