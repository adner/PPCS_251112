using AspNetCoreMcpServer.Tools;
using AspNetCoreMcpServer.Resources;
using System.Net.Http.Headers;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithTools<DataverseTool>()
    .WithResources<SimpleResourceType>();

builder.Services.AddSingleton<IOrganizationService>(provider =>
{
    // TODO Enter your Dataverse environment's URL and logon info.
    string url = "[Url]";
    string connectionString = $@"
    AuthType = ClientSecret;
    Url = {url};
    ClientId = [ClientId];
    Secret = [ClientSecret]";

    return new ServiceClient(connectionString);
});

var app = builder.Build();

app.MapMcp();

app.Run();
