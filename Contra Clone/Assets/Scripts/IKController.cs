using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour {

    protected Animator animator;

    public bool barShooting = false;
    public bool sliding = false;

    public Transform rightHandOnGun;
    public Transform leftHandOnGun;
    public Transform rightHandHanging;
    public Transform leftHandHanging;
    
    
    // Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}

    //a callback for calculating IK
    private void OnAnimatorIK()
    {
        if (animator)
        {
            if (barShooting)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandHanging.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandHanging.rotation);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandHanging.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandHanging.rotation);
            }

            //Debug.Log("test");
        }
    }
}
