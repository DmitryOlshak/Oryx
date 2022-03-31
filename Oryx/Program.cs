using CommandLine;
using Oryx;


Parser.Default.ParseArguments<ConsoleOptions>(args)
    .WithParsed(Run);

void Run(ConsoleOptions options)
{
    var projects = new CsharpProjectsCollection(options.SolutionPath);

    var summary = new NullableSummary(projects);
        
    Print(summary, options);

    Console.ReadKey();
}

void Print(NullableSummary summary, ConsoleOptions options)
{
    foreach (var summaryItem in summary.Items)
    {
        Console.WriteLine($"{summaryItem.FeatureReadiness:P}\t{summaryItem.ProjectName}");
        
        if (options.ShortOutput)
            continue;
        
        foreach (var notReadyFile in summaryItem.NotReadyFiles)
        {
            Console.WriteLine($"\t{notReadyFile.FullPath}");
        }
    }
}