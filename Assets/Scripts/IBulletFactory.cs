using UnityEngine;

public interface IBulletFactory
{
    #region Methods
    GameObject Create(Transform gun);
    #endregion
}