using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class SwordGrilScript : MonoBehaviour
{

    //Mecanim动画组件
    private Animator mAnimator = null;
    //动画状态信息
    private AnimatorStateInfo mStateInfo;
    //定义状态常量值，前面不要带层名啊，否则无法推断动画状态
    private const string IdleState = "Empty";
    private const string Attack1State = "Attack3-1";
    private const string Attack2State = "Attack3-2";
    private const string Attack3State = "Attack3-3";
    private const string Attack4State = "Attack4"; 

    //定义玩家连击次数
    private int mHitCount = 0;
    public bool isActive;
    public Transform lookAtObj;
    public Transform rightHandObj;

    public GameObject LookObj;

    void Start()
    {
        //获取动画组件
        mAnimator = GetComponent<Animator>();
        //获取状态信息 
        mStateInfo = mAnimator.GetCurrentAnimatorStateInfo(1);
    }

    void Update()
    {
        mStateInfo = mAnimator.GetCurrentAnimatorStateInfo(1);
        //假设玩家处于攻击状态，且攻击已经完毕，则返回到Idle状态
        if (!mStateInfo.IsName(IdleState) && mStateInfo.normalizedTime >= 1F)
        {
            mAnimator.SetInteger("ActionID", 0);
            mHitCount = 0;
        }
        //假设按下鼠标左键，则開始攻击
        if (Input.GetMouseButtonDown(0))
        { 
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            mAnimator.SetTrigger("sk1");
        }
    }

    void Attack()
    {
        //获取状态信息
        mStateInfo = mAnimator.GetCurrentAnimatorStateInfo(1);
        //假设玩家处于Idle状态且攻击次数为0，则玩家依照攻击招式1攻击，否则依照攻击招式2攻击，否则依照攻击招式3攻击
        if (mStateInfo.IsName(IdleState) && mHitCount == 0 && mStateInfo.normalizedTime > 0.50F)
        {
            mAnimator.SetInteger("ActionID", 1);
            mHitCount = 1;

           
        }
        else if (mStateInfo.IsName(Attack1State) && mHitCount == 1 && mStateInfo.normalizedTime > 0.65F)
        {
            mAnimator.SetInteger("ActionID", 2);
            mHitCount = 2;
        }
        else if (mStateInfo.IsName(Attack2State) && mHitCount == 2 && mStateInfo.normalizedTime > 0.50F)
        {
            mAnimator.SetInteger("ActionID", 3);
            mHitCount = 3;
        } 
        else if (mStateInfo.IsName(Attack3State) && mHitCount == 3 && mStateInfo.normalizedTime > 0.55F)
        {
            mAnimator.SetInteger("ActionID", 4);
            mHitCount = 4;
        }
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (mAnimator)
        {
            if (isActive)
            {
                if (LookObj)
                {
                    mAnimator.SetLookAtWeight(1);
                    mAnimator.SetLookAtPosition(lookAtObj.position);

                }
                if (rightHandObj)
                {
                    mAnimator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    mAnimator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    mAnimator.SetIKPosition(AvatarIKGoal.RightFoot, rightHandObj.position);
                    mAnimator.SetIKRotation(AvatarIKGoal.RightFoot, rightHandObj.rotation);

                    
                }

            }
            else
            {
                mAnimator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
                mAnimator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
                mAnimator.SetLookAtWeight(0);
            }
        }
    }
}
