namespace Oryx.UnitTests.Extensions;

public static class ValueExtension
{
    public static T[] AsArray<T>(this T value)
    {
        return new[] { value };
    }
}