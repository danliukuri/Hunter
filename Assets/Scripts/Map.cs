using UnityEngine;

public class Map : MonoBehaviour
{
    #region Methods
    void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);    
    }
    #endregion
}