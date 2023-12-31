﻿// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using IdentityModel.Client;

//discover endpoints from metadata
var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
if(disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}


//request token
var tokenResponse = await client.RequestClientCredentialsTokenAsync(
    new ClientCredentialsTokenRequest
    {
        Address = disco.TokenEndpoint,
        ClientId = "Korez73.IdServ.ProtectAPI.Client",
        ClientSecret = "secret",
        Scope = "Korez73.IdServ.ProtectAPI.API"

    });
if(tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}
if(null == tokenResponse.AccessToken)
{
    Console.WriteLine("tokenResponse.AccessToken is null");
    return;
}
//Console.WriteLine(tokenResponse.AccessToken);

//call api
var apiClient = new HttpClient();
apiClient.SetBearerToken(tokenResponse.AccessToken);

var response = await apiClient.GetAsync("https://localhost:6001/identity");
if (!response.IsSuccessStatusCode)
{
    Console.WriteLine(response.StatusCode);
}
else
{
    var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
    Console.WriteLine(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
}



Console.WriteLine("Hello, World!");
