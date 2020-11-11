# NewsPaper.GatewayClientApi
 
 This is a public REST API client, based on ASP.NET Core 3.1, authentication with IdentityServer4, as well as Swagger, AutoMapper, etc.
  
## Retrieve Token To IdentityServer in RequestClientCredentialsToken

```C#
public async Task<HttpClient> RetrieveToIdentityServer(IHttpClientFactory httpClientFactory)
{
    var authClient = httpClientFactory.CreateClient();

    var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:10001");

    var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
        new ClientCredentialsTokenRequest
        {
            Address = discoveryDocument.TokenEndpoint,
            ClientId = "client_id",
            ClientSecret = "client_secret",
            Scope = "GatewayClientApi"
        });

    var articlesClient = httpClientFactory.CreateClient();

    articlesClient.SetBearerToken(tokenResponse.AccessToken);

    return articlesClient;
}
```

## Links to project repositories
- :white_check_mark:[NewsPaper Review](https://github.com/PKravchenko-ki16/NewsPaper)
- :white_check_mark:[NewsPaper.MassTransit.Configuration](https://github.com/PKravchenko-ki16/NewsPaper.MassTransit.Configuration)
- :white_check_mark:[NewsPaper.MassTransit.Contracts](https://github.com/PKravchenko-ki16/NewsPaper.MassTransit.Contracts)
- :black_square_button:[NewsPaper.IdentityServer]()
- :white_check_mark:[Newspaper.GateWay](https://github.com/PKravchenko-ki16/Newspaper.GateWay)
- :white_check_mark:[NewsPaper.Accounts](https://github.com/PKravchenko-ki16/NewsPaper.Accounts)
- :white_check_mark:[NewsPaper.Articles](https://github.com/PKravchenko-ki16/NewsPaper.Articles)
- :white_check_mark:NewsPaper.GatewayClientApi
- :white_check_mark:[NewsPaper.Client.Mvc](https://github.com/PKravchenko-ki16/NewsPaper.Client.Mvc)
