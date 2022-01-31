using Entities.Factories;
using Entities.Movers;
using Entities.Weapons;
using Entities.Weapons.Ammunition;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers.SceneInstallers
{
    public class GunInstaller : MonoInstaller, IInitializable
    {
        #region Fields
        [SerializeField] GameObject gunPrefab;
        [SerializeField] GameObject ammunitionPrefab;

        BulletFactory bulletFactory;
        #endregion

        #region Methods
        [Inject]
        public void Construct(BulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GunInstaller>().FromInstance(this);
        }
        public void Initialize()
        {
            PlayerMover player = Container.Resolve<PlayerMover>();
            InstantiateGunForPlayer(player.transform);
        }

        void InstantiateGunForPlayer(Transform player)
        {
            GunShooter gun = Container
                .InstantiatePrefabForComponent<GunShooter>(gunPrefab, player);

            Ammunition ammunition = Container
                .InstantiatePrefabForComponent<Ammunition>(ammunitionPrefab, gun.transform);

            ammunition.SetBulletFactory(bulletFactory);
            gun.SetAmmunition(ammunition);
        }
        #endregion
    }
}