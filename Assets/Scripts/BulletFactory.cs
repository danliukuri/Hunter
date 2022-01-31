using UnityEngine;

public class BulletFactory : MonoBehaviour, IBulletFactory
{
    #region Fields
    [SerializeField] ObjectsPool bulletsPool;
    #endregion

    #region Methods
    public GameObject Create(Transform gun)
    {
        GameObject gameObject = bulletsPool.GetFreeObject();

        Transform gameObjectTransform = gameObject.transform;
        gameObjectTransform.SetParent(gun.parent);
        gameObjectTransform.rotation = gun.rotation;
        gameObjectTransform.localPosition = new Vector3(
            gun.localPosition.x,
            gun.localPosition.y + gun.localScale.y / 2f + gameObjectTransform.localScale.y / 2f,
            gun.localPosition.z);
        gameObjectTransform.SetParent(bulletsPool.ObjectsParent);

        return gameObject;
    }
    #endregion
}