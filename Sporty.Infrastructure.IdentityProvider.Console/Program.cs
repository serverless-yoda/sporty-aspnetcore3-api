using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sporty.Infrastructure.IdentityProvider.Console
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            var httpClient = new HttpClient();
            var doc = await httpClient.GetDiscoveryDocumentAsync("http://localhost:51783");

            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(

                    new ClientCredentialsTokenRequest()
                    {
                        Address = doc.TokenEndpoint,
                        ClientId = "client",
                        ClientSecret = "test-test1234",
                        Scope = "sporty-api"
                    }
                ); ;

            System.Console.WriteLine($"Token:  { tokenResponse.AccessToken}");
              
        }
    }
}
