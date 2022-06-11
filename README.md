
# Web API - Teste Técnico - Viceri




## Documentação da API

#### Cadastra um novo usuario

```http
  POST /api/User
```

| Json   | Tipo       | Descrição
| :---------- | :--------- | :---------
| `{"nome": string, "email" : string, "senha": string, "cpf": string, datanasc: string }` | `json ` | `*Todos são obrigatorios*. Envie somente numeros no CPF`

```json
Retornos:
Code:
  200: 
  {
    "statusCode": 200, //Usuario cadastrado
    "message": null, //Null string
    "result": {
      {
        "id": 0,
        "nome": "string",
        "email": "string",
        "senha": "string",
        "cpf": "string",
        "datanasc": "string",
      }
    }
  }
  400: // Erro ao cadastrar
  {
    "statusCode": 405, //Cadastro não foi permitido
    "message": "string", //Mensagem com o motivo - (Somente numeros no CPF | CPF Em uso | Email Em uso)
  }
 ```