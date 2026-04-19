namespace server.IAccessors
{
    public interface IVoterProfileAccessor
    {
        /*
        It's important to note that, unless specified otherwise, `id`
        refers to the primary key VoterId from the VoterProfile table
        in the database.
        */

        /*
        Returns an int from the database based on specified parameters.
        */
        public int GetInt(int id, string data);

        /*
        Returns a string from the database based on specified parameters.
        */
        public string GetString(int id, string data);

        /*
        Returns a DateTime object from the database based on specified
        parameters.
        */
        public DateTime GetDateTime(int id, string data);

        /*
        Returns UserId based on the associated VoterId.
        */
        public int GetUserId(int VoterId);

        /*
        Returns a FirstName from the associated `id`.
        */
        public string GetFirstName(int id);

        /*
        Returns a LastName from the associated `id`.
        */
        public string GetLastName(int id);

        /*
        Returns the DateOfBirth from the associated `id`.
        */
        public DateTime GetDateOfBirth(int id);

        /*
        Returns the StreetAddress from the associated `id`.
        */
        public string GetStreetAddress(int id);

        /*
        Returns the City from the associated `id`.
        */
        public string GetCity(int id);

        /*
        Returns the State from the associated `id`.
        */
        public string GetState(int id);

        /*
        Returns the ZipCode from the associated `id`.
        */
        public string GetZipCode(int id);

        /*
        Returns the PrecinctId from the associated `id`.
        */
        public int GetPrecinctId(int id);

        /*
        Returns whether the account associated with `id` is registered
        to vote.
        */
        public bool GetIsRegistered(int id);

        /*
        Returns the RegistrationDate associated with `id`.
        */
        public DateTime GetRegistrationDate(int id);
    }
}