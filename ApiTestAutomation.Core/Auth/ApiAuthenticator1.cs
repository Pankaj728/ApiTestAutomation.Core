using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTestAutomation.Core.API_Models;
using RestSharp;
using RestSharp.Authenticators;

namespace ApiTestAutomation.Core.Auth
{
    public class ApiAuthenticator1 : AuthenticatorBase
    {
        readonly string BaseUrl;
        readonly string ClientId;
        readonly string ClientSecret;

        public ApiAuthenticator1() : base("")
        {

        }
        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            var token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, token);
        }

        private async Task<string> GetToken()
        {
            var options = new RestClientOptions(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ClientId, ClientSecret),
            };
            var client = new RestClient(options);

            var request = new RestRequest("/oAuth2/token")
                .AddParameter("grant_type", "client_secret");

            var response = await client.PostAsync<TokenResponse>(request);
            return $"{response.TokenType} {response.AccessToken}";
        }
    }
}
