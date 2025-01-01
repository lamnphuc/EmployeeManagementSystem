namespace TL
{
    public class Logintranfer
    {
        public Logintranfer(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string username { get; set; }
        public string password { get; set; }
    }
}
