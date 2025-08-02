using JetBrains.Annotations;
using Services.Interfaces;
using UnityEngine.SceneManagement;

namespace Core
{
    [UsedImplicitly]
    public class SceneLoader : ISceneLoader
    {
        public void Load(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
            => SceneManager.LoadScene(sceneName, mode);
    }
}
