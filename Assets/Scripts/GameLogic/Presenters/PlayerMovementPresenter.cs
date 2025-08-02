using System;
using GameLogic.Views;
using Services.Interfaces;
using TickerUpdate;
using TickerUpdate.Interfaces;
using UnityEngine;

namespace GameLogic.Presenters
{
    public class PlayerMovementPresenter : IFixedUpdateable, IDisposable
    {
        public event Action<bool> OnAnimationUpdate;
        
        private readonly Rigidbody _rigidbody;
        private readonly Transform _transform;
        private readonly IInputService _input;
        private readonly float _moveSpeed;
        private readonly float _rotateSensitivity;

        public PlayerMovementPresenter(IInputService input, PlayerView playerView,IGameConfig config)
        {
            _input = input;
            _rigidbody = playerView.PlayerRigidbody;
            _transform = _rigidbody.transform;
            _moveSpeed   = config.MoveSpeed;
            _rotateSensitivity = config.MouseSensitivity;
            Ticker.RegisterFixedUpdateable(this);
        }
        
        public void OnFixedUpdate()
        {
            Vector2 look = _input.LookDelta;
            float yaw = look.x * _rotateSensitivity * Time.deltaTime;
            
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(0f, yaw, 0f));
            
            Vector2 dir = _input.MoveDirection;
            OnAnimationUpdate?.Invoke(dir.sqrMagnitude > 0.01f);

            Vector3 right   = _transform.right;
            Vector3 forward = _transform.forward;

            Vector3 moveWorld = (right * dir.x + forward * dir.y)
                                * _moveSpeed;
            
            Vector3 vel = moveWorld + Vector3.up * _rigidbody.velocity.y;
            _rigidbody.velocity = vel;
        }
        
        public void Dispose()
        {
            Ticker.UnregisterFixedUpdateable(this);
        }
    }
}