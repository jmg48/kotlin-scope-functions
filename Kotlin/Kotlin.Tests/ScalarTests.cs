using NUnit.Framework;

namespace Kotlin.Tests;

using System.Text;
using AwesomeAssertions;

[TestFixture]
public class LetTests
{
    [Test]
    public void ShouldLet()
    {
        var text = new StringBuilder()
            .Append("Hello, ")
            .Append("is it me you're looking for?")
            .Let(it => it.ToString());

        text.Should().Be("Hello, is it me you're looking for?");
    }
}