using System;
using FluentAssertions;
using Xunit;

namespace Oryx.UnitTests.Tests;

public class FeatureReadinessTests
{
    [Theory]
    [InlineData(1, 0, 0)]
    [InlineData(8, 2, 0.25)]
    [InlineData(4, 2, 0.5)]
    [InlineData(16, 12, 0.75)]
    [InlineData(10, 10, 1)]
    public void Ctor_ShouldBeEqualExpectedValue(int totalCount, int actualCount, double expectedReadiness)
    {
        var progress = new FeatureReadiness(totalCount, actualCount);

        progress.Should().Be(expectedReadiness);
    }

    [Fact]
    public void Ctor_TotalCountIsZero_ShouldThrowException()
    {
        var act = () => new FeatureReadiness(0, 1);

        act.Should().ThrowExactly<ArgumentException>()
            .Where(exception => exception.ParamName == "totalCount");
    }
}