using server.IAccessors;

namespace server.Accessors
{
    public class MeasureAccessor : IMeasureAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Measures WHERE MeasureId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Measures SET " + data + " = @new_value WHERE MeasureId = @id;";
        }

        public int GetInt(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetInt(id, sql);
        }

        public string GetString(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetString(id, sql);
        }

        public void SetInt(int id, string data, int new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetInt(id, sql, new_value);
        }

        public void SetString(int id, string data, string new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetString(id, sql, new_value);
        }

        public void AddMeasure(int electionid, string measure_title)
        {
            string sql = "use VotingSystemDB; insert into Measures (ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription, DisplayOrder) values (@id, @new_value, '', '', '', 1);";
            GenericAccessor.SetString(electionid, sql, measure_title);
        }
    }
}
