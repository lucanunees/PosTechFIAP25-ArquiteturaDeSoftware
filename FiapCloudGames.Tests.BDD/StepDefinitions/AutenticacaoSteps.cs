using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapCloudGames.Tests.BDD.StepDefinitions
{
    [Binding]
    public class AutenticacaoSteps
    {
        public AutenticacaoSteps() { }


        [Given(@"O que existe um usuário cadastrado com email ""(.*)"" e senha ""(.*)""")]
        public async Task GivenUsuarioCadastrado(string email, string senha)
        {
            var registro = new { Email = email, Password = senha };
            await _client.PostAsJsonAsync("/authenticate/registrar", registro);
        }


        [When(@"eu tento realizar o login com as mesmas credenciais")]
        public async Task WhenTentoRealizarLogin(Table table)
        {
            // O Reqnroll permite pegar dados de tabelas ou parâmetros de texto
            _loginRequest = new { Email = "joao@teste.com", Password = "Senha@123" };
            _response = _client.PostAsJsonAsync("/authenticate/login", _loginRequest);
        }

        [Then(@"o sistema deve retornar o status code (.*)")]
        public void ThenRetornarStatusCode(int statusCode)
        {
            ((int)_response.StatusCode.Should().Be(statusCode);
        }




    }
}
