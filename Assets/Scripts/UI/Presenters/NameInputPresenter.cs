using System;
using JetBrains.Annotations;
using Services.Interfaces;
using UI.Views;
using UnityEngine;
using VContainer.Unity;

namespace UI.Presenters
{
    [UsedImplicitly]
    public class NameInputPresenter : IStartable, IDisposable
    {
        private readonly NameInputView _view;
        private readonly INetworkService _network;
        private readonly ISceneLoader _sceneLoader;
        private readonly float _clientTimeoutMs; 
        private readonly IGameConfig _config;

        public NameInputPresenter(NameInputView view, INetworkService network, ISceneLoader sceneLoader,IGameConfig config)
        {
            _view = view;
            _network = network;
            _sceneLoader = sceneLoader;
            _config = config;
            _clientTimeoutMs = _config.ClientTimeoutMs;
        }

        public void Start() => _view.OnConnectClicked += HandleConnect;

        private async void HandleConnect(string nick, string address)
        {
            _view.SetInteractable(false);
            
            _network.SetPlayerName(nick);
            
            bool isClient = await _network.TryConnectAsClientAsync(
                address, TimeSpan.FromMilliseconds(_clientTimeoutMs));

            if (isClient)
                Debug.Log("Подключились как клиент");
            else
            {
                Debug.Log("Не удалось клиенту - поднимаем хост");
                await _network.ConnectAsHostAsync();
            }
            
            _sceneLoader.Load(_config.GameSceneName);
        }
        
        public void Dispose() => _view.OnConnectClicked -= HandleConnect;
    }
}