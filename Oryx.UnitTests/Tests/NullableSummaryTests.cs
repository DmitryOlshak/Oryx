using System;
using System.Linq;
using FluentAssertions;
using Oryx.UnitTests.Extensions;
using Xunit;

namespace Oryx.UnitTests.Tests;

public class NullableSummaryTests
{
    [Fact]
    public void Ctor_NullableEnabled_ShouldBeFullSupported()
    {
        const string projectName = nameof(projectName);
        var files = Array.Empty<CsharpFile>();
        var projects = new CsharpProject(NullableFeature.Enabled, projectName, files).AsArray();
        var expected = new NullableSummaryItem(FeatureReadiness.Full, projectName, files);
        
        var summary = new NullableSummary(projects);

        summary.Items.Should().ContainSingle()
            .And.ContainEquivalentOf(expected);
    }
    
    [Fact]
    public void Ctor_ThereIsFileWithoutNullableMark_ShouldHaveOnlyThatFile()
    {
        var notReadyFile = new CsharpFile("qwer2", NullableMarkScope.None);
        var files = new[]
        {
            new CsharpFile("qwer0", NullableMarkScope.File), 
            new CsharpFile("qwer1", NullableMarkScope.File), 
            notReadyFile
        };
        var projects = new CsharpProject(NullableFeature.Disabled, "name", files).AsArray();

        var summaryItem = new NullableSummary(projects).Items.First();

        summaryItem.NotReadyFiles.Should().ContainSingle()
            .And.ContainEquivalentOf(notReadyFile);
    }
}