using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    
    public Rigidbody playerRB;
    private Vector3 playerVelocity;    
    public float jumpSpeed = 1.0f;

	// Use this for initialization
	void Start ()
    {
        playerRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButton("Jump") == true)
        {            
            playerVelocity = playerRB.velocity;
            playerVelocity.y = jumpSpeed;
            playerRB.velocity = playerVelocity;
        }

        //Debug.Log(Input.GetButtonDown("Jump") + ": " + playerRB.velocity);
    }   
}
  