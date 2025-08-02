using System;
using GameLogic.Views;
using JetBrains.Annotations;
using Services.Interfaces;
using VContainer.Unity;

namespace GameLogic.Presenters
{
    [UsedImplicitly]
    public class PlayerActionPresenter : IStartable, IDisposable
    {
        private readonly IInputService _input;
        private readonly PlayerView _playerView;

        public PlayerActionPresenter(IInputService input, PlayerView  playerView)
        {
            _input = input;
            _playerView = playerView;
        }

        public void Start()
        {
            _input.OnSendMessage += HandleSend;
        }

        private void HandleSend()
        {
            if (_playerView.isLocalPlayer)
                _playerView.CmdPerformAction();
        }

        public void Dispose()
        {
            _input.OnSendMessage -= HandleSend;
        }
    }
}