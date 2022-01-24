using System;
using UnityEngine;

namespace Infrastructure.InputServices.StandalonePlatform
{
    class StandaloneButtonsInput : MonoBehaviour, IFireButtonInputService
    {
        #region FireButtonServiceFields
        const string fireButtonName = "Fire1";

        public event Action FireButtonReleased;
        public event Action FireButtonPressed;
        #endregion

        #region CommonMethods
        void Update()
        {
            TrackFireButtonRelease();
            TrackFireButtonPress();
        }
        #endregion

        #region FireButtonServiceMethods
        void TrackFireButtonRelease()
        {
            if (Input.GetButtonUp(fireButtonName))
                FireButtonReleased?.Invoke();
        }
        void TrackFireButtonPress()
        {
            if (Input.GetButtonDown(fireButtonName))
                FireButtonPressed?.Invoke();
        }
        #endregion
    }
}