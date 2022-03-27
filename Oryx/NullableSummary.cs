using System.Collections;

namespace Oryx;

internal class NullableSummary
{
    private readonly List<NullableSummaryItem> _items = new();

    public NullableSummary(ProjectsCollection projects)
    {
        foreach (var project in projects)
        {
            if (project.NullableEnabled)
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