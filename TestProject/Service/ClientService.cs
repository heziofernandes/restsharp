using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Reporsitory;
using TestProject.Validation;

namespace TestProject.Service
{
    public class ClientService
    {
        public int Register(Client client)
        {
            var repository = new ClientRepository();
            var validation = new ClientValidation();

            validation.Register(client);
            return  repository.Register(client);
        }
    }
}
