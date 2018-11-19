using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MachineGun : MonoBehaviour 
{
	
	//Variables
	public float magnitude = 1.0f;
	public float lifeLine = 1.0f;


	// Use this for initialization
	void Start ()
	{
		//Using the Rigidbody component it adds force in the forward direction
		GetComponent<Rigidbody> ().AddForce (magnitude * transform.forward);

		//Destroys the bullet when the lifeline is up
		Destroy (gameObject, lifeLine);


	}


    //When the object collides with anything it'll destroy itself
    public void OnTriggerEnter(Collider other)
    {
		//Destroys the gameobject
		Destroy (gameObject);
	}
}
