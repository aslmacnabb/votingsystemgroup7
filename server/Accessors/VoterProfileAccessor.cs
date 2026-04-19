using server.IAccessors;

namespace server.Accessors
{
    public class VoterProfileAccessor : IVoterProfileAccessor
    {
        public int GetInt(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM VoterProfile WHERE VoterId = @id;";
            return GenericAccessor.GetInt(id, sql);
        }

        public string GetString(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM VoterProfile WHERE VoterId = @id;";
            return GenericAccessor.GetString(id, sql);
        }

        public DateTime GetDateTime(int id, string data)
        {
            string sql = "use VotingSystemDB; SELECT " + data + " FROM VoterProfile WHERE VoterId = @id;";
            return GenericAccessor.GetDateTime(id, sql);
        }

        public int GetUserId(int VoterId) {
            return GetInt(VoterId, "UserId");
        }

        public string GetFirstName(int id)
        {
            return GetString(id, "FirstName");
        }

        public string GetLastName(int id)
        {
            return GetString(id, "LastName");
        }

        public DateTime GetDateOfBirth(int id)
        {
            return GetDateTime(id, "DateOfBirth");
        }

        public string GetStreetAddress(int id)
        {
            return GetString(id, "StreetAddress");
        }

        public string GetCity(int id)
        {
            return GetString(id, "City");
        }

        public string GetState(int id)
        {
            return GetString(id, "State");
        }

        public string GetZipCode(int id)
        {
            return GetString(id, "ZipCode");
        }

        public int GetPrecinctId(int id)
        {
            return GetInt(id, "PrecinctId");
        }

        public bool GetIsRegistered(int id)
        {
            int IsRegistered = GetInt(id, "IsRegistered");
            if (IsRegistered == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public DateTime GetRegistrationDate(int id)
        {
            return GetDateTime(id, "RegistrationDate");
        }
    }
}