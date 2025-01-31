﻿using Infrastructure.Configuration;
using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services
{
    public class InternalHttpClientService : IInternalHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly AuthorizationConfig _authConfig;
        private readonly ClientConfig _clientConfig;

        public InternalHttpClientService(
            IHttpClientFactory clientFactory,
            IOptions<ClientConfig> clientConfig,
            IOptions<AuthorizationConfig> authConfig)
        {
            _clientFactory = clientFactory;
            _authConfig = authConfig.Value;
            _clientConfig = clientConfig.Value;
        }

        public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? context)
        {
            var client = _clientFactory.CreateClient();
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = $"{_authConfig.Authority}/connect/token",
                ClientId = _clientConfig.Id,
                ClientSecret = _clientConfig.Secret
            });

            client.SetBearerToken(tokenResponse.AccessToken);

            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(url);
            httpMessage.Method = method;

            if (context != null)
            {
                httpMessage.Content = new StringContent(JsonConvert.SerializeObject(context), Encoding.UTF8, "application/json");
            }

            var result = await client.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                return response!;
            }

            return default(TResponse) !;
        }
    }
}
