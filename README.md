
# AspNet API - Teste Técnico - Viceri




## Documentação da API

#### Cadastra um novo usuario

```http
  POST /api/User
```

| Parâmetro   | Tipo       | Descrição
| :---------- | :--------- | :---------
| `{"nome": string, "email" : string, "senha": string, "cpf": string, datanasc: string }` | `json ` | `Todos são obrigatorios. Envie apenas numeros(11 caracteres) no CPF`

```json
Retornos:
Code:
  200: 
  {
    "statusCode": 200, //Usuario cadastrado
    "message": null, //Null string
    "result": 
      {
        "id": 0,
        "nome": "string",
        "email": "string",
        "senha": "string",
        "cpf": "string",
        "datanasc": "string",
      }
  }
  400: // Erro ao cadastrar
  {
    "statusCode": 405, //Cadastro não foi permitido
    "message": "string", //Mensagem com o motivo - (Somente numeros no CPF | CPF Inválido | CPF Em uso | Email Em uso | Email inválido)
  }
 ```

 #### Retorna a lista com todos os usuarios

```http
  GET /api/User
```
 ```json
Retornos:
Code:
  200: 
  {
    "statusCode": 200, //Sucesso
    "message": null, //Null string
    "result":
    [
        {
          "id": 0,
          "nome": "string",
          "email": "string",
          "senha": "string",
          "cpf": "string",
          "datanasc": "string",
        },
    ] 
  }
  404: // Nenhum usuario encontrado
  {
    "statusCode": 404, // Nenhum usuario encontrado
    "message": "string", //Mensagem com o motivo (Nenhum usuario encontrado)
  }
 ```

  #### Retorna um usuario pelo ID

```http
  GET /api/User
```
| Parâmetro   | Tipo       | Descrição
| :---------- | :--------- | :---------
|  `id` | `int` | `Obrigatorio`

 ```json
Retorno:
Code:
  200: 
  {
    "statusCode": 200, //Sucesso
    "message": null, //Null string
    "result":
        {
          "id": 0,
          "nome": "string",
          "email": "string",
          "senha": "string",
          "cpf": "string",
          "datanasc": "string",
        }
  }
  404: // Usuario não encontrado
  {
    "statusCode": 404, // Usuario não encontrado
    "message": "string", //Mensagem com o motivo (Usuario não encontrado)
  }
 ```

   #### Editar um usuario pelo ID

```http
  PUT /api/User/Edit
```
| Parâmetro   | Tipo       | Descrição
| :---------- | :--------- | :---------
|  `id` | `int` | `Id do usuario`
| `{"nome": string, "email" : string, "senha": string, "cpf": string, datanasc: string }`| `json`| `Não são todos obrigatorios, somente os dados que serão alterados`

 ```json
Retorno:
Code:
  200: 
  {
    "statusCode": 200, //Sucesso
    "message": null, //Null string
    "result":
        {
          "id": 0,
          "nome": "string",
          "email": "string",
          "senha": "string",
          "cpf": "string",
          "datanasc": "string",
        }
  }
  404: // Usuario não encontrado
  {
    "statusCode": 404, // Usuario não encontrado
    "message": "string", //Mensagem com o motivo (Usuario não encontrado)
  }
 ```

    #### Editar um usuario pelo ID

```http
  PUT /api/User/Delete
```
| Parâmetro   | Tipo       | Descrição
| :---------- | :--------- | :---------
|  `id` | `int` | `Id do usuario`

 ```json
Retorno:
Code:
  200: 
  {
    "statusCode": 200, //Sucesso
    "message": "string", //Mensagem de sucesso (Usuario Deletado)
  }
  404: // Usuario não encontrado
  {
    "statusCode": 404, // Usuario não encontrado
    "message": "string", //Mensagem com o motivo (Usuario não encontrado)
  }
 ```