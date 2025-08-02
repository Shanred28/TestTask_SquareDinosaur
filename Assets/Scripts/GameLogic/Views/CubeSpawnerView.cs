using Mirror;
using UnityEngine;

namespace GameLogic.Views
{
    public class CubeSpawnerView : NetworkBehaviour
    {
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private float spawnDistance = 2f;
        
        public void RequestSpawn()
        {
            if (!isLocalPlayer) return;

            Vector3 pos = transform.position + transform.forward * spawnDistance;
            Quaternion rot = Quaternion.identity;
            CmdSpawnCube(pos, rot);
        }

        [Command]
        void CmdSpawnCube(Vector3 pos, Quaternion rot)
        {
            GameObject cube = Instantiate(cubePrefab, pos, rot);
            NetworkServer.Spawn(cube);
        }
    }
}
