using Infrastructure.InputServices;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] StandaloneMovementInput standaloneMovementInputPrefab;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            BindMovementInputService();
        }

        void BindMovementInputService()
        {
            Container
              .Bind<IMovementInputService>()
              .FromComponentInNewPrefab(standaloneMovementInputPrefab)
              .UnderTransform(transform)
              .AsSingle();
        }
        #endregion
    }
}