using UnityEngine;

namespace Entities.Destroyers
{
    public class EntitiesDestroyer : MonoBehaviour
    {
        #region Methods
        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                collision.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}