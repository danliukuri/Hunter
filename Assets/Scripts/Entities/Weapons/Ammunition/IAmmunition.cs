using UnityEngine;

namespace Entities.Weapons.Ammunition
{
    public interface IAmmunition
    {
        #region Methods
        bool HaveAnyBullets();
        GameObject TryToGetBullet();
        #endregion
    }
}