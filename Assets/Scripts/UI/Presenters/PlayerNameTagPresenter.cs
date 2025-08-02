using System;
using GameLogic.Views;
using JetBrains.Annotations;
using VContainer.Unity;

namespace UI.Presenters
{
    [UsedImplicitly]
    public class PlayerNameTagPresenter : IStartable, IDisposable
    {
        private readonly PlayerNameTagView _playerNameTagView;
        private readonly PlayerView _playerView;

        public PlayerNameTagPresenter(PlayerNameTagView playerNameTagView, PlayerView playerView)
        {
            _playerNameTagView  = playerNameTagView;
            _playerView = playerView;
        }

        public void Start()
        {
            _playerView.UsernameChanged += OnNameChanged;
            OnNameChanged(_playerView.username);
        }

        private void OnNameChanged(string newName)
        {
            _playerNameTagView.SetName(newName, _playerView.isLocalPlayer);
        }

        public void Dispose()
        {
            _playerView.UsernameChanged -= OnNameChanged;
        }
    }
}
