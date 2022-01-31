using Entities.Weapons.Ammunition;
using Infrastructure.InputServices;
using UnityEngine;
using Zenject;

namespace Entities.Weapons
{
    public class GunShooter : MonoBehaviour
    {
        #region Fields
        IAmmunition ammunition;
        IFireButtonInputService fireButtonInputService;
        #endregion

        #region Methods
        [Inject]
        public void Construct(IFireButtonInputService fireButtonInputService)
        {
            this.fireButtonInputService = fireButtonInputService;
            fireButtonInputService.FireButtonPressed += TryToFire;
        }
        public void SetAmmunition(IAmmunition ammunition)
        {
            this.ammunition = ammunition;
        }

        void OnDestroy()
        {
            fireButtonInputService.FireButtonPressed -= TryToFire;
        }

        void TryToFire()
        {
            if (ammunition.HaveAnyBullets())
                Fire(ammunition.TryToGetBullet());
        }
        void Fire(GameObject bullet)
        {
            bullet.SetActive(true);
        }
        #endregion
    }
}