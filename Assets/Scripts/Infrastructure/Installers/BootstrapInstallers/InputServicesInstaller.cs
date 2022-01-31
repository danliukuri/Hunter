using Infrastructure.InputServices;
using System;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers.BootstrapInstallers
{
    public class InputServicesInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] GameObject inputServicesPrefab;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            BindInputServices(GetInputServiceTypes());
        }
        void BindInputServices(Type[] inputServiceTypes)
        {
            Container
              .Bind(inputServiceTypes)
              .FromComponentInNewPrefab(inputServicesPrefab)
              .AsSingle();
        }

        Type[] GetInputServiceTypes() => new Type[]
        {
            typeof(IFireButtonInputService),
            typeof(IMovementInputService)
        };
        #endregion
    }
}