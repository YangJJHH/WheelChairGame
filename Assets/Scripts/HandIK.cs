using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : MonoBehaviour
{
    Animator anim;
    public Transform leftIK;
    public Transform rightIK;
    [HideInInspector]public float dampWeight = 0.0f;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    private void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, dampWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, dampWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, dampWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, dampWeight);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftIK.position);
        //anim.SetIKRotation(AvatarIKGoal.LeftHand, leftIK.rotation);
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightIK.position);
        //anim.SetIKRotation(AvatarIKGoal.RightHand, rightIK.rotation);
    }
}
