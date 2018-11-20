using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour {

    public float aimAngle = 0.0f;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(aimAngle);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, aimAngle); 
        
        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 1)
        {
            aimAngle = 90.0f;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 0)
        {
            aimAngle = 180.0f;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == -1)
        {
            aimAngle = -90.0f;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 0)
        {
            aimAngle = 0.0f;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 1)
        {
            aimAngle = 135.0f;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 1)
        {
            aimAngle = 45.0f;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == -1)
        {
            aimAngle = -135.0f;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1)
        {
            aimAngle = -45.0f;
        }
    }  
}
