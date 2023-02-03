using Wisse.Common.Domain.Primitives;
using Wisse.Modules.Users.Domain.Constants;
using Wisse.Modules.Users.Domain.Exceptions.ValueObjects.Student.LanguageLevel;

namespace Wisse.Modules.Users.Domain.ValueObjects.Student;

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