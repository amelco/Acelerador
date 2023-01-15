# Acelerador

Código para facilitar (acelerar) a criação de API's REST utilizando dotnet core 6. 

Possui apenas um projeto contendo todas as camadas (Aplicação/Infraestrutura/Domínio).
O motivo pra essa escolha foi a simplicidade.
Entretanto, caso se queria criar projetos separados, a modificação é simples pois tudo está modularizado.

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

## TODO

- Testes
- Automapper
- Autenticação / Autorização
