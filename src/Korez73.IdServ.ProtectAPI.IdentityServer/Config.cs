using Duende.IdentityServer.Models;

namespace Korez73.IdServ.ProtectAPI.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
            { 
                new ApiScope("Korez73.IsServ.ProtectAPI.API", "Korez73.IsServ.ProtectAPI.API")
            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            { };
}