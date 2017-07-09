using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace ITGGame.AI
{
    [System.Serializable]
    public class SteeringBehaviours 
    {
        private Vehicle vehicle;
        [SerializeField]
        private float panicDistanceSq = 5*5;
        [SerializeField]
        private float decelerationMultiply = 3;

        public float PanicDistanceSquare
        {
            get { return panicDistanceSq; }
            set { panicDistanceSq = value; }
        }
        public float DecelerationMultiply
        {
            get { return decelerationMultiply; }
            set { decelerationMultiply = value; }
        }
        
        public SteeringBehaviours(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }


        public Vector3 Seek(Vector3 targetPos)
        {
            Vector3 desiredVelocity = vehicle.MaxSpeed *Vector3.Normalize(targetPos - vehicle.transform.position);
            return desiredVelocity - vehicle.ERigidbody.velocity;
        }

        public Vector3 Flee(Vector3 targetPos)
        {
            Vector3 result = Vector3.zero;
            Vector3 toTarget = targetPos - vehicle.transform.position;
            if(toTarget.sqrMagnitude < panicDistanceSq)
            {
                result = -Seek(targetPos);
            }
            return result;
        }

        public Vector3 Arrive(Vector3 targetPos, Deceleration deceleration)
        {
            Vector3 toTarget = targetPos - vehicle.transform.position;
            float distance = toTarget.magnitude;
            float speed = distance / (decelerationMultiply * (float)deceleration);
            speed = Mathf.Min(speed, vehicle.MaxSpeed);
            Vector3 desiredVelocity = toTarget * speed / distance;
            
            return desiredVelocity - vehicle.ERigidbody.velocity;
        }
        public Vector3 Persuit(BaseGameEntity evader)
        {
            Vector3 toEvader = evader.transform.position - vehicle.transform.position;

            return Vector3.zero;
        }
        public Vector3 Evade(BaseGameEntity agent)
        {
            return Vector3.zero;
        }
        public Vector3 Wander()
        {
            return Vector3.zero;
        }
        public Vector3 Interpose(BaseGameEntity agentA, BaseGameEntity agentB)
        {
            return Vector3.zero;
        }
        public Vector3 Hide(BaseGameEntity hunter, List<BaseGameEntity> obstacles)
        {
            return Vector3.zero;
        }
        public Vector3 FollowPath(Path path)
        {
            return Vector3.zero;
        }
        public Vector3 OffsetPersuit(BaseGameEntity leader,Vector3 offset)
        {
            return Vector3.zero;
        }

        public Vector3 Separation(List<BaseGameEntity> neighbors)
        {
            return Vector3.zero;
        }
        public Vector3 Alignment(List<BaseGameEntity> neightbors)
        {
            return Vector3.zero;
        }
        public Vector3 Cohesion(List<BaseGameEntity> neightbors)
        {
            return Vector3.zero;
        }
    }

}

