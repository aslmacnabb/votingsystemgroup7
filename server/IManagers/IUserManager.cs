namespace server.IManagers
{
    public interface IUserManager
    {
        /*
        Returns true if the passed username and password are valid.
        */
        public bool Authenticate(string username, string password);
    }
}