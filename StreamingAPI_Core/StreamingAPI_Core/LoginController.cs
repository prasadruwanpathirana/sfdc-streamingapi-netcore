using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StreamingAPI_Core
{
    class LoginController
    {
        public async static Task<AuthResponse> AsyncAuthRequest()
        {
            var content = new FormUrlEncodedContent(new[]
                 {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", Constants.CONSUMER_KEY),
                    new KeyValuePair<string, string>("client_secret", Constants.CONSUMER_SECRET),
                    new KeyValuePair<string, string>("username", Constants.USERNAME),
                    new KeyValuePair<string, string>("password", Constants.PASSWORD + Constants.TOKEN)
                });
            HttpClient _httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Constants.TOKEN_REQUEST_ENDPOINTURL),
                Content = content
            };
            var responseMessage = await _httpClient.SendAsync(request).ConfigureAwait(false);
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            AuthResponse responseDyn = JsonConvert.DeserializeObject<AuthResponse>(response);
            return responseDyn;
        }
    }
}


