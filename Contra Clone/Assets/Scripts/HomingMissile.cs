using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HomingMissile : MonoBehaviour {

    private List<GameObject> enemies;
    private GameObject target = null;
    public GameObject sensor;
    private float targetDistance = Mathf.Infinity;
    private Vector3 lookAtDirection;
    private float turningSpeed = 3f;
    public float startingTurningSpeed = 3f;
    public float turningSpeedIncrement = 0.5f;
    public float turningSpeedIncreseRate = 0.5f;
    private Rigidbody missileRB;
    public float missileSpeed = 20f;
    public float lifeLine = 1.0f;

    // Use this for initialization
    void Start ()
    {
        sensor = GameObject.FindGameObjectWithTag("Sensor");
        missileRB = GetComponent<Rigidbody>();
        turningSpeed = startingTurningSpeed;

        //collection a list of enemies loaded into the level
        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Senemy"))
        {
            enemies.Add(enemy);
        }

        //enemies positions are compared to the enemy sensor point and we select the closest for the misile to target.
        //we set the sensor point ahead of the gun to bias the homing in the direction the player is aiming.
        Vector3 sensorPosition = sensor.transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 relativeLocation = enemy.transform.position - sensorPosition;
            float distance = relativeLocation.sqrMagnitude;
            if (distance < targetDistance)
            {
                target = enemy;
                targetDistance = distance;
            }
        }

        //Destroys the bullet when the lifeline is up
        Destroy(gameObject, lifeLine);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)        
        {
            //dynamic turning speed programmed to increase over time
            float t = 0.0f;
            t += Time.deltaTime;
            if (t >= turningSpeedIncreseRate)
            {
                turningSpeed += turningSpeedIncrement;
                t = 0.0f;
            }

            //rotating the missile toward the target
            var targetPos = target.transform.position;
            targetPos.y += 3;
            lookAtDirection = targetPos - transform.position;
            Quaternion aimAtTarget = Quaternion.LookRotation(lookAtDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, aimAtTarget, turningSpeed * Time.deltaTime);

        }

        //seting the velocity forward
        missileRB.velocity = transform.forward * missileSpeed;        
	}

    //When the object collides with anything it'll destroy itself
    public void OnTriggerEnter(Collider other)
    {
        //Destroys the gameobject
        Destroy(gameObject);
    }
}
