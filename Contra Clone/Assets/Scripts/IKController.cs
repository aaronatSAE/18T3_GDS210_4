using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour {

    protected Animator anim;

    public GameObject aimingArm;

    public bool barShooting = false;    
    public bool gunActive = true;

    public bool machineGunActive = true;
    //set from the PlayerWeaponChange script

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
        anim = GetComponent<Animator>();        
    }

    public void Update()
    {
        //selects the IK handles for the corresponding gun
        if (machineGunActive)
        {
            rightHandOnGun = machineGunFrontHandle;
            leftHandOnGun = machineGunTriggerHandle;
            leftHandHanging = machineGunTriggerHandle;
        }
        else
        {
            rightHandOnGun = missileFrontHandle;
            leftHandOnGun = missileTriggerHandle;
            leftHandHanging = missileTriggerHandle;
        }

        //setting the "barShooting" bool
        if (anim.GetBool("on bar") == true && anim.GetBool("is climbing") == false)
        {
            barShooting = true;
        }
        else
        {
            barShooting = false;
        }

        //setting the "gunActive" bool
        if (anim.GetBool("is climbing") == true)
        {
            gunActive = false;
            //aiming arm deactivation
            aimingArm.gameObject.SetActive(false);
        }
        else
        {
            gunActive = true;
            aimingArm.gameObject.SetActive(true);
        }
    }

    //a callback for calculating IK
    private void OnAnimatorIK()
    {
        if (anim)
        {
            //IK value setting when the player is shooting from the bar
            if (barShooting && gunActive)
            {
                //right hand weights
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                //left hand weights
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                //right hand transforms
                anim.SetIKPosition(AvatarIKGoal.RightHand, handHangingHandle.position);
                anim.SetIKRotation(AvatarIKGoal.RightHand, handHangingHandle.rotation);
                //left hand transforms
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandHanging.position);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandHanging.rotation);
            }
            
            //if the animation does not involve the gun then set IK values to default
            else if (!gunActive)
            {
                //right hand weights
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                //left hand weights
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }

            //IK value setting when the player is standing, running, crouching or airborne
            else
            {
                //right hand weights
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                //left hand weights
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

                //right hand transforms
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandOnGun.position);
                anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandOnGun.rotation);
                //left hand transforms
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandOnGun.position);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandOnGun.rotation);
            }
            
        }
    }
}
