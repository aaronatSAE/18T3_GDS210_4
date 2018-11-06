using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public GameObject playerLocation;
    

	// Use this for initialization
	void Start () {
        playerLocation = GameObject.FindGameObjectWithTag("Player");
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = playerLocation.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
