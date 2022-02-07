using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio.Api.Test.Interfaces;
using Twilio.Api.Test.Serilog;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Twilio.Api.Test.Twilio
{
    public class TwilioClientWrapper : IClient
    {
        private string acc_sid, auth_token;

        public TwilioClientWrapper(string sid, string authtoken)
        {
            acc_sid = sid;
            auth_token = authtoken;
            log = new SerilogFile();
        }
        public bool IsInitialized { get; set;}
        public bool CanSendSms { get { return true; } }
        public bool CanCall { get { return true; } }  
        
        public bool FromNumberRequired { get { return true; } }

        public SerilogFile log { get; set; }

        //public Task<IResponse> GetMsgAsync()
        //{
        //    var toPn = "+18109648508";
        //    var fromPn = "+16103793312";
        //    MessageResource.ReadAsync(
        //        to:toPn,
        //        from:fromPn);
        //}

        public void Init()
        {
            TwilioClient.Init(acc_sid, auth_token);
            IsInitialized = true;
            log.LogIt("Twilio Client Initialized");
        }
        public async Task<IResponse> MessageAsync(string from, string to, string msg)
        {
            var fromPn = new PhoneNumber(from);
            var toPn = new PhoneNumber(to);
            try
            {
                var message = await MessageResource.CreateAsync(
                    toPn,
                    from: fromPn,
                    body: msg);
                return new MessageResponse(message);
            }
            catch (Exception e)
            {
                log.log.Error($"An error has occurred while attempting to send a message resource. || Error: {e}");
            }

            return null;
            
        }

        

        public Task<IResponse> SendSmsAsync(string from, string to, string msg)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Twilio API";
        }

        public class MessageResponse : IResponse
        {

            private string acc_sid;
            public string Status { get; set; }
            public bool CanUpdate { get { return true; } }

            public MessageResponse(MessageResource msg)
            {
                SetMessage(msg);
            }

            private void SetMessage(MessageResource msg)
            {
                acc_sid = msg.AccountSid;
                Status = msg.Status.ToString();
            }

            public async Task UpdateAsync()
            {
                var message = await MessageResource.FetchAsync(acc_sid);
                SetMessage(message);
            }
        }
    }
}
