using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class ObjectsInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] GameObject bullets;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            GameObject bullets = InstantiateBullets();
            BulletFactory bulletFactory = bullets.GetComponent<BulletFactory>();
            BindBulletFactory(bulletFactory);
        }
        GameObject InstantiateBullets()
        {
            return Container.InstantiatePrefab(bullets);
        }
        void BindBulletFactory(BulletFactory bulletFactory)
        {
            Container
                .Bind<BulletFactory>()
                .FromInstance(bulletFactory)
                .AsSingle();
        }
        #endregion
    }
}