using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody playerRB;
    public Transform playerHitCollider;

    public GameObject machineGunModel;
    public GameObject missileGunModel;
    public Transform defaultGunModelPosition;
    public Transform onBarGunModelPosition;

    //Capsule length orientation: 0 -> x-axis. 1 -> y-axis. 2 -> z-axis.
    //public int standColliderOrientation = 1;
    //public int crouchColliderOrientation = 2;

    private Vector3 playerVelocity;
    public float runSpeed = 1.0f;
    public float airSpeed = 1.0f;
    public float climbSpeed = 1.0f;
    private float deltaX;
    public float deltaY = 0.5f;
    public bool grounded = false;
    public bool isCrouched = false;
    public bool holdPosition = false;
    public bool onBar = false;
    //onBar is set using the PlayerClimb scripts attached to each bar and is true when holding the bar.
    public bool sliding = false;
    //sliding is set using the PlayerJumpSlide script

    // Use this for initialization
    void Start ()
    {
        playerRB = GetComponent<Rigidbody>();
        playerHitCollider = transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //setting character orientation
        if (Input.GetAxisRaw("Horizontal") != 0.0f && isCrouched == false)
        {
            transform.rotation = Quaternion.Euler(0, 90 * Input.GetAxisRaw("Horizontal"), 0);
        }
        
        playerVelocity = playerRB.velocity;

        //when crouched or on hold the player is unable to move horizontally
        if (isCrouched == false && holdPosition == false && sliding == false)
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
        if ((grounded == true || onBar == true) && isCrouched == false && sliding == false)
        {
            //setting the hold postion state
            if (Input.GetButton("Fire2"))
            {
                holdPosition = true;

                //setting the hold position velocity to zero
                if (playerVelocity.x != 0)
                {
                    playerVelocity.x = 0;
                    playerRB.velocity = playerVelocity;
                }
            }
            else
            {
                holdPosition = false;
            }
        }
        //once airborne the player can still move left and right
        else
        {
            holdPosition = false;
        }

        if(grounded == true)
        {
            //while grounded the player can crouch by holding the crouch button and while crouched they can only aim forward.
            if (Input.GetKeyDown(KeyCode.C))
            {
                Crouch();
            }

            //setting the crouch state
            if (Input.GetKey(KeyCode.C))
            {
                isCrouched = true;
            }
            else
            {
                isCrouched = false;
            }

            //stand happens if you are not in a slide attack
            if (Input.GetKeyUp(KeyCode.C) && sliding == false)
            {
                Stand();
            }
        }

        //movement options/restrictions while holding onto a bar
        if(onBar == true)
        {
            //while holding onto a bar they can hit the crouch button to let go
            if (Input.GetKeyDown(KeyCode.C))
            {
                StartCoroutine("CoLetGo");
            }

            //while shooting the player is unable to move on the bar
            if (Input.GetButton("Fire1"))
            {
                playerVelocity.x = 0;
                playerRB.velocity = playerVelocity;
            }
        }

        //setting the gunmodels positon
        if (onBar)
        {
            machineGunModel.transform.position = onBarGunModelPosition.position;
            missileGunModel.transform.position = onBarGunModelPosition.position;
        }
        else
        {
            machineGunModel.transform.position = defaultGunModelPosition.position;
            missileGunModel.transform.position = defaultGunModelPosition.position;
        }
    }

    //setting the grounded state
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            grounded = true;
            
            //if the crouch button is pressed on landing the player will enter crouch state
            if(Input.GetKey(KeyCode.C))
            {
                Crouch();
            }
        }        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            grounded = false;
        }        
    }

    //Crouch sets the players hitbox and position closer to the ground
    public void Crouch()
    {
        if (playerVelocity.x != 0)
        {
            playerRB.velocity = Vector3.zero;
        }

        //playerHitCollider.direction = crouchColliderOrientation;
        playerHitCollider.localRotation = Quaternion.Euler(90, 0, 0);

        var playerPosition = playerHitCollider.localPosition;
        playerPosition.y -= deltaY;
        playerHitCollider.localPosition = playerPosition;
    }

    //Stand resets the players hitbox and position
    public void Stand()
    {
        //playerHitCollider.direction = standColliderOrientation;
        playerHitCollider.localRotation = Quaternion.Euler(0, 0, 0);

        var playerPosition = playerHitCollider.localPosition;
        playerPosition.y += deltaY;
        playerHitCollider.localPosition = playerPosition;
    }

    //used to deactivate and reactivate the hand so the player let go of a bar    
    private IEnumerator CoLetGo()
    {
        transform.GetChild(2).gameObject.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        transform.GetChild(2).gameObject.SetActive(true);
    }
}

