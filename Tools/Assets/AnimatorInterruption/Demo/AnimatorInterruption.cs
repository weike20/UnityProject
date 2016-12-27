using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimatorInterruption : MonoBehaviour
{
    #region Fields / Properties
    [SerializeField] Animator animator;



    private List<int> animatorHashNames = new List<int>();


    static int triggerAtoB = Animator.StringToHash("AToB");
    static int triggerAtoC = Animator.StringToHash("AToC");
    static int triggerAtoD = Animator.StringToHash("AToD");
    static int triggerBtoC = Animator.StringToHash("BToC");
    static int triggerBtoD = Animator.StringToHash("BToD");
    //static int triggerCtoD = Animator.StringToHash("CtoD");

    static int stateA = Animator.StringToHash("Base Layer A");
    static int stateB = Animator.StringToHash("Base Layer B");
    static int stateC = Animator.StringToHash("Base Layer C");
    static int stateD = Animator.StringToHash("Base Layer D");
    #endregion

    #region MonoBehavoiur
    void Start()
    {
        AddHashNameToAnimator();
        //InterruptCurrentStateLab1();
        //InterruptCurrentStateLab2();
        //InterruptNextStateLab1();
        //InterruptNextStateLab2();

        PrintCurrentStateInfo();
    }

    #endregion

    #region Private
    private void AddHashNameToAnimator()
    {
        animatorHashNames.Add(stateA);
        animatorHashNames.Add(stateB);
        animatorHashNames.Add(stateC);
        animatorHashNames.Add(stateD);
    }
    private void InterruptCurrentStateLab1()
    {
        animator.SetTrigger(triggerAtoB);
        animator.SetTrigger(triggerAtoC);
    }
    private void InterruptCurrentStateLab2()
    {
        animator.SetTrigger(triggerAtoB);
        animator.SetTrigger(triggerAtoD);
    }
    private void InterruptNextStateLab1()
    {
        animator.SetTrigger(triggerAtoB);
        animator.SetTrigger(triggerBtoC);
    }
    private void InterruptNextStateLab2()
    {
        animator.SetTrigger(triggerAtoB);
        animator.SetTrigger(triggerBtoD);
    }

    //最后两种实验分别是选择CurrentStateThenNextState和NextStateThenCurrentState ，通过前两种都已近理解

    /// <summary>
    /// 打印当前状态机正在播放的动画变短
    /// </summary>
    private void PrintCurrentStateInfo()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);
        List<AnimatorClipInfo> clips = new List<AnimatorClipInfo>(clipInfos);
        AnimatorClipInfo clipInfo = clips.Find(info => state.IsName(info.clip.name));
        if(clipInfo.clip != null)
        {
            Debug.Log("实验的状态机当前状态是: " + clipInfo.clip.name);
        }    
    }
    #endregion
}
