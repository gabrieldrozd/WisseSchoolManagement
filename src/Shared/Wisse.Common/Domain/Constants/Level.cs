using Wisse.Base.Types;

namespace Wisse.Common.Domain.Constants;

public class Level : PairEnumeration<Level>
{
    public static readonly Level A0 = new BeginnerLevel();
    public static readonly Level A1 = new ElementaryLevel();
    public static readonly Level A2 = new PreIntermediateLevel();
    public static readonly Level B1 = new IntermediateLevel();
    public static readonly Level B2 = new UpperIntermediateLevel();
    public static readonly Level C1 = new AdvancedLevel();
    public static readonly Level C2 = new ProficientLevel();

    private Level(string key, string name)
        : base(key, name)
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
            : base("A0", "beginner")
        {
        }
    }

    private sealed class ElementaryLevel : Level
    {
        public ElementaryLevel()
            : base("A1", "elementary")
        {
        }
    }

    private sealed class PreIntermediateLevel : Level
    {
        public PreIntermediateLevel()
            : base("A2", "pre-intermediate")
        {
        }
    }

    private sealed class IntermediateLevel : Level
    {
        public IntermediateLevel()
            : base("B1", "intermediate")
        {
        }
    }

    private sealed class UpperIntermediateLevel : Level
    {
        public UpperIntermediateLevel()
            : base("B2", "upper intermediate")
        {
        }
    }

    private sealed class AdvancedLevel : Level
    {
        public AdvancedLevel()
            : base("C1", "advanced")
        {
        }
    }

    private sealed class ProficientLevel : Level
    {
        public ProficientLevel()
            : base("C2", "proficient")
        {
        }
    }
}