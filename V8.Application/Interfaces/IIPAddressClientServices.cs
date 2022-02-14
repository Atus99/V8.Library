using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace V8.Application.Interfaces
{
    public interface IIPAddressClientServices
    {
        Task<bool> GetPublicIPAddress();
    }
}
