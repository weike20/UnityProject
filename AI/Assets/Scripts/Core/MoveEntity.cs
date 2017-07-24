using UnityEngine;
using System.Collections;

namespace ITGGame.AI
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class MoveEntity : BaseGameEntity
    {
        [SerializeField]
        private float maxSpeed;
        [SerializeField]
        private float maxForce;
        [SerializeField]
        private float maxTurnRate;

        private Rigidbody eRigidbody;

        public float Speed { get { return ERigidbody.velocity.magnitude; } }
        public float MaxSpeed { get { return maxSpeed; } set { maxSpeed = value; } }
        public float MaxForce { get { return maxForce; } set { maxForce = value; } }
        public float MaxTurnRate { get { return maxTurnRate; } set { maxTurnRate = value; } }
        public Rigidbody ERigidbody { get { return eRigidbody; } }

        public virtual void Start()
        {
            eRigidbody = GetComponent<Rigidbody>();
        }
    }

}
