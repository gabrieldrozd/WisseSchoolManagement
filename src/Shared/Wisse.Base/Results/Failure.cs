using Wisse.Base.Types;

namespace Wisse.Base.Results;

public class Failure : ErrorEnumeration<Failure>
{
    public static readonly Failure DatabaseFailure = new DatabaseFail();

    private Failure(string code, string message) : base(code, message)
    {
    }

    private sealed class DatabaseFail : Failure
    {
        public DatabaseFail() : base("DatabaseFailure", "Database failed to process changes.")
        {
        }
    }
}
