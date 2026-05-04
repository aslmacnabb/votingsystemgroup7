using System.Data.SqlClient;
using server.Accessors.IAccessors;
using server.Models;

namespace server.Accessors
{
    public class OfficeAccessor : IOfficeAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Offices WHERE OfficeId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Offices SET " + data + " = @new_value WHERE OfficeId = @id;";
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

        public List<OfficeDto> GetOfficesByElection(int electionId)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT OfficeId, ElectionId, OfficeTitle, Description, SeatsAvailable, DisplayOrder FROM Offices WHERE ElectionId = @electionId ORDER BY DisplayOrder;";
            List<OfficeDto> offices = new List<OfficeDto>();
            CandidateAccessor ca = new CandidateAccessor();

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@electionId", System.Data.SqlDbType.Int);
                cmd.Parameters["@electionId"].Value = electionId;
                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int officeId = reader.GetInt32(0);
                            offices.Add(new OfficeDto
                            {
                                OfficeId = officeId,
                                ElectionId = reader.GetInt32(1),
                                OfficeTitle = reader.GetString(2),
                                Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                SeatsAvailable = reader.GetInt32(4),
                                DisplayOrder = reader.GetInt32(5),
                                Candidates = ca.GetCandidatesByOffice(officeId)
                            });
                        }
                    }
                }
                catch (SqlException sx)
                {
                    Console.WriteLine(sx);
                }
                cmd.Connection.Close();
            }
            return offices;
        }
    }
}
