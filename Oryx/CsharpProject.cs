using System.Xml;

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

internal sealed class CsharpProject
{
    private CsharpProject(bool nullableEnabled, string name, IReadOnlyCollection<CsharpFile> files)
    {
        NullableEnabled = nullableEnabled;
        Name = name;
        Files = files;
    }
    
    public bool NullableEnabled { get; }
    public string Name { get; }
    public IReadOnlyCollection<CsharpFile> Files { get; }

    public static CsharpProject Parse(string path)
    {
        var document = new XmlDocument();
        document.Load(path);
        var nullableValue = document["Project"]?["PropertyGroup"]?["Nullable"]?.InnerText;
        var nullableEnabled = nullableValue?.Equals("enable", StringComparison.InvariantCultureIgnoreCase) ?? false;

        var projectName = Path.GetFileNameWithoutExtension(path);
        
        var files = Directory.GetFiles(Path.GetDirectoryName(path)!, "*.cs", SearchOption.AllDirectories)
            .Select(filePath => new CsharpFile(filePath, NullableMarkScope.Parse(filePath)))
            .ToList();

        return new CsharpProject(nullableEnabled, projectName, files);
    }
}