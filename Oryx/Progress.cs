﻿using System.Globalization;

namespace Oryx;

internal readonly struct Progress : IFormattable
{
    private readonly double _value;
    
    public Progress(int totalCount, int actualCount)
    {
        if (totalCount == 0)
            throw new ArgumentException($"{nameof(totalCount)} can not be zero", nameof(totalCount));
        
        _value = actualCount / (double) totalCount;
    }

    private Progress(double value)
    {
        _value = value;
    }

    public static Progress Done => new (1);

    public override bool Equals(object? obj)
    {
        if (obj is int integer)
            return _value == integer;
        
        if (obj is double floating)
            return _value == floating;
        
        return obj is Progress other && _value.Equals(other._value);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return _value.ToString(format, formatProvider);
    }
}