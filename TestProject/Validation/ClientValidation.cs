using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Validation
{
    public class ClientValidation
    {
        public void Register(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.FullName))
            {
                throw new Exception("The Name should be informed");
            }
            if(client.FullName.Split(' ').Length<= 1)
            {
                throw new Exception("Should be inform complet Name");
            }
        }
    }
}
