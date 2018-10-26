using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using CometD.NetCore.Client;
using CometD.NetCore.Client.Transport;

namespace StreamingAPI_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Task<AuthResponse> authResponse = Task.Run(() => LoginController.AsyncAuthRequest());
            authResponse.Wait();
            if (authResponse.Result != null)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                try
                {
                    int readTimeOut = 120000;
                    string streamingEndpointURI = "/cometd/43.0";
                    var options = new Dictionary<String, Object>
                    {
                        { ClientTransport.TIMEOUT_OPTION, readTimeOut }
                    };
                    NameValueCollection collection = new NameValueCollection();
                    collection.Add(HttpRequestHeader.Authorization.ToString(), "OAuth " + authResponse.Result.access_token);
                    var transport = new LongPollingTransport(options, new NameValueCollection { collection });
                    var serverUri = new Uri(authResponse.Result.instance_url);
                    String endpoint = String.Format("{0}://{1}{2}", serverUri.Scheme, serverUri.Host, streamingEndpointURI);
                    var bayeuxClient = new BayeuxClient(endpoint, new[] { transport });
                    var pushTopicConnection = new PushTopicConnection(bayeuxClient);
                    pushTopicConnection.Connect();
                    //Close the connection
                    Console.WriteLine("Press any key to shut down.\n");
                    Console.ReadKey();
                    pushTopicConnection.Disconect();
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
