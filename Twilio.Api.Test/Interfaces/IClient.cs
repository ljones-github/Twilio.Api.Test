using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twilio.Api.Test.Interfaces
{
    public interface IClient
    {
        bool IsInitialized { get; set; }

        bool CanSendSms { get;}

        bool CanCall { get;}

        bool FromNumberRequired { get; }

        void Init();

        Task<IResponse> MessageAsync(string from, string to, string msg);

        Task<IResponse> SendSmsAsync(string from, string to, string msg);

        //Task<IResponse> GetMsgAsync();

        string ToString();
    }
}
