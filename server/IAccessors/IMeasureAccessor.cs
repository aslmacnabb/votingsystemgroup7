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
        Returns an int from the database based on specified parameters.
        */
        public int GetInt(int id, string data);

        /*
        Returns a string from the database based on specified parameters.
        */
        public string GetString(int id, string data);
    }
}
