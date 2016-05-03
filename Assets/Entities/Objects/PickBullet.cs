using UnityEngine;
using System.Collections;

public class PickBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//print("Collision");

		// Si le collider en question est celui du joueur
		if (other.tag == "Player")
		{
			Destroy (gameObject);



		}



	}
}
