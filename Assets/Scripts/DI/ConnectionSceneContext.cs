using UI.Presenters;
using UI.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class ConnectionSceneContext : LifetimeScope
    {
        [SerializeField] NameInputView nameInputView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(nameInputView);
            builder.RegisterEntryPoint<NameInputPresenter>();
        }
    }
}
