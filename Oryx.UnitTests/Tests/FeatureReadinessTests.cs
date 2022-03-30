using System;
using FluentAssertions;
using Xunit;

namespace Oryx.UnitTests.Tests;

public class FeatureReadinessTests
{
    [Theory]
    [InlineData(1, 0, 1)]
    [InlineData(8, 2, 0.75)]
    [InlineData(4, 2, 0.5)]
    [InlineData(16, 12, 0.25)]
    [InlineData(10, 10, 0)]
    public void Ctor_ShouldBeEqualExpectedValue(int totalFilesCount, int notReadyFilesCount, double expectedReadiness)
    {
        var progress = new FeatureReadiness(totalFilesCount, notReadyFilesCount);

        progress.Should().Be(expectedReadiness);
    }

    [Fact]
    public void Ctor_TotalCountIsZero_ShouldThrowException()
    {
        var act = () => new FeatureReadiness(0, 1);

        act.Should().ThrowExactly<ArgumentException>()
            .Where(exception => exception.ParamName == "totalFilesCount");
    }
}