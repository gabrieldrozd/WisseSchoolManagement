using Wisse.Base.Types;

namespace Wisse.Modules.Users.Domain.Constants;

public class Level : PairEnumeration<Level>
{
    public static readonly Level A0 = new BeginnerLevel();
    public static readonly Level A1 = new ElementaryLevel();
    public static readonly Level A2 = new PreIntermediateLevel();
    public static readonly Level B1 = new IntermediateLevel();
    public static readonly Level B2 = new UpperIntermediateLevel();
    public static readonly Level C1 = new AdvancedLevel();
    public static readonly Level C2 = new ProficientLevel();

    private Level(int value, string key, string name)
        : base(value, key, name)
    {
    }

    public static Level TryGetLevel(string value)
    {
        Level level;

        if (FromKey(value) is not null)
        {
            level = FromKey(value);
        }
        else if (FromName(value) is not null)
        {
            level = FromName(value);
        }
        else
        {
            return null;
        }

        return level;
    }

    private sealed class BeginnerLevel : Level
    {
        public BeginnerLevel()
            : base(1, "A0", "beginner")
        {
        }
    }

    private sealed class ElementaryLevel : Level
    {
        public ElementaryLevel()
            : base(2, "A1", "elementary")
        {
        }
    }

    private sealed class PreIntermediateLevel : Level
    {
        public PreIntermediateLevel()
            : base(3, "A2", "pre-intermediate")
        {
        }
    }

    private sealed class IntermediateLevel : Level
    {
        public IntermediateLevel()
            : base(4, "B1", "intermediate")
        {
        }
    }

    private sealed class UpperIntermediateLevel : Level
    {
        public UpperIntermediateLevel()
            : base(5, "B2", "upper intermediate")
        {
        }
    }

    private sealed class AdvancedLevel : Level
    {
        public AdvancedLevel()
            : base(6, "C1", "advanced")
        {
        }
    }

    private sealed class ProficientLevel : Level
    {
        public ProficientLevel()
            : base(7, "C2", "proficient")
        {
        }
    }
}