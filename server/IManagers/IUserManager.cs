namespace server.IManagers
{
    public interface IUserManager
    {
        /**
        * Authenticates the User and returns its type (voter or admin).
        */
        public static abstract string GetUserType(string username, string password);
    }
}