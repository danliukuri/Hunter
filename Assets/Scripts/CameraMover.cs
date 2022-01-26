using UnityEngine;
using Zenject;

public class CameraMover : MonoBehaviour
{
    #region Fields
    Transform targetTransform;
    Vector3 offset;
    #endregion

    #region Methods
    [Inject]
    public void Construct(PlayerMover player)
    {
        targetTransform = player.transform;
    }
    void Awake()
    {
        offset = transform.position - targetTransform.position;
    }
    void LateUpdate()
    {
        transform.position = targetTransform.position + offset;
    }
    #endregion
}