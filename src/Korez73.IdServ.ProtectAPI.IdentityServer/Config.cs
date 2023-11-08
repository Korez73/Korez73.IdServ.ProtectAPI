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
            new ApiScope("Korez73.IdServ.ProtectAPI.API", "Korez73.IdServ.ProtectAPI.API")
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        { 
            new Client
            {
                ClientId = "Korez73.IdServ.ProtectAPI.Client",
                //no interactive user, use the clientid/secret for authN
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                //secret for authN
                ClientSecrets = 
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = {"Korez73.IdServ.ProtectAPI.API"}
            }

        };
}