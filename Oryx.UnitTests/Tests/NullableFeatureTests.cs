using System.IO;
using FluentAssertions;
using Xunit;

namespace Oryx.UnitTests.Tests;

public class NullableFeatureTests
{
    [Theory]
    [InlineData("Files/Project1.xml")]
    [InlineData("Files/Project2.xml")]
    public void Parse_ShouldBeEnabled(string projectPath)
    {
        var feature = NullableFeature.Parse(projectPath);

        feature.Should().Be(NullableFeature.Enabled);
    }
    
    [Fact]
    public void Parse_ShouldBeDisabled()
    {
        var feature = NullableFeature.Parse("Files/Project3.xml");

        feature.Should().Be(NullableFeature.Disabled);
    }
}