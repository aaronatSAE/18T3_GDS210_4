using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour {

    protected Animator animator;

    public bool barShooting = false;
    public bool crouched = false;
    public bool gunActive = true;
    public bool machineGunActive = true;    

    public Transform machineGunFrontHandle;
    public Transform machineGunTriggerHandle;
    public Transform missileFrontHandle;
    public Transform missileTriggerHandle;

    public Transform handHangingHandle;

    private Transform rightHandOnGun;
    private Transform leftHandOnGun;    
    private Transform leftHandHanging;
    
    
    // Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}

    public void Update()
    {
        if (machineGunActive)
        {
            rightHandOnGun = machineGunTriggerHandle;
            leftHandOnGun = machineGunFrontHandle;
            leftHandHanging = machineGunTriggerHandle;
        }
        else
        {
            rightHandOnGun = missileTriggerHandle;
            leftHandOnGun = missileFrontHandle;
            leftHandHanging = missileTriggerHandle;
        }
    }

    //a callback for calculating IK
    private void OnAnimatorIK()
    {
        if (animator)
        {
            //IK value setting when the player is shooting from the bar
            if (barShooting && gunActive)
            {
                //right hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                //left hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                //right hand transforms
                animator.SetIKPosition(AvatarIKGoal.RightHand, handHangingHandle.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, handHangingHandle.rotation);
                //left hand transforms
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandHanging.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandHanging.rotation);
            }
            /*//IK value setting when the player is crouched
            else if (crouched||gunActive)
            {
                //right hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                //left hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                //right hand transforms
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandOnGun.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandOnGun.rotation);
                //left hand transforms
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandOnGun.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandOnGun.rotation);
            }*/
            //if the animation does not invovle the gun then set IK values to default
            else if (!gunActive)
            {
                //right hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                //left hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }
            //IK value setting when the player is standing, running, crouching or airborne
            else
            {
                //right hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                //left hand weights
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                //right hand transforms
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandOnGun.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandOnGun.rotation);
                //left hand transforms
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandOnGun.position);
                animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandOnGun.rotation);
            }
            
        }
    }
}
