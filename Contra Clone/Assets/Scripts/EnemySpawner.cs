using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject location;
    private float timer = 3.0f;
    public float spawnTimer = 3.0f;
    public GameObject[] mEnemyArray;
    
    

	// Use this for initialization
	void Start () {
        timer = spawnTimer;
        

    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer < 0)
        {                    
            Spawn();
            timer = spawnTimer;
            Debug.Log(mEnemyArray.Length);
        }

    }

    public void Spawn()
    {
        mEnemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("Check1,2");
        if (mEnemyArray.Length < 10)
        {
            
            Instantiate(enemy, location.transform);
            Debug.Log("CHHHHHAAARRRRGGGEEEEE!!!!!!");

        }
    }


}
