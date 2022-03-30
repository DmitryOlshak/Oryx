using System;
using FluentAssertions;
using Xunit;

namespace Oryx.UnitTests.Tests;

public class ProgressTests
{
    [Theory]
    [InlineData(1, 0, 0)]
    [InlineData(8, 2, 0.25)]
    [InlineData(4, 2, 0.5)]
    [InlineData(16, 12, 0.75)]
    [InlineData(10, 10, 1)]
    public void Ctor_ShouldBeEqualExpectedValue(int totalCount, int actualCount, double expectedProgress)
    {
        var progress = new Progress(totalCount, actualCount);

        progress.Should().Be(expectedProgress);
    }

    [Fact]
    public void Ctor_TotalCountIsZero_ShouldThrowException()
    {
        var act = () => new Progress(0, 1);

        act.Should().ThrowExactly<ArgumentException>()
            .Where(exception => exception.ParamName == "totalCount");
    }
}