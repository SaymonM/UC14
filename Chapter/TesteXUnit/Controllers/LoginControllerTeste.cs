using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteXUnit.Controllers
{
    public class LoginControllerTeste
    {

        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            //Arrange
            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadosLogin = new LoginViewModel();

            dadosLogin.Email = "teste@teste.com.br";
            dadosLogin.Senha = "senha123";

            var controller = LoginController(fakeRepository.Object);


            //Act
            var resultado = controller.Login(dadosLogin);


            //Assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void LoginController_RetornarToken()
        {
            //Arrange
            Usuario usuarioRetorno = new Usuario();
            usuarioRetorno.Email = "teste@teste.com.br";
            usuarioRetorno.Senha = "senha123";

            var fakeRepository = new Mock<IUsuarioRepository>();
            fakeRepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((usuarioRetorno)null);

            string issuerValidacao = "chapter.webapi";

            LoginViewModel dadosLogin = new LoginViewModel();
            dadosLogin.Email = "teste@teste.com.br";
            dadosLogin.Senha = "senha123";

            var controller = LoginController(fakeRepository.Object);

            //Act

        }

    }
}
