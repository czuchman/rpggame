using UnityEngine;
using System.Collections;

public class apple : MonoBehaviour {

	public GameObject EnergyBarr;
	public Entity EnergyBar;

	public GameObject healthBarr;
	public Entity healthBar;



	// Use this for initialization
	void Start () {
	
		if (EnergyBarr == null) {

			EnergyBarr = GameObject.FindGameObjectWithTag ("HealthBar");
			EnergyBar = EnergyBarr.GetComponent<Entity>();
		}

		if (healthBarr == null) {
			healthBarr = GameObject.FindGameObjectWithTag ("HealthBar");
			healthBar = healthBarr.GetComponent<Entity>();
		}

	}
	
	// Update is called once per frame
	void Update () {

	}



	void OnTriggerEnter2D(Collider2D other)
	{
		//print("Collision");

		// Si le collider en question est celui du joueur
		if (other.name == "Player")
		{
			EnergyBar.takeEnergy (-20);
			healthBar.takeHealth (-20);

			//print("it is a player");
			Destroy (gameObject);

		}



	}

}

