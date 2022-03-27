using System.Globalization;

namespace Oryx;

internal readonly struct Progress
{
    private readonly double _value;
    
    public Progress(int totalCount, int actualCount)
    {
        _value = totalCount / (double)actualCount;
    }

    private Progress(double value)
    {
        _value = value;
    }

    public static Progress Done => new (1);

    public override string ToString() 
        => _value.ToString("P", CultureInfo.InvariantCulture);
}