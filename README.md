[![](https://img.shields.io/nuget/v/soenneker.windmill.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.windmill.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.windmill.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.windmill.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.windmill.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.windmill.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.windmill.openapiclient/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.windmill.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Windmill.OpenApiClient

A Kiota client for Windmill workspaces, scripts, flows, jobs, resources, schedules, and instance administration.

## Installation

```bash
dotnet add package Soenneker.Windmill.OpenApiClient
```

## Usage

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Windmill.OpenApiClient;
using Soenneker.Windmill.OpenApiClient.Models;

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", "your-user-token");

var authProvider = new AnonymousAuthenticationProvider();
var adapter = new HttpClientRequestAdapter(authProvider, httpClient: httpClient)
{
    BaseUrl = "https://app.windmill.dev/api"
};

var client = new WindmillOpenApiClient(adapter);

List<ListWorkspaces200ResponseSchemaItem>? workspaces =
    await client.Workspaces.List.GetAsync();

foreach (ListWorkspaces200ResponseSchemaItem workspace in workspaces ?? [])
{
    Console.WriteLine($"{workspace.Id}: {workspace.Name}");
}
```

For self-hosted Windmill, set `BaseUrl` to your instance URL followed by `/api`. The token determines which workspaces and operations are available; Windmill supports scoped tokens when the client only needs a subset of scripts, flows, jobs, or resources.
