using server.IAccessors;

namespace server.Accessors
{
    public class MeasureAccessor : IMeasureAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Measures WHERE MeasureId = @id;";
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
    }
}
