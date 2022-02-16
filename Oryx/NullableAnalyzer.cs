namespace Oryx;

internal static class NullableAnalyzer
{
    public static ProjectNullableInfo Analyze(CsharpProject project)
    {
        if (project.NullableEnabled)
            return ProjectNullableInfo.FillSupport(project.Name);
        
        var notReadyFiles = project.Files
            .Where(file => !ContainsNullableMark(file))
            .ToList();

        var progress = notReadyFiles.Count / (double)project.Files.Count;

        return new ProjectNullableInfo(progress, project.Name, notReadyFiles);
    }

    private static bool ContainsNullableMark(FileSystemInfo file)
    {
        using var fileStream = File.OpenRead(file.FullName);
        using var reader = new StreamReader(fileStream);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine()?.Trim() ?? string.Empty;
            if (line.Equals("#nullable enable", StringComparison.InvariantCultureIgnoreCase))
                return true;
        }

        return false;
    }
}