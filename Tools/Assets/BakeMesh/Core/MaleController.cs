using UnityEngine;
using System.Collections;

public class MaleController : MonoBehaviour
{
    #region Fields / Propertes
    private Animator anim;

    private static int speedFloat = Animator.StringToHash("Speed");
    const float SPEED_DAMP_TIME = 0.01f;
    #endregion

    #region MonoBehavior
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            anim.SetFloat(speedFloat, h, SPEED_DAMP_TIME, Time.deltaTime);
        }
    }
    #endregion
}
