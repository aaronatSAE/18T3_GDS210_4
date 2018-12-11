using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperLookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerLocation;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerLocation.transform);
    }
}
