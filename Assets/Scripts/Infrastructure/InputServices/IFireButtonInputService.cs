using System;

namespace Infrastructure.InputServices
{
    public interface IFireButtonInputService
    {
        #region Events
        event Action FireButtonReleased;
        event Action FireButtonPressed;
        #endregion
    }
}