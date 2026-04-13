class Admin : User
{
    private string EmployeeID;
    private string PositionTitle;
    private string PermissionsLevel;

    public Admin(string username, string password, string email, string employeeID, string positionTitle, string permissionsLevel)
        : base(username, password, email)
    {
        EmployeeID = employeeID;
        PositionTitle = positionTitle;
        PermissionsLevel = permissionsLevel;
    }
}