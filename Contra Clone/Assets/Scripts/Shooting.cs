using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour 
{
	//Variables
	public GameObject bullet;
	public float delayDuration = 1.0f;
	private float timeOfShot = 0.0f;


	void Start()
	{
		
	}

    // Update is called once per frame
    void Update()
    {
        //When the player clicks the left mouse button the gun will fire
        if (Input.GetButton("Fire1"))
        {
            // if statement used so that there is a delay between shots
            if (Time.time > timeOfShot + delayDuration)
            {
                //Creates a bullet
                Instantiate(bullet, transform.position, transform.rotation);

                //makes the time when shot equal to time in game
                timeOfShot = Time.time;
            }

        }
    }
}
