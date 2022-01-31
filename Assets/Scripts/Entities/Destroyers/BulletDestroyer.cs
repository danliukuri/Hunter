using UnityEngine;

namespace Entities.Destroyers
{
    public class BulletDestroyer : MonoBehaviour
    {
        #region Methods
        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                collision.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}