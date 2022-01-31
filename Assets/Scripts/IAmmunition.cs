using UnityEngine;

public interface IAmmunition
{
    #region Methods
    bool HaveAnyBullets();
    GameObject TryToGetBullet();
    #endregion
}