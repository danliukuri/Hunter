using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class PlayerInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] Transform playerStartSpawnPoint;
        [SerializeField] GameObject playerPrefab;

        [SerializeField] GameObject gunPrefab;
        [SerializeField] ObjectsPool bulletsPool;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            PlayerMover player = InstantiateAndBindPlayer();
            BindPlayer(player);

            BindObjectsPool();
            InstantiateGunForPlayer(player.transform);
        }

        PlayerMover InstantiateAndBindPlayer()
        {
            return Container
                .InstantiatePrefabForComponent<PlayerMover>(playerPrefab, playerStartSpawnPoint);
        }
        void BindPlayer(PlayerMover player)
        {
            Container
               .Bind<PlayerMover>()
               .FromInstance(player)
               .AsSingle();
        }
        void BindObjectsPool()
        {
            Container
                .Bind<ObjectsPool>()
                .FromInstance(bulletsPool)
                .AsSingle();
        }
        void InstantiateGunForPlayer(Transform player)
        {
            Container.InstantiatePrefabForComponent<GunShooter>(gunPrefab, player);
        }
        #endregion
    }
}