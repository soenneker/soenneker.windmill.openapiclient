using Soenneker.Tests.HostedUnit;

namespace Soenneker.Windmill.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class WindmillOpenApiClientTests : HostedUnitTest
{
    public WindmillOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
