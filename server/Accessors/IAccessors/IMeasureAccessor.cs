namespace server.Accessors.IAccessors
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
        Adds a measure to the database, with name `measure_title` and
        associated with Election `electionid`.
        */
        public void AddMeasure(int electionid, string measure_title);
    }
}
