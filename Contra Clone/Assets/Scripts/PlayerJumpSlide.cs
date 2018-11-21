using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSlide : MonoBehaviour {

    
    public Rigidbody playerRB;
    private Vector3 playerVelocity;    
    public float groundJumpSpeed = 1.0f;
    public float barJumpSpeed = 1.0f;


	// Use this for initialization
	void Start ()
    {
        playerRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Jump") == true)
        {
            if(GetComponent<PlayerMovement>().grounded == true)
            {
                playerVelocity = playerRB.velocity;
                playerVelocity.y = groundJumpSpeed;
                playerRB.velocity = playerVelocity;
            }
            else if (GetComponent<PlayerMovement>().onBar == true)
            {
                playerVelocity = playerRB.velocity;
                playerVelocity.y = barJumpSpeed;
                playerRB.velocity = playerVelocity;
            }
            else if (GetComponent<PlayerMovement>().isCrouched == true)
            {
                //slide code here
            }
        }

        
    }   
}
  