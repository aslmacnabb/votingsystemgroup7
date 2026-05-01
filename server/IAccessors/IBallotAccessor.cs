namespace server.IAccessors
{
    public interface IBallotAccessor
    {
        /*
        It's important to note that, unless specified otherwise, `id`
        refers to the primary key BallotId from the Ballots table
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
        Sets the measure decision for `id` to 'new_value'.
        */
        public void SetMeasureDecision(int id, string new_value);

        /*
        Gets the submission date associated with `id`.
        */
        public DateTime GetBallotDate(int id);

        /*
        Sets the submission date of `id` to `new_value`.
        */
        public void SetBallotDate(int id, DateTime new_value);
    }
}
