using System.Globalization;

namespace Oryx;

internal readonly struct FeatureReadiness : IFormattable, IComparable<FeatureReadiness>
{
    private readonly double _value;
    
    public FeatureReadiness(int totalFilesCount, int notReadyFilesCount)
    {
        if (totalFilesCount == 0)
            throw new ArgumentException($"{nameof(totalFilesCount)} can not be zero", nameof(totalFilesCount));
        
        _value = (totalFilesCount - notReadyFilesCount) / (double) totalFilesCount;
    }

    private FeatureReadiness(double value)
    {
        _value = value;
    }

    public static FeatureReadiness Full => new (1);

    public static implicit operator double(FeatureReadiness f) => f._value;
    public static implicit operator FeatureReadiness(double d) => new (d);
    
    public static bool operator ==(FeatureReadiness left, FeatureReadiness right)
    {
        return left._value == right._value;
    }
    
    public static bool operator !=(FeatureReadiness left, FeatureReadiness right)
    {
        return left._value != right._value;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is int integer)
            return _value == integer;
        
        if (obj is double floating)
            return _value == floating;
        
        return obj is FeatureReadiness other && _value.Equals(other._value);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public override string ToString()
    {
        return _value.ToString(CultureInfo.InvariantCulture);
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return _value.ToString(format, formatProvider);
    }

    public int CompareTo(FeatureReadiness other)
    {
        return _value.CompareTo(other._value);
    }
}