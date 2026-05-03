namespace server.Accessors.IAccessors
{
    public interface IVoterProfileAccessor
    {
        /*
        It's important to note that, unless specified otherwise, `id`
        refers to the primary key VoterId from the VoterProfile table
        in the database.
        */

        /*
        Returns an SQL query for use by a Getter.
        */
        public string GetGetterSqlString(string data);

        /*
        Returns an SQL query for use by a Setter.
        */
        public string GetSetterSqlString(string data);

        /*
        Returns an int from the database based on specified parameters.
        */
        public int GetInt(int id, string data);

        /*
        Returns a string from the database based on specified parameters.
        */
        public string GetString(int id, string data);

        /*
        Returns a DateTime object from the database based on specified
        parameters.
        */
        public DateTime GetDateTime(int id, string data);

        /*
        Sets an int belonging to `id` to `new_value` on field `data`
        */
        public void SetInt(int id, string data, int new_value);

        /*
        Sets a string belonging to `id` to `new_value` on field `data.
        */
        public void SetString(int id, string sql, string new_value);

        /*
        Sets a DateTime object belonging to `id` to `new_value` on field `data`.
        */
        public void SetDateTime(int id, string sql, DateTime new_value);

        /*
        Gets a voterid from the passed `userid`
        */
        public int GetVoterIdFromUserId(int userid);

        /*
        Returns the number of voters (by voterid)
        */
        public int GetNumberOfVoters();
    }
}
