using Core.Entity;
using Core.Input;
using Core.Repository;
using FiapCloudGames.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Reqnroll;

namespace FiapCloudGames.Tests.BDD.StepDefinitions
{
    [Binding]
    public class AcessUserSteps
    {
        private readonly Mock<IAcessUserRepository> _repository;
        private readonly AcessUserController _controller;
        private AcessUserInput _input;
        private IActionResult _result;

        public AcessUserSteps()
        {
            _repository = new Mock<IAcessUserRepository>();
            _repository.Setup(x => x.Create(It.IsAny<AcessUser>()));
            _controller = new AcessUserController(_repository.Object);
        }



        [Given(@"que o usuário preencheu o formulário de cadastro inserido corretamento sue nome, email e senha")]
        public void GivenUsuarioPreencheuFormulario(Table table)
        {
            var row = table.Rows[0];
            _input = new AcessUserInput
            {
                Username = row["Nome"],
                Email = row["Email"],
                Password = row["Senha"]
            };
        }

        [When(@"acessou pela primeira vez a plataforma FiapCloudGames")]
        public void WhenAcessouPlataforma()
        {
            _result = _controller.Post(_input);
        }

        [Then(@"foi criado um usuário na plataforma com as suas credenciais")]
        public void ThenUsuarioCriado()
        {
            _result.Should().BeOfType<CreatedAtActionResult>();

            _repository.Verify(r => r.Create(It.Is<AcessUser>(u =>
                u.Email == _input.Email &&
                u.Username == _input.Username
            )), Times.Once);
        }

    }
}
