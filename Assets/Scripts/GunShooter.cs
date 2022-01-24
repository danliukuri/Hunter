using Infrastructure.InputServices;
using UnityEngine;
using Zenject;

public class GunShooter : MonoBehaviour
{
    #region Fields
    [SerializeField] ObjectsPool bulletsPool;
    [SerializeField] int numberOfBullets;

    IFireButtonInputService fireButtonInputService;
    #endregion

    #region Methods
    [Inject]
    public void Construct(IFireButtonInputService fireButtonInputService)
    {
        this.fireButtonInputService = fireButtonInputService;
        fireButtonInputService.FireButtonPressed += TryToFire;
    }
    void OnDestroy()
    {
        fireButtonInputService.FireButtonPressed -= TryToFire;
    }

    void TryToFire()
    {
        if (numberOfBullets > 0)
        {
            numberOfBullets--;
            Fire();
        }
    }
    void Fire()
    {
        GameObject gameObject = bulletsPool.GetFreeObject();

        Transform gameObjectTransform = gameObject.transform;
        gameObjectTransform.SetParent(transform.parent);
        gameObjectTransform.rotation = transform.rotation;
        gameObjectTransform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y + transform.localScale.y / 2f + gameObjectTransform.localScale.y / 2f,
            transform.localPosition.z);
        gameObjectTransform.SetParent(bulletsPool.ObjectsParent);

        gameObject.SetActive(true);
    }
    #endregion
}