using System;
using GameLogic.Views;
using Services.Interfaces;

namespace GameLogic.Presenters
{
    public class PlayerPresenter : IDisposable
    {
        private PlayerMovementPresenter _playerMovementPresenter;
        
        private readonly CubeSpawnerView _spawnerView;
        private readonly PlayerView _playerViewModel;
        private readonly IInputService  _input;
        private PlayerAnimationPresenter _playerAnimationPresenter;
        private readonly IGameConfig _config;
        
        private readonly Action _onSpawnHandler;
        private readonly Action<string> _onNameChangedHandler;
        
        public PlayerPresenter(PlayerView playerViewModel, IInputService input,IGameConfig config)
        {
            _playerViewModel = playerViewModel;
            _input = input;
            _config = config;
        }
        
        public void Initialize()
        {
            _playerViewModel.UsernameChanged += _onNameChangedHandler;
            _playerMovementPresenter = new PlayerMovementPresenter(_input,_playerViewModel,_config);
            _playerAnimationPresenter = new PlayerAnimationPresenter(_playerViewModel,_playerMovementPresenter);
        }
        

        public void Dispose()
        {
            _playerMovementPresenter?.Dispose();
            _input.OnSpawnRequest -= _onSpawnHandler;
            _playerViewModel.UsernameChanged -= _onNameChangedHandler;
        }
    }
}
