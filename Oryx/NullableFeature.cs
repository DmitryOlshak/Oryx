namespace Oryx;

internal sealed class NullableFeature : IComparable<NullableFeature>
{
    private readonly string _value;

    public static NullableFeature Enabled { get; } = new(nameof(Enabled));
    public static NullableFeature Disabled { get; } = new(nameof(Disabled));

    private NullableFeature(string value)
    {
        _value = value;
    }

    public static NullableFeature Parse(string projectPath)
    {
        var projectContent = File.ReadAllText(projectPath);

        const string featureText = "<Nullable>enable</Nullable>";
        var featureEnabled = projectContent.Contains(featureText, StringComparison.InvariantCultureIgnoreCase);

        return featureEnabled ? Enabled : Disabled;
    }
    
    public int CompareTo(NullableFeature? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return string.Compare(_value, other._value, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return _value;
    }
}