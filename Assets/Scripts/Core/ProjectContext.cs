using Mirror;
using Network;
using Services;
using Services.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class ProjectContext : LifetimeScope
    {
        [SerializeField] private GameConfig gameConfig; 
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance<IGameConfig>(gameConfig);
            builder
                .RegisterComponentInHierarchy<CustomNetworkManager>()
                .As<NetworkManager>()
                .As<CustomNetworkManager>();
            
            builder.Register<INetworkService, NetworkServiceMirror>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<Bootstrapper>();
        }
    }
}
