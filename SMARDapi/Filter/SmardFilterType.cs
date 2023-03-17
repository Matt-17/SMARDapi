namespace SMARDapi.Filter;

public abstract class SmardFilterType
{
    private string Value { get; }

    protected SmardFilterType(string value)
    {
        Value = value;
    }

    public override string ToString() => Value;
}