using System.Data.SqlClient;
using server.Accessors.IAccessors;
using server.Models;

namespace server.Accessors
{
    public class CandidateAccessor : ICandidateAccessor
    {
        public string GetGetterSqlString(string data)
        {
            return "use VotingSystemDB; SELECT " + data + " FROM Candidates WHERE CandidateId = @id;";
        }

        public string GetSetterSqlString(string data)
        {
            return "use VotingSystemDB; UPDATE Candidates SET " + data + " = @new_value WHERE Candidate = @id;";
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

        public List<CandidateDto> GetCandidatesByOffice(int officeId)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT CandidateId, OfficeId, FirstName, LastName, PartyAffiliation, Biography, DisplayOrder FROM Candidates WHERE OfficeId = @officeId ORDER BY DisplayOrder;";
            List<CandidateDto> candidates = new List<CandidateDto>();
            
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@officeId", System.Data.SqlDbType.Int);
                cmd.Parameters["@officeId"].Value = officeId;
                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            candidates.Add(new CandidateDto
                            {
                                CandidateId = reader.GetInt32(0),
                                OfficeId = reader.GetInt32(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                PartyAffiliation = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Biography = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                DisplayOrder = reader.GetInt32(6)
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
            return candidates;
        }
    }
}
