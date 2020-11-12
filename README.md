# NewsPaper.GatewayClientApi
 
 This is a public REST API client, based on ASP.NET Core 3.1, authentication with IdentityServer4, as well as Swagger, AutoMapper, etc.
  
## Screenshots

General queries

![Alt-текст](https://downloader.disk.yandex.ru/preview/936641acd5a488cf7ec85aced53c00b09011c0d5f6f95afc085b1ccb06e09a50/5fad44f7/o5TRjymLK6o2bnM1dD02S6cpwKM48HQ8bTxZPU09__mRbOV7FeIW1rCf8gOtp2x1e82qbKL0LpTg1ufqKx_WHA==?uid=0&filename=2020-11-12_16-55-48.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&tknv=v2&owner_uid=311404214&size=2048x2048 "Swagger screenshot")

Example request with parameter

![Alt-текст](https://downloader.disk.yandex.ru/preview/ed12fda738abc26fa685b7ab769043ecd9ae8e7222f7916bf6484c306fc73311/5fad4538/Z-6MquM9yFoHZvLykOYvkvqDHKwkXAdvcf0ecOSQjFfHLvJQkD6VUd5enN4e4wdjlB1YdODn_nc9s38q_mRRyA==?uid=0&filename=2020-11-12_17-01-18.png&disposition=inline&hash=&limit=0&content_type=image%2Fpng&tknv=v2&owner_uid=311404214&size=2048x2048 "Swagger screenshot")

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
