using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    #region Fields
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationalSpeed;
    #endregion

    #region Methods
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