namespace server.Managers.IManagers
{
    public interface IAdminManager
    {
        /*
        Adds an election named `title` to the database.
        */
        public string AddElection(string username, string password, string title);

        /*
        Adds a measure (option) to an election. Must be admin to perform this.
        */
        public void AddMeasure(string username, string password, string election_name, string measure_title);

        /*
        Assigns every user a ballot corresponding to the Election `election_name`.
        */
        public void AddBallots(string username, string password, string election_name);
    }
}
