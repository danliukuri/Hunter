using Entities.Movers;
using UnityEngine;

namespace Entities.SteeringBehaviors
{
    [RequireComponent(typeof(SteeringMover))]
    public abstract class DesiredVelocityProvider : MonoBehaviour
    {
        #region Fields
        [SerializeField, Range(0f, 10f)] protected float velocityMultiplier = 1f;

        protected SteeringMover steeringMover;
        #endregion

        #region Methods
        protected virtual void Awake()
        {
            steeringMover = GetComponent<SteeringMover>();
        }

        public abstract Vector3 GetDesiredVelocity();
        #endregion
    }
}