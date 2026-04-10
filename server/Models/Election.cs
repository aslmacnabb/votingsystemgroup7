using System.Runtime.CompilerServices;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class Election
{
    private string ElectionName;
    private string Description;
    private DateTime StartDate;
    private DateTime EndDate;
    private Boolean IsPublished;

    public Election(string electionName, string description, DateTime startDate, DateTime endDate)
    {
        ElectionName = electionName;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        IsPublished = false;
    }
}