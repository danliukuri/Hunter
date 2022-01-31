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

        PlayerMover player;
        BulletFactory bulletFactory;
        #endregion

        #region Methods
        [Inject]
        public void Construct(BulletFactory bulletFactory, PlayerMover player)
        {
            this.bulletFactory = bulletFactory;
            this.player = player;
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GunInstaller>().FromInstance(this);
        }
        public void Initialize()
        {
            GunShooter gun = InstantiateGunForPlayer(player.transform);
            InstantiateAmmunitionForPlayerGun(gun);
        }

        GunShooter InstantiateGunForPlayer(Transform player)
        {
            return Container.InstantiatePrefabForComponent<GunShooter>(gunPrefab, player);
        }
        void InstantiateAmmunitionForPlayerGun(GunShooter gun)
        {
            Ammunition ammunition = Container
                .InstantiatePrefabForComponent<Ammunition>(ammunitionPrefab, gun.transform);
            ammunition.SetBulletFactory(bulletFactory);
            gun.SetAmmunition(ammunition);
        }
        #endregion
    }
}