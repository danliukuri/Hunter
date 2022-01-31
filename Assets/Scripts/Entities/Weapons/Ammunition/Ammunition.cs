using Entities.Factories;
using UnityEngine;
using Zenject;

namespace Entities.Weapons.Ammunition
{
    public class Ammunition : MonoBehaviour, IAmmunition
    {
        #region Fields
        [SerializeField] int numberOfBullets;

        Transform gun;
        IBulletFactory bulletFactory;
        #endregion

        #region Methods
        [Inject]
        public void Construct()
        {
            gun = transform.parent;
        }
        public void SetBulletFactory(IBulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        public bool HaveAnyBullets() => numberOfBullets > 0;
        public GameObject TryToGetBullet()
        {
            GameObject bullet = default;
            if (HaveAnyBullets())
                bullet = GetBullet();
            return bullet;
        }
        GameObject GetBullet()
        {
            numberOfBullets--;
            return bulletFactory.Create(gun);
        }
        #endregion
    }
}