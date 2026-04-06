using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Windmill.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class WindmillOpenApiClientTests : FixturedUnitTest
{
    public WindmillOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
