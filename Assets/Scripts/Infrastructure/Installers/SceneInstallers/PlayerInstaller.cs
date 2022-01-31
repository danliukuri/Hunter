using Entities.Movers;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers.SceneInstallers
{
    public class PlayerInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] Transform playerStartSpawnPoint;
        [SerializeField] GameObject playerPrefab;
        #endregion

        #region Methods
        public override void InstallBindings()
        {
            BindPlayer();
        }

        void BindPlayer()
        {
            Container
                .Bind<PlayerMover>()
                .FromComponentInNewPrefab(playerPrefab)
                .UnderTransform(playerStartSpawnPoint)
                .AsSingle();
        }
        #endregion
    }
}