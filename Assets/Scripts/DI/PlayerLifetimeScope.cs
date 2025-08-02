using GameLogic.Presenters;
using GameLogic.Views;
using Mirror;
using UI.Presenters;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class PlayerLifetimeScope : LifetimeScope
    {
        [SerializeField] private PlayerNameTagView nameTagView; 
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(gameObject.GetComponent<NetworkBehaviour>()).As<NetworkBehaviour>();
            builder.RegisterInstance(gameObject.GetComponent<CubeSpawnerView>()).As<CubeSpawnerView>();
            builder.RegisterInstance(gameObject.GetComponent<PlayerView>()).As<PlayerView>().As<NetworkBehaviour>();
            builder.RegisterInstance(nameTagView).As<PlayerNameTagView>();
            
            builder.RegisterEntryPoint<PlayerEnterPoint>();
            builder.RegisterEntryPoint<CubeSpawnerPresenter>();
            builder.RegisterEntryPoint<PlayerActionPresenter>();
            builder.RegisterEntryPoint<PlayerNameTagPresenter>();
        }
    }
}
