using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour {

    
    public GameObject playerLocation;
    [SerializeField] private GameObject gun;
    public GameObject bullet;
    public float delayDuration = 1.0f;
    private float timeOfShot = 0.0f;


    // Use this for initialization
    void Start () {
        StartCoroutine("CoLocate");

    }
	
	// Update is called once per frame
	void Update () {
        if (playerLocation.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public IEnumerator CoLocate()
    {
        while(gameObject != null)
        {

            gun.transform.LookAt(playerLocation.transform);
            // if statement used so that there is a delay between shots
            if (Time.time > timeOfShot + delayDuration)
            {
                //Creates a bullet
                Instantiate(bullet, transform.position, transform.rotation);

                //makes the time when shot equal to time in game
                timeOfShot = Time.time;
            }
            yield return new WaitForSeconds(1f);
        }
        
    }
}
