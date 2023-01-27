using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Enrollments.Domain.Constants;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant;
using Wisse.Modules.Enrollments.Domain.Exceptions.ValueObjects.Applicant.LanguageLevel;

namespace Wisse.Modules.Enrollments.Domain.ValueObjects.Applicant;

public class LanguageLevel : ValueObject
{
    public string Key { get; }
    public string Name { get; }

    public LanguageLevel(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyLanguageLevelException();
        }

        var level = Level.TryGetLevel(value);
        if (level is null)
        {
            throw new InvalidLanguageLevelException();
        }

        Key = level.Key;
        Name = level.Name;
    }

    public static LanguageLevel Create(Level level)
        => new(level.Key);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Key;
        yield return Name;
    }
}