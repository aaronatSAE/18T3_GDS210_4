using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	//Variables
	public float speed;
    public GameObject player;
    [SerializeField] private float distance;

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update () 
	{
        //make the variable as the player
        player = GameObject.FindGameObjectWithTag("Player");
		//gets the players x and z positions and maintains the same y positions
		Vector3 playerpos = new Vector3 (player.transform.position.x, transform.position.y, player.transform.position.z-distance);

		//makes the camera move with the players position at a nice speed
		transform.position = Vector3.Lerp (transform.position, playerpos, Time.deltaTime * speed);
	}
}
