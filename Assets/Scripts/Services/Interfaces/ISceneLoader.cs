using UnityEngine.SceneManagement;

namespace Services.Interfaces
{
    public interface ISceneLoader
    {
        void Load(string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
    }
}
