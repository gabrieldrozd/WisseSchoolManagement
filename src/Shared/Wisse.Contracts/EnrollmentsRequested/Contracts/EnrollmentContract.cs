namespace Wisse.Contracts.EnrollmentsRequested.Contracts;

public class EnrollmentContract
{
    public Guid ExternalId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string EnrollmentStatus { get; set; }
}