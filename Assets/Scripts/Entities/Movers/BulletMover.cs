using UnityEngine;

namespace Entities.Movers
{
    public class BulletMover : MonoBehaviour
    {
        #region Fields
        [SerializeField] float speed;
        #endregion

        #region Methods
        void Update()
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        #endregion
    }
}