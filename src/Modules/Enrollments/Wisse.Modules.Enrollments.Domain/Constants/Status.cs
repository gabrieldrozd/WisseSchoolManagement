using Wisse.Base.Types;

namespace Wisse.Modules.Enrollments.Domain.Constants;

public class Status : Enumeration<Status>
{
    public static readonly Status Pending = new PendingStatus();
    public static readonly Status Approved = new ApprovedStatus();
    public static readonly Status Rejected = new RejectedStatus();

    private Status(int value, string name)
        : base(value, name)
    {
    }

    public static bool IsValid(string value)
    {
        return value == Pending.Name ||
               value == Approved.Name ||
               value == Rejected.Name;
    }

    private sealed class PendingStatus : Status
    {
        public PendingStatus()
            : base(1, "Pending")
        {
        }
    }

    private sealed class ApprovedStatus : Status
    {
        public ApprovedStatus()
            : base(2, "Approved")
        {
        }
    }

    private sealed class RejectedStatus : Status
    {
        public RejectedStatus()
            : base(3, "Rejected")
        {
        }
    }
}