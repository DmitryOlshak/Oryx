using CommandLine;

internal sealed class ConsoleOptions
{
    [Option("sln", Required = true, HelpText = "Path to the solution file to analyze")]
    public string SolutionPath { get; set; } = string.Empty;

    [Option("short", HelpText = "Flag to print summary without not ready files")]
    public bool ShortOutput { get; set; } = false;
}