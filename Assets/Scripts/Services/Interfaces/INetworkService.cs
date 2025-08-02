using System;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface  INetworkService
    {
        void SetPlayerName(string nick);
        Task<bool> TryConnectAsClientAsync(string address, TimeSpan timeout);
        Task ConnectAsHostAsync();
    }
}
