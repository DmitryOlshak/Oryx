using System.Collections;

namespace Oryx;

internal sealed class CsharpFilesCollection : IReadOnlyCollection<CsharpFile>
{
    private readonly IReadOnlyCollection<CsharpFile> _list;

    private CsharpFilesCollection(IReadOnlyCollection<CsharpFile> list)
    {
        _list = list;
    }
    
    public int Count => _list.Count;
    
    public IEnumerator<CsharpFile> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static CsharpFilesCollection FromProject(string projectPath)
    {
        const string fileExtension = "*.cs";
        var directory = Path.GetDirectoryName(projectPath)!;

        var files = Directory.GetFiles(directory, fileExtension, SearchOption.AllDirectories)
            .Select(filePath => new CsharpFile(filePath, NullableMarkScope.Parse(filePath)))
            .ToList();

        return new CsharpFilesCollection(files);
    }
}