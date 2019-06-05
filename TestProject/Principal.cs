using System;
using TestProject.Service;

namespace TestProject
{
    public class Principal
    {
        public void RegisterClient()
        {
            var client = new Client
            {
                Code = 1,
                FullName = "Ryan Fernandes",
                Address = "Street roud main 123"
            };
            var service = new ClientService();
            service.Register(client);
        }
    }
}
