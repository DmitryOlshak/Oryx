using Microsoft.Build.Construction;

namespace Oryx;

internal sealed class CsharpProjectsCollection : List<CsharpProject>
{
    public CsharpProjectsCollection(string solutionPath)
    {
        var solution = SolutionFile.Parse(solutionPath);
        
        var projects = solution.ProjectsInOrder
            .Where(project => Path.GetExtension(project.AbsolutePath) == ".csproj")
            .Select(project => CsharpProject.Parse(project.AbsolutePath));
        
        AddRange(projects);
    }
}