namespace Oryx;

internal sealed class CsharpFile
{
    public CsharpFile(string fullPath, NullableMarkScope nullableMarkScope)
    {
        FullPath = fullPath;
        NullableMarkScope = nullableMarkScope;
    }
    
    public string FullPath { get; }
    public NullableMarkScope NullableMarkScope { get; }
}