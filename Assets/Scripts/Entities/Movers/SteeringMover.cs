using Entities.SteeringBehaviors;
using UnityEngine;

namespace Entities.Movers
{
    public class SteeringMover : MonoBehaviour
    {
        #region Properties
        public float VelocityLimit => velocityLimit;
        public Vector3 Velocity => velocity;
        #endregion

        #region Fields
        const float VelocityEpsilon = 0.05f;
        const float FrictionForceMultiplier = 0.5f;

        [SerializeField, Range(1, 120)] float mass = 1f;

        [SerializeField, Range(1, 25)] float velocityLimit = 3f;
        [SerializeField, Range(1, 50)] float steeringForceLimit = 5f;

        DesiredVelocityProvider[] providers;

        Vector3 velocity;
        Vector3 acceleration;
        #endregion

        #region Methods
        void Awake()
        {
            providers = GetComponents<DesiredVelocityProvider>();
        }
        void Update()
        {
            CalculateVelocity();

            acceleration = Vector3.zero;
            ApplyForce(GetFrictionForce() + GetSteeringForce());

            MoveAndRotate();
        }

        public void ApplyForce(Vector3 force) => acceleration += force / mass;

        Vector3 GetFrictionForce() => -velocity.normalized * FrictionForceMultiplier;
        Vector3 GetSteeringForce()
        {
            Vector3 steering = Vector3.zero;
            foreach (DesiredVelocityProvider provider in providers)
            {
                Vector3 desiredVelocity = provider.GetDesiredVelocity();
                steering += desiredVelocity - velocity;
                //Debug.DrawRay(transform.position, desiredVelocity, Color.blue);
            }

            //Debug.DrawRay(transform.position, steering, Color.magenta);
            //Debug.DrawRay(transform.position, velocity, Color.red);
            //Debug.Log(velocity.magnitude);
            //Debug.DrawRay(transform.position, transform.forward * -0.5f, Color.green, 1000f); // Path

            return Vector3.ClampMagnitude(steering - velocity, steeringForceLimit);
        }

        void CalculateVelocity()
        {
            velocity += acceleration * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, velocityLimit);

            // On small values object might start to blink, so we considering small velocities as zeroes
            if (velocity.magnitude < VelocityEpsilon)
                velocity = Vector3.zero;
        }
        void MoveAndRotate()
        {
            if (velocity != Vector3.zero)
            {
                transform.position += velocity * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(transform.forward, velocity);
            }
        }
        #endregion
    }
}