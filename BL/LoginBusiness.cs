using DL;

namespace BL
{
    public class LoginBusiness
    {
        private readonly LoginData _loginData;

        public LoginBusiness()
        {
            _loginData = new LoginData();
        }

        public (bool isSuccess, string employeeName, string message) Login(string username, string password)
        {
            return _loginData.VerifyCredentials(username, password);
        }
    }
}