using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Fields
    [SerializeField] Transform targetTransform;
    Vector3 offset;
    #endregion

    #region Methods
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