using Infrastructure.InputServices;
using Infrastructure.InputServices.StandalonePlatform;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] StandaloneButtonsInput standaloneButtonsInputPrefab;
        [SerializeField] StandaloneMovementInput standaloneMovementInputPrefab;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            BindButtonsInputService();
            BindMovementInputService();
        }

        void BindButtonsInputService()
        {
            Container
              .Bind<IFireButtonInputService>()
              .FromComponentInNewPrefab(standaloneButtonsInputPrefab)
              .UnderTransform(transform)
              .AsSingle();
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