using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twilio.Api.Test.Interfaces
{
    public interface IResponse
    {

        string Status { get; set; }

        bool CanUpdate { get; }

        Task UpdateAsync();
    }
}
