using System;
using System.Collections.Generic;

namespace server.IAccessors
{
    public interface IMeasureAccessor
    {
        /*
        It's important to note that, unless specified otherwise, `id`
        refers to the primary key MeasureId from the Measures table
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
        Sets an int belonging to `id` to `new_value` on field `data`
        */
        public void SetInt(int id, string data, int new_value);

        /*
        Sets a string belonging to `id` to `new_value` on field `data.
        */
        public void SetString(int id, string sql, string new_value);

        /*
        Returns all measures assigned to a given election
        */
        public List<Dictionary<string, object>> GetMeasuresForElection(int electionId);

        /*
        Inserts a new measure for the given election
        */
        public void InsertMeasure(int electionId, string title, string text, string yesDesc, string noDesc);

        /*
        Returns all measures visible on a ballot
        */
        public List<Dictionary<string, object>> GetMeasuresForBallot(int ballotId);

        /*
        Inserts a new measure for the election attached to the ballot
        */
        public void InsertMeasureForBallot(int ballotId, string title, string text, string yesDesc, string noDesc);
    }
}
