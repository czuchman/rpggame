using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    private float playerhealth; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentHealth;
        if (playerhealth < 0 ) SceneManager.LoadScene("GameOver");
    }
}
