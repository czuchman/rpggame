using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	private Rigidbody2D myBody;
	private float speed = 5f;

	public bool isDestroy;

	// Use this for initialization
	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		if (isDestroy) {
			Destroy (gameObject, 1.6F);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//myBody.velocity = new Vector2 (0, -speed);
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		//print("Collision");

		// Si le collider en question est celui du joueur
		if (other.tag == "KillWolf")
		{



			Destroy (gameObject);

		}



	}


}
