# Acelerador

C�digo para facilitar (acelerar) a cria��o de API's REST utilizando dotnet core 6. 

Possui apenas um projeto contendo todas as camadas (Aplica��o/Infraestrutura/Dom�nio).
O motivo pra essa escolha foi a simplicidade.
Entretanto, caso se queria criar projetos separados, a modifica��o � simples pois tudo est� modularizado.

---

## Features

### Banco SQL

O acelerador est� preparado para bancos de dados SQL. Basta criar um novo DbContext implementnado o SqlDbContext.
Nesse exemplo, o DbContext utiliza o SQLite.

**OBSERVA��O**  
N�o utilize o SQLite em produ��o. Ele aqui est� somente como em exemplo para se criar o seu pr�prio context
utilizando SQL Server, Postgres ou MySQL.

### CRUD gen�rico

Para agilizar a cria��o de CRUDS, uma Application gen�rica foi criada com os principais m�todos.

## TODO

- Testes
- Logging
- Automapper
- Tratanento de erros / mensagens de erros
- Autentica��o / Autoriza��o
