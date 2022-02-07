using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;
using Twilio.Api.Test.TestBase;

namespace Twilio.Api.Test
{
    [TestClass]
    public class TwilioAPITest
    {
        [TestMethod]
        [TestCategory("TwilioApiGet")]
        public async Task TwilioGetRequest()
        {
            ClientSetup cs = new ClientSetup();
            var response = await cs.testGetRequest();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseContent = response.Content.ToString();
            Console.WriteLine(responseContent);
        }

        [TestMethod]
        [TestCategory("TwilioApiPost")]
        public async Task TwilioPostRequest()
        {
            ClientSetup cs = new ClientSetup();
            var response = await cs.testPostRequest("Sent from Microsoft Visual Studio!");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
