using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody playerRB;
    private Vector3 playerVelocity;
    public float runSpeed = 1.0f;
    public float airSpeed = 1.0f;
    public float climbSpeed = 1.0f;
    private float deltaX;
    public bool grounded = false;
    public bool isCrouched = false;
    public bool holdPosition = false;
    public bool onBar = false;
    //onBar is set using the PlayerClimb scripts attached to each bar and is true when holding oa bar.

    // Use this for initialization
    void Start ()
    {
        playerRB = GetComponent<Rigidbody>();        
    }
	
	// Update is called once per frame
	void Update ()
    {        
        playerVelocity = playerRB.velocity;

        //when crouched or on hold the player is unable to move horizontally
        if (isCrouched == false || holdPosition == false)
        {
            if (Input.GetAxisRaw("Horizontal") != 0.0f)
            {
                //running speed when on the ground
                if (grounded == true)
                {
                    deltaX = runSpeed * Input.GetAxisRaw("Horizontal") / Mathf.Abs(Input.GetAxisRaw("Horizontal"));
                }
                //climbing speed when on a bar
                else if (onBar == true)
                {
                    deltaX = climbSpeed * Input.GetAxisRaw("Horizontal") / Mathf.Abs(Input.GetAxisRaw("Horizontal"));
                }
                //aerial drift speed when airborne. the player can change the drift direction.
                else
                {
                    deltaX = airSpeed * Input.GetAxisRaw("Horizontal") / Mathf.Abs(Input.GetAxisRaw("Horizontal"));
                }
                //code to set the above velocities
                playerVelocity.x = deltaX;
                playerRB.velocity = playerVelocity;
            }
            else
            {
                //player will quickly come to a stop when grounded or on a monkey bar and not hitting a direction
                //in the air players will maintain their momentum when not hitting a direction
                if (grounded == true || onBar == true)
                {
                    playerVelocity.x = 0;
                    playerRB.velocity = playerVelocity;
                }
            }
        }

        //if the player is grounded or hanging on a bar they can hold their position to shoot in all directions without moving
        if(grounded == true || onBar == true)
        {
            //setting the hold postion state
            if(Input.GetKey(KeyCode.H) == true)
            {
                holdPosition = true;
            }
        }

        
        //while grounded the player can crouch by holding the crouch.
        if(grounded == true)
        {
            //setting the crouch state
            if(Input.GetKey(KeyCode.C))
            {
                isCrouched = true;

                //crouch code here
            }
            
        }

    }


    //setting the grounded state
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            grounded = true;
        }        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            grounded = false;
        }        
    }


}

