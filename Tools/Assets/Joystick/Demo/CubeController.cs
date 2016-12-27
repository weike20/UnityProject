using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    #region Fields / Properties
    public float speed = 2.5f;

    private Animator animator;
    private Vector3 direction;

    [System.Serializable]
    public class AnimatorHashID
    {
        [SerializeField]
        private string xRotation;
        [SerializeField]
        private string yRotation;
        [SerializeField]
        private string isMoving;

        public int XRotationSpeedFloat
        {
            get
            {
                return Animator.StringToHash(xRotation);
            }
        }
        public int YRotationSpeedFloat
        {
            get
            {
                return Animator.StringToHash(yRotation);
            }
        }
        public int IsMoving
        {
            get
            {
                return Animator.StringToHash(isMoving);
            }
        }
    }

    public AnimatorHashID hashID;
    #endregion

    #region MonoBehavoiur
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
        animator.SetFloat(hashID.XRotationSpeedFloat, direction.x,0.01f,Time.deltaTime);
        animator.SetFloat(hashID.YRotationSpeedFloat, direction.y,0.01f,Time.deltaTime);
    }
    #endregion

    #region  EventHandler

    public void OnBeginMove()
    {
        animator.SetBool(hashID.IsMoving, true);
    }

    public void UpdateDiretion(Vector3 direction)
    {
        this.direction = direction;
    }

    public void OnEndMove()
    {
        animator.SetBool(hashID.IsMoving, false);
        animator.SetFloat(hashID.XRotationSpeedFloat, 0f);
        animator.SetFloat(hashID.YRotationSpeedFloat, 0f);
        direction = Vector3.zero;
    }


       
    #endregion

}
