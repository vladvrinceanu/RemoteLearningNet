namespace iQuest.VendingMachine.Services
{
    public interface IAuthentificationService
    {
        bool UserIsLoggedIn { get; }
        void Login(string password);
        void Logout();
    }
}