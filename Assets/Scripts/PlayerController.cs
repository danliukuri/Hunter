using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Methods
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationalSpeed;
    #endregion

    #region
    void Update()
    {
        Move(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));
    }

    void Move(float verticalAxisvalue)
    {
        if (verticalAxisvalue != 0)
        {
            transform.Translate(0f, verticalAxisvalue * movementSpeed * Time.deltaTime, 0f);
        }
    }
    void Rotate(float horizontalAxisvalue)
    { 
        if (horizontalAxisvalue != 0)
        {
            transform.Rotate(0f, 0f, -horizontalAxisvalue * rotationalSpeed * Mathf.Rad2Deg * Time.deltaTime);
        }
    }
    #endregion
}