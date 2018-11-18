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
    public bool onBar = false;
    

	// Use this for initialization
	void Start ()
    {
        playerRB = GetComponent<Rigidbody>();        
    }
	
	// Update is called once per frame
	void Update ()
    {        
        playerVelocity = playerRB.velocity;

        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            if(grounded == true)
            {
                deltaX = runSpeed * Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal"));
            }
            else if(onBar == true)
            {
                deltaX = climbSpeed * Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal"));
            }
            else
            {
                deltaX = airSpeed * Input.GetAxis("Horizontal") / Mathf.Abs(Input.GetAxis("Horizontal"));
            }
            
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

