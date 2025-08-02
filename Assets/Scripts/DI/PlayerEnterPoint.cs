using System;
using GameLogic.Presenters;
using GameLogic.Views;
using JetBrains.Annotations;
using Services.Interfaces;
using VContainer.Unity;

namespace DI
{
    [UsedImplicitly]
    public class PlayerEnterPoint : IInitializable, IDisposable
    {
        private readonly IInputService _input;
        private PlayerPresenter _playerPresenter;
        private readonly PlayerView _playerView;
        private readonly IGameConfig _config;

        public PlayerEnterPoint( IInputService input,PlayerView playerView,IGameConfig config)
        {
            _input = input;
            _playerView = playerView;
            _config = config;
        }

        public void Initialize()
        {
            _playerPresenter = new PlayerPresenter( _playerView, _input, _config);
            _playerPresenter.Initialize();
        }

        public void Dispose()
        {
            _playerPresenter?.Dispose();
        }
    }
}
