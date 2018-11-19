using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour {

    public Rigidbody handRB;
    

    // Use this for initialization
    void Start ()
    {
        handRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bar")
        {
            if(handRB.velocity.y <= 0)
            {

            }

            GetComponentInParent<PlayerMovement>().onBar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bar")
        {
            GetComponentInParent<PlayerMovement>().onBar = false;
        }
    }   
}
