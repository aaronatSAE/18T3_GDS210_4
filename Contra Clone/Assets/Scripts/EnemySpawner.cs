using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject location;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawner", 1.0f, 3.0f);
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawner()
    {
        print(Time.time);
        Instantiate(enemy,location.transform);
        
       
     
    }

}
