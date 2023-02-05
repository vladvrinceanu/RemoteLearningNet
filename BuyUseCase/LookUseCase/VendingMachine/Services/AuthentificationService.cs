using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TestProject")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine.Services
{
    internal class AuthentificationService : IAuthentificationService
    {
        public bool UserIsLoggedIn { get; private set; }
        public void Login(string password)
        {
            if (password == "vlad")
                UserIsLoggedIn = true;
            else
                throw new Exception("Invalid password");
        }
        public void Logout()
        {
            UserIsLoggedIn = false;
        }
    }
}
