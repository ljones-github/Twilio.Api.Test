using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Twilio.Api.Test.TestBase
{
    public class ClientSetup
    {

        private HttpClient restClient = new HttpClient();
        private HttpRequestMessage restReq;
        private string uri = "https://api.twilio.com/2010-04-01/Accounts"; 

        public async Task<HttpResponseMessage> testGetRequest()
        {
            setDefaultHeaders(restClient);
            var builder = new System.UriBuilder($"{uri}/AC20439bd63ef360ee29e4529da831511e/Messages.json");
            var response = await restClient.GetAsync(builder.Uri);
            return response;
        }

        public async Task<HttpResponseMessage> testPostRequest(string message)
        {
            setDefaultHeaders(restClient);

            var dict = new List<KeyValuePair<string, string>>();
            dict.Add(new KeyValuePair<string, string>("To", "+18109648508"));
            dict.Add(new KeyValuePair<string, string>("Body", $"{message}"));
            dict.Add(new KeyValuePair<string, string>("MediaUrl", "C:\\Users\\ljone\\Desktop\\Guitar Hero!\\45087182_697854963933323_2663404083192266752_n.jpg"));
            dict.Add(new KeyValuePair<string, string>("From", "+16103793312"));
            var builder = new System.UriBuilder($"{uri}/AC20439bd63ef360ee29e4529da831511e/Messages.json");
            var encodedContent = new FormUrlEncodedContent(dict);
            restReq = new HttpRequestMessage(HttpMethod.Post, builder.Uri) { Content = encodedContent };
            var response = await restClient.SendAsync(restReq);
            return response;
        }

        public void setDefaultHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            var credentials = System.Text.Encoding.UTF8.GetBytes("AC20439bd63ef360ee29e4529da831511e:ab4b933ff5e6163af21b2d41ed5d87f5");
            string val = System.Convert.ToBase64String(credentials);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + val);
        }
    }
}
