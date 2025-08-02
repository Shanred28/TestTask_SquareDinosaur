using System;
using GameLogic.Views;
using JetBrains.Annotations;
using Services.Interfaces;
using VContainer.Unity;

namespace GameLogic.Presenters
{
    [UsedImplicitly]
    public class CubeSpawnerPresenter : IStartable, IDisposable
    {
        private readonly IInputService _input;
        private readonly CubeSpawnerView _spawnerView;

        public CubeSpawnerPresenter(IInputService input, CubeSpawnerView spawnerView)
        {
            _input = input;
            _spawnerView = spawnerView;
        }

        public void Start()
        {
            _input.OnSpawnRequest += HandleSpawn;
        }

        private void HandleSpawn()
        {
            if (_spawnerView.isLocalPlayer)
                _spawnerView.RequestSpawn();
        }

        public void Dispose()
        {
            _input.OnSpawnRequest -= HandleSpawn;
        }
    }
}
