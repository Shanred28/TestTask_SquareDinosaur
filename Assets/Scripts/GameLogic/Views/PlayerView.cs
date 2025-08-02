using System;
using Mirror;
using UnityEngine;

namespace GameLogic.Views
{
    public class PlayerView : NetworkBehaviour
    {
        public Animator Animator => animator;
        public Rigidbody PlayerRigidbody => playerRigidbody;
        
        [SerializeField] private Animator animator;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private Rigidbody playerRigidbody;

        [SyncVar(hook = nameof(OnUsernameChanged))]
        public string username;

        public event Action<string> UsernameChanged;

        void OnUsernameChanged(string oldName, string newName) => UsernameChanged?.Invoke(newName);
        
        
        public override void OnStartClient()
        {
            base.OnStartClient();
            if (!isLocalPlayer)
                Destroy(playerCamera.gameObject);
        }
        
        [Command]
        public void CmdPerformAction()
        {
            RpcOnAction(username);
        }

        [ClientRpc]
        private void RpcOnAction(string nick)
        {
            Debug.Log($"Игрок {nick} нажал Space!");
        }
    }
}