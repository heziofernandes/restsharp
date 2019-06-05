using System;
using TestProject;
using TestProject.Service;
using Xunit;

namespace XUnitTestProject
{
    public class TestClientRegister
    {
        [Fact]
        public void TestRegisterWithSucess()
        {
            var client = new Client
            {
                Code = 1,
                FullName = "Ryan Fernandes",
                Address = "Street roud main 123"
            };
            var service = new ClientService();
            var registedCode = service.Register(client);
            Assert.Equal(1, registedCode);
        }

        [Fact]
        public void TestRegisterWithOnlyFirstName()
        {
            var client = new Client
            {
                Code = 1,
                FullName = "Ryan",
                Address = "Street roud main 123"
            };
            var service = new ClientService();
            var clientException = Assert.Throws<Exception>(() => service.Register(client));
            Assert.Equal(clientException.Message,"Should be inform complet Name");
        }
        [Fact]
        public void TestRegisterWithNameEmpty()
        {
            var client = new Client
            {
                Code = 1,
                FullName = "",
                Address = "Street roud main 123"
            };
            var service = new ClientService();
            var clientException = Assert.Throws<Exception>(() => service.Register(client));
            Assert.Equal(clientException.Message, "The Name should be informed");
        }
    }
}
