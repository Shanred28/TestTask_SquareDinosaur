using System;
using JetBrains.Annotations;
using Services.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Services
{
    [UsedImplicitly]
    public class InputService : IInputService, IDisposable, IStartable
    {
        public Vector2 MoveDirection => _controls.Gameplay.Move.ReadValue<Vector2>();
        public Vector2 LookDelta     => _controls.Gameplay.Look.ReadValue<Vector2>();
        
        public event Action OnSpawnRequest;
        public event Action OnSendMessage;
    
        private readonly PlayerControls _controls;
        private Vector2 _cachedMove;
    
        public InputService()
        {
            _controls = new PlayerControls();
        
            _controls.Gameplay.Spawn.performed  += ctx => OnSpawnRequest?.Invoke();
            _controls.Gameplay.SendMessage.performed += ctx => OnSendMessage?.Invoke();
        
            _controls.Gameplay.Enable();
        }
    
        public void Start()  => _controls.Enable();
    
        public void Dispose()
        {
            _controls.Disable();
            _controls.Dispose();
        }
    }
}
