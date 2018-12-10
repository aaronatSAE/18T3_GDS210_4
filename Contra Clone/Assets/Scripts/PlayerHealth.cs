using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public GameObject player;
    public int lives = 9;

    public float maxLives;
    public Image lifeBar;
    public float livesPercent;	
	
	public AudioClip sound; 
    private AudioSource audioPlayer;
	// Use this for initialization
	void Start () {
		//Initialize player healthbar
		maxLives = lives;
        audioPlayer = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
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
			//Start draw health function
            audioPlayer.PlayOneShot(sound, 1f);
			DrawLives();
        }
    }

    public IEnumerator CoOneSec()
    {
        //code that stops triggers or collision with enemy and ebullets
        GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(3f);
        //code that activates triggers or collision with enemy and ebullets
        GetComponent<CapsuleCollider>().enabled = true;
        yield return 0;
    }
	    
		public void DrawLives()
    {
        if (lifeBar != null) // if an object is specified
        {
            livesPercent = lives/maxLives; // get health as percent
            lifeBar.fillAmount = livesPercent;
        }
	}
}

