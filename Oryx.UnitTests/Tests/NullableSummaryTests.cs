using System.Linq;
using FluentAssertions;
using Xunit;

namespace Oryx.UnitTests.Tests;

public class NullableSummaryTests
{
    [Fact]
    public void Ctor_NullableEnabled_ShouldBeFullSupported()
    {
        var files = new[]
        {
            new CsharpFile("qwer1", NullableMarkScope.None), 
            new CsharpFile("qwer2", NullableMarkScope.None)
        };
        var projects = new[]
        {
            new CsharpProject(NullableFeature.Enabled, "name", files)
        };

        var summary = new NullableSummary(projects);

        summary.Items.Should().ContainSingle(item => item.FeatureReadiness == FeatureReadiness.Full);
    }
    
    [Fact]
    public void Ctor_ThereIsFileWithoutNullableMark_ShouldHaveOnlyThatFile()
    {
        var files = new[]
        {
            new CsharpFile("qwer0", NullableMarkScope.File), 
            new CsharpFile("qwer1", NullableMarkScope.File), 
            new CsharpFile("qwer2", NullableMarkScope.None)
        };
        var projects = new[]
        {
            new CsharpProject(NullableFeature.Disabled, "name", files)
        };

        var summaryItem = new NullableSummary(projects).Items.First();

        summaryItem.NotReadyFiles.Should().ContainSingle(file => file.FullPath == "qwer2");
    }
}