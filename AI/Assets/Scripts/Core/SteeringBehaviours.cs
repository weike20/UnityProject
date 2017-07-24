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
        private float decelerationMultiply = 0.3f;
        [SerializeField]
        private float wanderRadius = 1.2f;
        [SerializeField]
        private float wanderDistance = 2f;
        [SerializeField]
        private float wanderJitter = 10;
        [SerializeField]
        private float minDetectionBoxLength = 1;
        [SerializeField]
        private float obstacleAvoidanceIndensity = 5f;
        [SerializeField]
        private float distanceFromBoundary = 3f;
        [SerializeField]
        private float wayPointSeekDistanceSqr = 3f;

        [SerializeField]
        public SumingMethod sumingMethod = SumingMethod.Prioritized;
        [SerializeField]
        public Deceleration deceleration = Deceleration.Fast;

        [SerializeField]
        private float weightSeek = 1f;
        [SerializeField]
        private float weightFlee = 1f;
        [SerializeField]
        private float weightArrive = 1f;
        [SerializeField]
        private float weightWander = 1f;
        [SerializeField]
        private float weghtCohesion = 1f;
        [SerializeField]
        private float weightSeparation = 1f;
        [SerializeField]
        private float weightAllignment = 1;
        [SerializeField]
        private float weightObstacleAvoidance = 1f;
        [SerializeField]
        private float weightFollowPath = 1f;
        [SerializeField]
        private float weightPersuit = 1f;
        [SerializeField]
        private float weightEvade = 1f;
        [SerializeField]
        private float weightInterpose = 1f;
        [SerializeField]
        private float weightHide = 1f;
        [SerializeField]
        private float weightOffsetPursuit = 1f;

        private Vector3 wanderTarget = Vector3.zero;
        private Vector3 steerForce = Vector3.zero;
        private int mFlags;

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
        public Vector3 TargetPos { get; set; }
        public Vehicle Agent { get; set; }
        
        public SteeringBehaviours(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }
        public Vector3 Calculate()
        {
            steerForce = Vector3.zero;

            switch (sumingMethod)
            {

                case SumingMethod.WeightedAverage:
                    steerForce = CalculateWeightedSum();
                    break;
                case SumingMethod.Prioritized:
                    steerForce = CalculatePrioritized();
                    break;
                case SumingMethod.Dithered:
                    steerForce = CalculateDithered();
                    break;

            }
            return steerForce;

        }
        public void TurnOn(BehaviourType behaviour)
        {
            mFlags |= (int)behaviour;
        }
        public void TurnOff(BehaviourType behaviour)
        {
            mFlags ^= (int)behaviour;
        }
        public bool On(BehaviourType behaviour)
        {
            int value = (int)behaviour;
            return (value & mFlags) == value;
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
                Vector3 desiredVelocity = vehicle.MaxSpeed * Vector3.Normalize(vehicle.transform.position - targetPos);
                result = desiredVelocity - vehicle.ERigidbody.velocity;
            }
            return result;
        }

        public Vector3 Arrive(Vector3 targetPos, Deceleration deceleration)
        {
            Vector3 toTarget = targetPos - vehicle.transform.position;
            float distance = toTarget.magnitude;
            if(distance >= 0f)
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
            Vector3 worldTarget = vehicle.transform.TransformPoint(localTarget);

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
            Vector3 steerForce = Vector3.zero;
            neighbors.ForEach(item => 
            {
                if(item != vehicle && item.TagNeighbor)
                {
                    Vector3 toVehicle = vehicle.transform.position - item.transform.position;
                    steerForce += toVehicle.normalized / toVehicle.magnitude;
                }
            });
            return steerForce;
        }
        public Vector3 Alignment(List<Vehicle> neightbors)
        {
            Vector3 averageHeading = Vector3.zero;
            int neighborsCount = 0;
            neightbors.ForEach(item => 
            {
                if(item != vehicle && item.TagNeighbor)
                {
                    averageHeading += item.transform.forward;
                    ++neighborsCount;
                }
            });
            if(neighborsCount>0)
            {
                averageHeading /= neighborsCount;
                averageHeading -= vehicle.transform.forward;
            }

            return averageHeading;
        }
        public Vector3 Cohesion(List<Vehicle> neightbors)
        {
            Vector3 centerOfMass = Vector3.zero;
            Vector3 steeringForce = Vector3.zero;

            int neighborsCount = 0;
            neightbors.ForEach(item => 
            {
                if (item != vehicle && item.TagNeighbor)
                {
                    centerOfMass += item.transform.position;
                    ++neighborsCount;
                }
            });

            if(neighborsCount>0)
            {
                centerOfMass /= neighborsCount;
                steeringForce = Seek(centerOfMass);
            }
            return steeringForce;
        }

        private Vector3 CalculateWeightedSum()
        {
            if(On(BehaviourType.Seek))
                steerForce += Seek(TargetPos) * weightSeek;
            if(On(BehaviourType.Flee))
                steerForce += Flee(TargetPos) * weightFlee;
            if(On(BehaviourType.Arrive))
                steerForce += Arrive(TargetPos,deceleration) * weightArrive;
            if (On(BehaviourType.Pursuit))
                steerForce += Persuit(Agent) * weightPersuit;
            if (On(BehaviourType.Evade))
                steerForce += Evade(Agent) * weightEvade;
            if (On(BehaviourType.Wander))
                steerForce += Wander() * weightWander;
//             if(On(BehaviourType.ObstacleAvoidance))
//                 steerForce += ObstacleAvoidance()
            if(steerForce.sqrMagnitude >= vehicle.MaxForce*vehicle.MaxForce)
            {
                steerForce = steerForce.normalized * vehicle.MaxForce;
            }
            return steerForce;
        }
        private Vector3 CalculatePrioritized()
        {
            return Vector3.zero;
        }
        private Vector3 CalculateDithered()
        {
            return Vector3.zero;
        }

    }

}

