using JetBrains.Annotations;
using Services.Interfaces;
using VContainer.Unity;

namespace Core
{
    [UsedImplicitly]
    public class Bootstrapper : IStartable
    {
        private readonly ISceneLoader _scenes;
        private readonly IGameConfig  _config;

        public Bootstrapper(ISceneLoader scenes, IGameConfig config)
        {
            _scenes = scenes;
            _config = config;
        }

        public void Start() => _scenes.Load(_config.ConnectionSceneName);
    }
}
