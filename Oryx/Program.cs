using CommandLine;
using Oryx;


Parser.Default.ParseArguments<ConsoleOptions>(args)
    .WithParsed(Run);

void Run(ConsoleOptions options)
{
    var projects = new CsharpProjectsCollection(options.SolutionPath);

    var summary = new NullableSummary(projects);
        
    Print(summary);

    Console.ReadKey();
}

void Print(NullableSummary summary)
{
    foreach (var summaryItem in summary.Items)
    {
        Console.WriteLine($"{summaryItem.Progress:P}\t{summaryItem.ProjectName}");
        foreach (var notReadyFile in summaryItem.NotReadyFiles)
        {
            Console.WriteLine($"\t{notReadyFile.FullPath}");
        }
    }
}