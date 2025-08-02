using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Network;
using Services.Interfaces;

namespace Services
{
    [UsedImplicitly]
    public class NetworkServiceMirror : INetworkService
    {
        public NetworkServiceMirror(CustomNetworkManager customNetworkManager) => _customNetworkManager = customNetworkManager;

        private readonly CustomNetworkManager _customNetworkManager;
        
        public void SetPlayerName(string nick)
        {
            _customNetworkManager.playerName = nick;
        }
        
        public async Task<bool> TryConnectAsClientAsync(string address, TimeSpan timeout)
        {
            var tcs = new TaskCompletionSource<bool>();

            void OnConnected()
            {
                tcs.TrySetResult(true);
            }
            
            CustomNetworkManager.OnClientConnected += OnConnected;

            if (!string.IsNullOrEmpty(address))
                _customNetworkManager.networkAddress = address;
            _customNetworkManager.StartClient();
            
            var finished = await Task.WhenAny(tcs.Task, Task.Delay(timeout));
            
            CustomNetworkManager.OnClientConnected -= OnConnected;
            
            return finished == tcs.Task && tcs.Task.Result;
        }

        public Task ConnectAsHostAsync()
        {
            _customNetworkManager.StartHost();
            return Task.CompletedTask;
        }

        public Task ConnectAsClientAsync(string address)
        {
            _customNetworkManager.networkAddress = address;
            _customNetworkManager.StartClient();
            return Task.CompletedTask;
        }
    }
}
