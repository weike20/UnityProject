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
        [SerializeField]
        private float wanderRadius = 1;
        [SerializeField]
        private float wanderDistance = 1;
        [SerializeField]
        private float wanderJitter = 1;
        [SerializeField]
        private float minDetectionBoxLength = 1;
        [SerializeField]
        private float obstacleAvoidanceIndensity = 5f;
        [SerializeField]
        private float distanceFromBoundary = 3f;
        [SerializeField]
        private float wayPointSeekDistanceSqr = 3f;


        private Vector3 wanderTarget = Vector3.zero;

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
            if(distance >= 0.1f)
            {
                float speed = distance / (decelerationMultiply * (float)deceleration);
                speed = Mathf.Min(speed, vehicle.MaxSpeed);
                Vector3 desiredVelocity = toTarget * speed / distance;
                return desiredVelocity - vehicle.ERigidbody.velocity;
            }
            return Vector3.zero;
           
        }
        public Vector3 Persuit(Vehicle evader)
        {
            Rigidbody eRigid = evader.ERigidbody;

            Vector3 toEvader = evader.transform.position - vehicle.transform.position;
            float relativeHeading = Vector3.Dot(vehicle.transform.forward, evader.transform.forward);
            if(Vector3.Dot(toEvader,vehicle.transform.forward) > 0 && relativeHeading<-0.95f)
            {
                return Seek(evader.transform.position);
            }

            float lookAheadTime = toEvader.magnitude / (vehicle.MaxSpeed + eRigid.velocity.magnitude);
            return Seek(evader.transform.position + eRigid.velocity * lookAheadTime);
        }
        public Vector3 Evade(Vehicle pursuer)
        {
            Vector3 toPursuer = pursuer.transform.position - vehicle.transform.position;
            float lookAheadTime = toPursuer.magnitude / (vehicle.MaxSpeed + pursuer.ERigidbody.velocity.magnitude);
            return Flee(pursuer.transform.position + pursuer.ERigidbody.velocity * lookAheadTime);
        }
        public Vector3 Wander()
        {
            float jitterThisTimeSlice = wanderJitter * Time.fixedDeltaTime;
            wanderTarget += new Vector3
                (Random.Range(-1f, 1f) * jitterThisTimeSlice,
                 Random.Range(-1f, 1f) * jitterThisTimeSlice,
                 Random.Range(-1f, 1f) * jitterThisTimeSlice
                );
            wanderTarget.Normalize();
            wanderTarget *= wanderRadius;
            Vector3 localTarget = wanderTarget + new Vector3(0, 0, wanderDistance);
            Vector3 worldTarget = vehicle.transform.TransformVector(localTarget);

            return worldTarget - vehicle.transform.position;
        }
        public Vector3 ObstacleAvoidance(RaycastHit hit,out float boxLength)
        {
            boxLength = (vehicle.Speed / vehicle.MaxSpeed) * minDetectionBoxLength + minDetectionBoxLength;
            float multiplier = 1 + (boxLength - hit.distance) / boxLength;
            return hit.normal * multiplier * obstacleAvoidanceIndensity;
        }
        
        public Vector3 Interpose(Vehicle agentA, Vehicle agentB)
        {
            Vector3 midPoint = (agentA.transform.position + agentB.transform.position) * 0.5f;
            Vector3 toMidPoint = midPoint - vehicle.transform.position;
            float timeToReachMidPoint = toMidPoint.magnitude / vehicle.MaxSpeed;
            Vector3 aPos = agentA.ERigidbody.velocity * timeToReachMidPoint + agentA.transform.position;
            Vector3 bPos = agentB.ERigidbody.velocity * timeToReachMidPoint + agentB.transform.position;

            midPoint = (aPos + bPos) / 2;
            return Arrive(midPoint,Deceleration.Fast);
        }
        public Vector3 Hide(Vehicle hunter, List<Collider> obstacles)
        {
            float distToClosest = float.MaxValue;
            Vector3 bestHidingSpot = Vector3.zero;
            for (int i= 0;i<obstacles.Count;++i)
            {
                Vector3 hidingSpot = GetHidingPoint(obstacles[i], hunter.transform.position);
                float distance = (hidingSpot - vehicle.transform.position).sqrMagnitude;
                if(distance < distToClosest)
                {
                    bestHidingSpot = hidingSpot;
                    distToClosest = distance;
                }
            }
            if(bestHidingSpot == Vector3.zero)
            {
                return Evade(hunter);
            }
            return Arrive(bestHidingSpot,Deceleration.Fast);
        }
        private Vector3 GetHidingPoint(Collider obstacle,Vector3 hunterPos)
        {
            Vector3 dir = (obstacle.transform.position - hunterPos).normalized;
            Bounds bounds = obstacle.bounds;
            float disAway = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
            return obstacle.transform.position + dir * (disAway + distanceFromBoundary);

        }
        public Vector3 FollowPath(Path path)
        {
            Vector3 toTarget = path.CurrentWayPoint.transform.position - vehicle.transform.position;
            if (toTarget.sqrMagnitude < wayPointSeekDistanceSqr && !path.CurrentWayPoint.isFinished)
            {
                path.SetNextWayPoint();
            }

            if (path.CurrentWayPoint.isFinished)
            {
                return Arrive(path.CurrentWayPoint.transform.position, Deceleration.Normal);
            }
            else
                return Seek(path.CurrentWayPoint.transform.position);
        }
        public Vector3 OffsetPersuit(Vehicle leader,Vector3 offset)
        {
            Vector3 worldOffsetPos = leader.transform.TransformVector(offset);
            Vector3 toOffsetPos = worldOffsetPos - vehicle.transform.position;
            float lookAheadTime = toOffsetPos.magnitude / (vehicle.MaxSpeed + leader.Speed);
            return Arrive(worldOffsetPos+leader.ERigidbody.velocity * lookAheadTime,Deceleration.Fast);
        }

        public Vector3 Separation(List<Vehicle> neighbors)
        {
            return Vector3.zero;
        }
        public Vector3 Alignment(List<Vehicle> neightbors)
        {
            return Vector3.zero;
        }
        public Vector3 Cohesion(List<Vehicle> neightbors)
        {
            return Vector3.zero;
        }
    }

}

