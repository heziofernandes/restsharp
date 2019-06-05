using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Reporsitory
{
    public class ClientRepository
    {
        public int Register(Client client)
        {
            return client.Code;
        }
    }
}
