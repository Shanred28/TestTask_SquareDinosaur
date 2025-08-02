using System.Collections.Generic;
using GameLogic.Views;
using Mirror;
using UnityEngine;

namespace Network
{
    public class CustomNetworkManager : NetworkManager
    {
        private struct AddPlayerNameMessage : NetworkMessage
        {
            public string Nick;
        }

        public static event System.Action OnClientConnected;
        
        [HideInInspector] public string playerName;

        private readonly Dictionary<NetworkConnectionToClient, string> nickCache =
            new Dictionary<NetworkConnectionToClient, string>();

        public override void Awake()
        {
            base.Awake();
            autoCreatePlayer = false;
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<AddPlayerNameMessage>(OnAddPlayerNameMessage, false);
        }

        public override void OnClientConnect()
        {
            base.OnClientConnect();
            var msg = new AddPlayerNameMessage { Nick = playerName };
            NetworkClient.Send(msg);

            OnClientConnected?.Invoke();
        }

        private void OnAddPlayerNameMessage(NetworkConnectionToClient conn, AddPlayerNameMessage msg)
        {
            nickCache[conn] = msg.Nick;
            SpawnPlayerForConnection(conn);
        }

        private void SpawnPlayerForConnection(NetworkConnectionToClient conn)
        {
            Transform start = GetStartPosition() ?? transform;

            var go = Instantiate(playerPrefab, start.position, start.rotation);
            
            var pv = go.GetComponent<PlayerView>();
            if (pv != null)
                pv.username = nickCache[conn];

            NetworkServer.AddPlayerForConnection(conn, go);
        }
    }
}