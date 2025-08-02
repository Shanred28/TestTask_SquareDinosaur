using Services.Interfaces;
using UnityEngine;

namespace Services
{
    [CreateAssetMenu(menuName = "Configurations/GameConfig")]
    public class GameConfig : ScriptableObject, IGameConfig
    {
        [Header("Network")]
        [Tooltip("Таймаут ожидания подключения клиента (мс)")]
        public int clientTimeoutMs = 3000;

        [Header("Scenes")]
        public string connectionScene = "ConnectionScene";
        public string gameScene       = "GameScene";

        [Header("Controls")]
        [Tooltip("Скорость движения персонажа")]
        public float moveSpeed        = 5f;

        [Tooltip("Чувствительность мыши при вращении")]
        public float mouseSensitivity = 200f;
        
        int   IGameConfig.ClientTimeoutMs      => clientTimeoutMs;
        string IGameConfig.ConnectionSceneName => connectionScene;
        string IGameConfig.GameSceneName       => gameScene;
        float  IGameConfig.MoveSpeed           => moveSpeed;
        float  IGameConfig.MouseSensitivity    => mouseSensitivity;
    }
}
