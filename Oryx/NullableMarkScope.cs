namespace Oryx;

internal sealed class NullableMarkScope : IEqualityComparer<NullableMarkScope>
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

    public bool Equals(NullableMarkScope? x, NullableMarkScope? y)
    {
        if (ReferenceEquals(null, x) && ReferenceEquals(null, y))
            return true;
        
        if (ReferenceEquals(null, x) || ReferenceEquals(null, y))
            return false;
        
        return x._value.Equals(y._value);
    }

    public int GetHashCode(NullableMarkScope obj)
    {
        return _value.GetHashCode();
    }
}