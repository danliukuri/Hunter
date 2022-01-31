using Entities.Factories;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers.BootstrapInstallers
{
    public class ObjectsInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] GameObject bullets;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            BindBulletFactory();
        }

        void BindBulletFactory()
        {
            Container
                .Bind<BulletFactory>()
                .FromComponentInNewPrefab(bullets)
                .UnderTransform(transform)
                .AsSingle();
        }
        #endregion
    }
}