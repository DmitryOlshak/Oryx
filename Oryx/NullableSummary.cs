namespace Oryx;

internal class NullableSummary
{
    private readonly List<NullableSummaryItem> _items = new();

    public NullableSummary(CsharpProjectsCollection csharpProjects)
    {
        foreach (var project in csharpProjects)
        {
            if (project.NullableFeature == NullableFeature.Enabled)
            {
                _items.Add(NullableSummaryItem.FullSupport(project.Name));
                continue;
            }
        
            var notReadyFiles = project.Files
                .Where(file => file.NullableMarkScope != NullableMarkScope.File)
                .ToList();

            var totalCount = notReadyFiles.Count;
            var actualCount = project.Files.Count;
            var progress = new Progress(totalCount, actualCount);
            
            _items.Add(new NullableSummaryItem(progress, project.Name, notReadyFiles));
        }
    }
    
    public IEnumerable<NullableSummaryItem> Items
        => _items;
}