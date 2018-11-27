using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public GameObject player;
    public int lives = 9;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(lives <= 0)
        {
            Destroy(player);
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("eBullet") || other.CompareTag("Senemy"))
        {
            lives--;
            StartCoroutine("CoOneSec");
        }
    }

    public IEnumerator CoOneSec()
    {
        //code that stops triggers or collision with enemy and ebullets
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(3f);
        //code that activates triggers or collision with enemy and ebullets
        GetComponent<BoxCollider>().enabled = true;
        yield return 0;
    }
}

