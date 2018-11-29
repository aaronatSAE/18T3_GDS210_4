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
        if(GetComponentInParent<PlayerMovement>().isCrouched != true)
        {
            //aiming angles
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 1)
            {
                aimAngle = -90.0f;
            }
            else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 0)
            {
                aimAngle = 0.0f;
            }
            else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == -1)
            {
                aimAngle = 90.0f;
            }
            else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 0)
            {
                aimAngle = 0.0f;
            }
            else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == 1)
            {
                aimAngle = -45.0f;
            }
            else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == 1)
            {
                aimAngle = -45.0f;
            }
            else if (Input.GetAxisRaw("Horizontal") == -1 && Input.GetAxisRaw("Vertical") == -1)
            {
                aimAngle = 45.0f;
            }
            else if (Input.GetAxisRaw("Horizontal") == 1 && Input.GetAxisRaw("Vertical") == -1)
            {
                aimAngle = 45.0f;
            }

            gameObject.transform.localRotation = Quaternion.Euler(aimAngle, 0, 0);
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.forward);
        }        
    }  
}
