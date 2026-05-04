using System.Data.SqlClient;
using server.Accessors.IAccessors;
using server.Models;

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

        public List<MeasureDto> GetMeasuresByElection(int electionId)
        {
            SqlConnection conn = GenericAccessor.GetConnection();
            string sql = "use VotingSystemDB; SELECT MeasureId, ElectionId, MeasureTitle, MeasureText, YesDescription, NoDescription, DisplayOrder FROM Measures WHERE ElectionId = @electionId ORDER BY DisplayOrder;";
            List<MeasureDto> measures = new List<MeasureDto>();

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
                            measures.Add(new MeasureDto
                            {
                                MeasureId = reader.GetInt32(0),
                                ElectionId = reader.GetInt32(1),
                                MeasureTitle = reader.GetString(2),
                                MeasureText = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                YesDescription = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                NoDescription = reader.IsDBNull(5) ? "" : reader.GetString(5),
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
            return measures;
        }
    }
}
