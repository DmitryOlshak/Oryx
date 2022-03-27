using Oryx;


var projects = new CsharpProjectsCollection(@"S:\Source\NullableExample\NullableExample.sln");

var summary = new NullableSummary(projects);

Print(summary);

Console.ReadKey();

void Print(NullableSummary summary)
{
    foreach (var summaryItem in summary.Items)
    {
        Console.WriteLine($"{summaryItem.Progress}\t{summaryItem.ProjectName}");
        foreach (var notReadyFile in summaryItem.NotReadyFiles)
        {
            Console.WriteLine($"\t{notReadyFile.FullPath}");
        }
    }
}