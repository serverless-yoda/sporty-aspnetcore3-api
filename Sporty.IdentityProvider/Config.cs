using IdentityServer4.Models;
using System.Collections.Generic;

namespace Sporty.IdentityProvider
{
    public class Config
    {
        public static IEnumerable<ApiResource> Apis { 
            get
            {
                return new List<ApiResource>
                {
                    new ApiResource("sporty-api","Sporty API")
                };
            }
        }

        public static IEnumerable<Client> Clients { 
            get
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = "client",
                        AllowedScopes = { "sporty-api"},
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("test-test1234".Sha256())
                        }
                    }
                };
            }
        }
    }
}
