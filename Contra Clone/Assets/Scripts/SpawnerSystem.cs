using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawner"))
        {
            if (other.gameObject.GetComponent<EnemySpawner>().enabled == false)
            {
                other.gameObject.GetComponent<EnemySpawner>().enabled = true;
            }
            if(other.gameObject.GetComponent<EnemySpawner>().enabled == true)
            {
                other.gameObject.GetComponent<EnemySpawner>().enabled = false;
            }
        }
    }
}
