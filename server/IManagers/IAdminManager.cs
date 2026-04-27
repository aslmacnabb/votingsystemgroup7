namespace server.IManagers
{
    public interface IAdminManager
    {
        /*
        Adds an election named `title` to the database.
        */
        public string AddElection(string username, string password, string title);
    }
}
