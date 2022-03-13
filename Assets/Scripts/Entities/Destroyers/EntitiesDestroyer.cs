using UnityEngine;

namespace Entities.Destroyers
{
    public class EntitiesDestroyer : MonoBehaviour
    {
        #region Methods
        void OnTriggerExit2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
        #endregion
    }
}