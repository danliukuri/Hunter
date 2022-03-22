using UnityEngine;

namespace Entities.SteeringBehaviors
{
    public class WanderSteeringBehavior : DesiredVelocityProvider
    {
        #region Fields
        [SerializeField, Range(0.5f, 5f)] float circleDistance = 2f;
        [SerializeField, Range(0.5f, 5f)] float circleRadius = 1f;

        [SerializeField, Range(1, 80)] int angleChangeStep = 5;
        int angle;
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            angle = Random.Range(0, 360);
        }

        public override Vector3 GetDesiredVelocity()
        {
            int randomSign = Random.value < 0.5f ? 1 : -1;
            angle += randomSign * angleChangeStep;

            float angleInRadians = angle * Mathf.Deg2Rad;
            Vector3 displacement = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * circleRadius;

            Vector3 futurePosition = transform.position + steeringMover.Velocity.normalized * circleDistance;

            //Debug.DrawRay(futurePosition, displacement, Color.red); // Displacement vector
            //Debug.DrawLine(transform.position, futurePosition, Color.magenta); // Circle center vector
            //Debug.DrawLine(transform.position, futurePosition + displacement, Color.blue); // Wander force vector

            Vector3 desiredVelocity = futurePosition + displacement - transform.position;
            return steeringMover.VelocityLimit * velocityMultiplier * desiredVelocity.normalized;
        }
        #endregion
    }
}