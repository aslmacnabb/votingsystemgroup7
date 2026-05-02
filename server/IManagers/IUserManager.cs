namespace server.IManagers
{
    public interface IUserManager
    {
        /*
        Returns true if the passed username and password are valid.
        */
        public bool Authenticate(string username, string password);

        /*
        Returns the user's account type as a string: voter or admin.
        */
        public string GetAccountType(string username, string password);
    }
}
