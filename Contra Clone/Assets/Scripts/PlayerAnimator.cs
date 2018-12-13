using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public GameObject player;
    private PlayerMovement myPlayerMovement;

    private Animator anim;
    
    
    // Use this for initialization
	void Start ()
    {
        myPlayerMovement = player.GetComponent<PlayerMovement>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //setting the "is running" parameter
        if (myPlayerMovement.grounded == true && myPlayerMovement.playerRB.velocity.x != 0)
        {
            anim.SetBool("is running", true);
        }
        else
        {
            anim.SetBool("is running", false);
        }

        //setting the "is crouched" parameter
        anim.SetBool("is crouched", myPlayerMovement.isCrouched);

        //setting the "airborne" parameter
        if(myPlayerMovement.grounded == false && myPlayerMovement.onBar == false)
        {
            anim.SetBool("airborne", true);
        }
        else
        {
            anim.SetBool("airborne", false);
        }

        //setting the "on bar" parameter
        anim.SetBool("on bar", myPlayerMovement.onBar);

        //setting the "is climbing" parameter
        if (myPlayerMovement.onBar == true && myPlayerMovement.playerRB.velocity.x != 0)
        {
            anim.SetBool("is climbing", true);
        }
        else
        {
            anim.SetBool("is climbing", false);
        }

        //setting the "sliding" parameter
        anim.SetBool("sliding", myPlayerMovement.sliding);

        //setting the "shooting" paramater
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("shooting", true);
        }
        else
        {
            anim.SetBool("shooting", false);
        }
	}
}
