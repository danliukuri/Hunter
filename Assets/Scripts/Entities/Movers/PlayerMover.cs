using Infrastructure.InputServices;
using UnityEngine;
using Zenject;

namespace Entities.Movers
{
    public class PlayerMover : MonoBehaviour
    {
        #region Fields
        [SerializeField] float movementSpeed;
        [SerializeField] float rotationalSpeed;

        IMovementInputService movementInputService;
        #endregion

        #region Methods
        [Inject]
        public void Construct(IMovementInputService movementInputService)
        {
            this.movementInputService = movementInputService;
        }
        private void OnEnable()
        {
            movementInputService.HorizontalAxisValueChanging += Rotate;
            movementInputService.VerticalAxisValueChanging += Move;
        }
        private void OnDisable()
        {
            movementInputService.HorizontalAxisValueChanging -= Rotate;
            movementInputService.VerticalAxisValueChanging -= Move;
        }

        void Move(float verticalAxisvalue)
        {
            transform.Translate(0f, verticalAxisvalue * movementSpeed * Time.deltaTime, 0f);
        }
        void Rotate(float horizontalAxisvalue)
        {
            transform.Rotate(0f, 0f, -horizontalAxisvalue * rotationalSpeed * Mathf.Rad2Deg * Time.deltaTime);
        }
        #endregion
    }
}