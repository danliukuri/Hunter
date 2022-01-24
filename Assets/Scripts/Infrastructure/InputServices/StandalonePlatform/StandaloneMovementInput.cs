using System;
using UnityEngine;

namespace Infrastructure.InputServices.StandalonePlatform
{
    public class StandaloneMovementInput : MonoBehaviour, IMovementInputService
    {
        #region Fields
        const string horizontalAxisName = "Horizontal";
        const string verticalAxisName = "Vertical";
        const int defaultAxisValue = 0;

        public event Action<float> HorizontalAxisValueChanging;
        public event Action<float> VerticalAxisValueChanging;
        #endregion

        #region Methods
        void Update()
        {
            TrackHorizontalAxisValueChange();
            TrackVerticalAxisValueChange();
        }

        void TrackHorizontalAxisValueChange()
        {
            float horizontalAxisValue = Input.GetAxis(horizontalAxisName);
            if (horizontalAxisValue != defaultAxisValue)
                HorizontalAxisValueChanging?.Invoke(horizontalAxisValue);
        }
        void TrackVerticalAxisValueChange()
        {
            float verticalAxisValue = Input.GetAxis(verticalAxisName);
            if (verticalAxisValue != defaultAxisValue)
                VerticalAxisValueChanging?.Invoke(verticalAxisValue);
        }
        #endregion
    }
}