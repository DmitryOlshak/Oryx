namespace Oryx;

internal sealed class NullableSummaryItem
{
    public NullableSummaryItem(FeatureReadiness featureReadiness, string projectName, IReadOnlyCollection<CsharpFile> notReadyFiles)
    {
        FeatureReadiness = featureReadiness;
        ProjectName = projectName;
        NotReadyFiles = notReadyFiles;
    }
    
    public FeatureReadiness FeatureReadiness { get; }
    public string ProjectName { get; }
    public IReadOnlyCollection<CsharpFile> NotReadyFiles { get; }
    
    public static NullableSummaryItem FullSupport(string projectName) 
        => new (FeatureReadiness.Done, projectName, Array.Empty<CsharpFile>());
}