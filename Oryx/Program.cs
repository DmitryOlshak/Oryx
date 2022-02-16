// See https://aka.ms/new-console-template for more information

using Microsoft.Build.Construction;
using Oryx;


var projects = EnumerateProjectInSolutions(@"S:\Source\NullableExample\NullableExample.sln")
    .Select(project => CsharpProject.Parse(project.AbsolutePath))
    .ToList();

var projectNullableInfos = projects.Select(NullableAnalyzer.Analyze).ToList();

Print(projectNullableInfos);


Console.ReadKey();

IEnumerable<ProjectInSolution> EnumerateProjectInSolutions(string solutionPath)
{
    var solution = SolutionFile.Parse(solutionPath);
    return solution.ProjectsInOrder
        .Where(project => Path.GetExtension(project.AbsolutePath) == ".csproj");
}

void Print(IEnumerable<ProjectNullableInfo> infos)
{
    foreach (var nullableInfo in infos)
    {
        Console.WriteLine($"{nullableInfo.Progress:P}\t{nullableInfo.ProjectName}");
        foreach (var notReadyFile in nullableInfo.NotReadyFiles)
        {
            Console.WriteLine($"\t{notReadyFile.Name}");
        }
    }
}