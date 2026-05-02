namespace server.IAccessors
{
    public interface IBallotManager
    {
        /*
        Sets the measure decision for the ballot of `election_name` associated
        with `username`. For instance, one could use this to set `username`'s
        ballot for the "2026 Mayoral Election" to "Gordan Freeman".
        */
        public void SetMeasureDecision(string username, string password, string election_name, string new_value);

        /*
        Gets the submission date associated with `username`'s `election_name` ballot.
        */
        public DateTime GetBallotDate(string username, string password, string election_name);

        /*
        Sets the submission date associated with `username`'s `election_name` ballot.
        */
        public void SetBallotDate(string username, string password, string election_name, DateTime new_value);

        /*
        Gets the title of the measure associated with `username`'s `election_name` ballot.
        */
        public string GetMeasureFromBallot(string username, string password, string election_name);
    }
}
