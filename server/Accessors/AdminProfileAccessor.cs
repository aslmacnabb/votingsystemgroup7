using server.Accessors.IAccessors;

namespace server.Accessors
{
    public class AdminProfileAccessor : IAdminProfileAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM AdminProfile WHERE AdminId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE AdminProfile SET " + data + " = @new_value WHERE AdminId = @id;";
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

        public DateTime GetDateTime(int id, string data)
        {
            string sql = GetGetterSqlString(data);
            return GenericAccessor.GetDateTime(id, sql);
        }

        public int GetAdminIdFromUserId(int userid)
        {
            string sql = "use VotingSystemDB; SELECT AdminId FROM AdminProfile WHERE UserId = @id;";
            return GenericAccessor.GetInt(userid, sql);
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

        public void SetDateTime(int id, string data, DateTime new_value)
        {
            string sql = GetSetterSqlString(data);
            GenericAccessor.SetDateTime(id, sql, new_value);
        }

        public void AddElection(int id, string title)
        {
            string sql = "use VotingSystemDB; insert into Elections (AdminId, ElectionName, StartDate, EndDate, IsPublished) values (@id, @new_value, '2026-04-09 08:00:00', '2026-04-30 20:00:00', 1);";
            GenericAccessor.SetString(id, sql, title);
        }
    }
}
