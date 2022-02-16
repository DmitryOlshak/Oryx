namespace Oryx;

internal sealed class ProjectNullableInfo
{
    public ProjectNullableInfo(double progress, string projectName, IReadOnlyCollection<FileSystemInfo> notReadyFiles)
    {
        Progress = progress;
        ProjectName = projectName;
        NotReadyFiles = notReadyFiles;
    }

    public double Progress { get; }
    public string ProjectName { get; }
    public IReadOnlyCollection<FileSystemInfo> NotReadyFiles { get; }

    public static ProjectNullableInfo FillSupport(string projectName) 
        => new ProjectNullableInfo(1, projectName, Array.Empty<FileInfo>());
}