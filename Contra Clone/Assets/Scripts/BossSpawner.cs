using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bossSpawn;
    [SerializeField] private GameObject lineRenderer;
    [SerializeField] private GameObject exitBlock;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossSpawn.SetActive(true);
            lineRenderer.SetActive(true);
            exitBlock.transform.localScale = new Vector3(1, 25, 5);
            Destroy(gameObject);
        }
    }
}
