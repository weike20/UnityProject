using UnityEngine;
using System.Collections;

namespace ITGGame.AI
{
    public class Vehicle : MoveEntity
    {
        [SerializeField]
        public SteeringBehaviours behaviour;

        public Transform target;

        public override void Awake()
        {
            base.Awake();
            behaviour = new SteeringBehaviours(this);
        }

        void FixedUpdate()
        {
            Vector3 force = Vector3.zero;

            //force = behaviour.Seek(target.position);
            //force = behaviour.Flee(target.transform.position);
            //force = behaviour.Arrive(target.transform.position, Deceleration.Fast);

            //force = behaviour.Wander();
            //Quaternion targetRot = Quaternion.LookRotation(force.normalized,transform.up);
            //transform.rotation = Quaternion.SlerpUnclamped(transform.rotation,targetRot,Time.fixedDeltaTime);

            ERigidbody.AddForce(force);
        }
       

    }
}


