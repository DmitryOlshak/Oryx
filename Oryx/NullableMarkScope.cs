namespace Oryx;

internal sealed class NullableMarkScope : IComparable<NullableMarkScope>
{
    private readonly string _value;

    public static NullableMarkScope File = new (nameof(File));
    public static NullableMarkScope None = new (nameof(None));

    private NullableMarkScope(string value)
    {
        _value = value;
    }
    
    public static NullableMarkScope Parse(string filePath)
    {
        using var fileStream = System.IO.File.OpenRead(filePath);
        using var reader = new StreamReader(fileStream);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine()?.Trim() ?? string.Empty;
            if (line.Equals("#nullable enable", StringComparison.InvariantCultureIgnoreCase))
                return File;
        }
        
        return None;
    }

    public int CompareTo(NullableMarkScope? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return string.Compare(_value, other._value, StringComparison.Ordinal);
    }
}