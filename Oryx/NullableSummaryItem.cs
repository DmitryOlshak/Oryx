namespace Oryx;

internal sealed class NullableSummaryItem
{
    public NullableSummaryItem(Progress progress, string projectName, IReadOnlyCollection<CsharpFile> notReadyFiles)
    {
        Progress = progress;
        ProjectName = projectName;
        NotReadyFiles = notReadyFiles;
    }
    
    public Progress Progress { get; }
    public string ProjectName { get; }
    public IReadOnlyCollection<CsharpFile> NotReadyFiles { get; }
    
    public static NullableSummaryItem FullSupport(string projectName) 
        => new (Progress.Done, projectName, Array.Empty<CsharpFile>());
}