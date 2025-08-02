using GameLogic.Views;
using UnityEngine;

namespace GameLogic.Presenters
{
    public class PlayerAnimationPresenter
    {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private readonly PlayerView   _view;
        
        Vector2 _currentInput;
        public PlayerAnimationPresenter(PlayerView view,PlayerMovementPresenter playerMovementPresenter)
        {
            playerMovementPresenter.OnAnimationUpdate += AnimationUpdate;
            _view  = view;
        }
        
        private void AnimationUpdate(bool isRunning)
        {
            if (!_view.isLocalPlayer) 
                return;
            
            _view.Animator.SetBool(IsRunning, isRunning);
        }
    }
}
