using System;

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
        Returns the ballot cast date from Ballots.CastAt, or null when it
        has not been cast yet
        */
        public DateTime? GetBallotDate(int ballotId);

        /*
        Sets the ballot cast date in Ballots.CastAt for the specified ballot
        This is the date/time the voter actually submitted the ballot
        */
        public void SetBallotDate(int ballotId, DateTime date);

        /*
        Returns the voting session start time for this ballot.
        Ballot level start/end dates are easier to control than election level dates.
        */
        public DateTime? GetBallotStartDate(int ballotId);

        /*
        Sets the ballot voting session start time for the specified ballot
        */
        public void SetBallotStartDate(int ballotId, DateTime date);

        /*
        Returns the voting session end time for this ballot
        */
        public DateTime? GetBallotEndDate(int ballotId);

        /*
        Sets the ballot voting session end time for the specified ballot
        */
        public void SetBallotEndDate(int ballotId, DateTime date);

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
    }
}
