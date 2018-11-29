using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSlide : MonoBehaviour {

    
    public Rigidbody playerRB;
    private Vector3 playerVelocity;    
    public float groundJumpSpeed = 1.0f;
    public float barJumpSpeed = 1.0f;
    public float slideForce = 500f;
    public float slideAttackTime = 0.8f;
    public float slideTotalTime = 1.2f;    

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
            if(GetComponent<PlayerMovement>().grounded == true && GetComponent<PlayerMovement>().isCrouched == false)
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
            else if (GetComponent<PlayerMovement>().isCrouched == true && GetComponent<PlayerMovement>().sliding == false)
            {
                StartCoroutine("CoSlide");                
            }
        }        
    }
    
    private IEnumerator CoSlide()
    {
        //setting slide state
        GetComponent<PlayerMovement>().sliding = true;
        //disabling shooting for the slide
        transform.GetChild(3).gameObject.SetActive(false);
        //slides forward
        playerRB.AddForce(transform.forward * slideForce);
        //activating the invulnerable time of the slide by turning off the body trigger
        transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        //activating the attack box of the slide
        transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(slideAttackTime);

        //de-activating the invulnerable time of the slide by turning on the body trigger
        transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        //de-activating the attack box of the slide
        transform.GetChild(1).gameObject.SetActive(false);

        yield return new WaitForSeconds(slideTotalTime - slideAttackTime);

        if(GetComponent<PlayerMovement>().isCrouched == false)
        {
            GetComponent<PlayerMovement>().Stand();
        }

        //setting slide state
        GetComponent<PlayerMovement>().sliding = false;
        //enabling shooting after the slide
        transform.GetChild(3).gameObject.SetActive(true);
        //resetting the velocity
        playerRB.velocity = Vector3.zero;        
    }    
}
  