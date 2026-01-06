# language: pt
Funcionalidade: Autenticação de Usuário

Cenário: Login realizado com sucesso
Dado que existe um usuário com o email "tal" e a senha "tal"
Quando eu tento realizar o login com as mesmas credenciais
Então o sistema deve retornar o status code 200
E o corpo da resposta deve conter um "Token" JWT