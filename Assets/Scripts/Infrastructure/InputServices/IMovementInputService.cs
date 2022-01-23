using System;

namespace Infrastructure.InputServices
{
    public interface IMovementInputService
    {
        #region Events
        public event Action<float> HorizontalAxisValueChanging;
        public event Action<float> VerticalAxisValueChanging;
        #endregion
    }
}