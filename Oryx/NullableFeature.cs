using System.Xml;

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
        var document = new XmlDocument();
        document.Load(projectPath);
        var nullableValue = document["Project"]?["PropertyGroup"]?["Nullable"]?.InnerText;
        var nullableEnabled = nullableValue?.Equals("enable", StringComparison.InvariantCultureIgnoreCase) ?? false;

        return nullableEnabled ? Enabled : Disabled;
    }
    
    public int CompareTo(NullableFeature? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return string.Compare(_value, other._value, StringComparison.Ordinal);
    }
}