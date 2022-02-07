using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;
using Twilio.Api.Test.Serilog;
using Twilio.Api.Test.Twilio;

namespace Twilio.Api.Test
{
    [TestClass]
    public class TwilioAPITest
    {

        SerilogConsole sc = new SerilogConsole();
        SerilogFile sf = new SerilogFile();
        //[TestMethod]
        //[TestCategory("TwilioApiGet")]
        //public async Task TwilioGetRequest()
        //{

        //    var response = await cs.testGetRequest();
        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    string responseContent = response.Content.ToString();
        //    Console.WriteLine(responseContent);
        //}

        [TestMethod]
        [TestCategory("TwilioApiPost")]
        public async Task TwilioPostRequest()
        {
            TwilioClientWrapper tcw = new TwilioClientWrapper(Credentials.TWILIO_ACCOUNT_SID, Credentials.TWILIO_AUTH_TOKEN);
            //Initializes Twilio Client
            tcw.Init();
            sf.LogIt("Twilio Client Wrapper successfully initialized");
            //sc.LogIt("Twilio Client Wrapper successfully initialized");
            var response = await tcw.MessageAsync("+16103793312", "+18109648508", "Live from Universal Studios!");
            //Assert.AreEqual(HttpStatusCode.OK, response.Result.Status);
        }
    }
}
