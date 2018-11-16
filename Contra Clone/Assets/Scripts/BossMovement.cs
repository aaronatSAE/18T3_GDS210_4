using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

    public GameObject[] currentLocations;
    public int pos;
    public float timeTurn = 3f;

	// Use this for initialization
	void Start () {
        transform.position = currentLocations[0].transform.position;
        pos = 1;
	}

    // Update is called once per frame
    void Update()
    {
        timeTurn -= Time.deltaTime;
        if (timeTurn < 0)
        {
            Movement();
        }
    }

    public void Movement()
    {       
        int rand = Random.Range(0, 2);
        if(rand == 0)
        {
            if(pos == 1)
            {
                Attack1();
            }
            if (pos == 2)
            {
                Attack2();
            }
            if (pos == 3)
            {
                Attack3();
            }
        }

        if(rand == 1)
        {
            int rand2 = Random.Range(0, 3);
            if(rand2 == 0)
            {
                transform.position = currentLocations[1].transform.position;
                pos = 2;
                Movement();
            }

            if (rand2 == 1)
            {
                transform.position = currentLocations[2].transform.position;
                pos = 3;
                Movement();
            }

            if (rand2 == 2)
            {
                transform.position = currentLocations[0].transform.position;
                pos = 1;
                Movement();
            }
        }

    }


    

    public void Attack1()
    {
        Debug.Log("Attack 1 Occurs");
        Movement();
    }

    public void Attack2()
    {
        Debug.Log("Attack 2 Occurs");
        Movement();
    }

    public void Attack3()
    {
        Debug.Log("Attack 3 Occurs");
        Movement();
    }
}
