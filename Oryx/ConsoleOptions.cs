using CommandLine;

internal sealed class ConsoleOptions
{
    [Option("sln", Required = true, HelpText = "Path to the solution file to analyze")]
    public string SolutionPath { get; set; } = string.Empty;
}