namespace Oryx;

internal sealed class CsharpProject
{
    private CsharpProject(NullableFeature nullableFeature, string name, IReadOnlyCollection<CsharpFile> files)
    {
        NullableFeature = nullableFeature;
        Name = name;
        Files = files;
    }
    
    public NullableFeature NullableFeature { get; }
    public string Name { get; }
    public IReadOnlyCollection<CsharpFile> Files { get; }

    public static CsharpProject Parse(string projectPath)
    {
        var nullableFeature = NullableFeature.Parse(projectPath);

        var projectName = Path.GetFileNameWithoutExtension(projectPath);

        var files = CsharpFilesCollection.FromProject(projectPath);

        return new CsharpProject(nullableFeature, projectName, files);
    }
}