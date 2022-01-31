using System;
using UnityEngine;
using Zenject;

namespace Infrastructure
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
            PlayerMover player = InstantiatePlayer();
            BindPlayer(player);
        }

        PlayerMover InstantiatePlayer()
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
        #endregion
    }
}