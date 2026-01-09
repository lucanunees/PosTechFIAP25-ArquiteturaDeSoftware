# language: pt
Funcionalidade: Cadastro de Usuário na FiapCloudGames

Cenário: Cadastro realizado com sucesso
Dado que eu informo dados de cadastro válidos:
      | Nome         | Email              | Senha      |
      | "João Costa" | "joao@fiap.com.br" | "Senha@123" |
Quando eu solicito o registro do novo usuário
Então o sistema deve confirmar a criação com sucesso
E o usuário "joao@fiap.com.br" deve conseguir se autenticar na plataforma
