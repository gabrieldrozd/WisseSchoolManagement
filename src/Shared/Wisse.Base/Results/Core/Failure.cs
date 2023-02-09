using Wisse.Base.Types;

namespace Wisse.Base.Results.Core;

public class Failure : ErrorEnumeration<Failure>
{
    public static readonly Failure Database = new DatabaseFail();
    public static readonly Failure Mediator = new MediatorFail();
    public static readonly Failure EmailInUse = new EmailInUseFail();

    private Failure(string code, string message) : base(code, message)
    {
    }

    private sealed class DatabaseFail : Failure
    {
        public DatabaseFail() : base("DatabaseFailure", "Database failed to process changes.")
        {
        }
    }

    private sealed class MediatorFail : Failure
    {
        public MediatorFail() : base("MediatorFailure", "Mediator failed to process request.")
        {
        }
    }

    private sealed class EmailInUseFail : Failure
    {
        public EmailInUseFail() : base("EmailInUseFailure", "Email is already in use.")
        {
        }
    }
}
