using UnityEngine;

namespace Entities.Factories
{
    public interface IBulletFactory
    {
        #region Methods
        GameObject Create(Transform gun);
        #endregion
    }
}