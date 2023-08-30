using System;

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
