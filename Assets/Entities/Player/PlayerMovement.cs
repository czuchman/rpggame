using UnityEngine;
using System.Collections;

public class PlayerMovement : Entity {

    public float speed;

	public GameObject EnergyBarr;
	public Entity EnergyBar;

	public bool isWalking = false;
	public bool canLoseEnergy = true;

	void Start () {
		if (EnergyBarr == null) {
			
			EnergyBarr = GameObject.FindGameObjectWithTag ("HealthBar");
			EnergyBar = EnergyBarr.GetComponent<Entity>();
		}


	}
	
	void Update () {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed);
			isWalking = true;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed);
			isWalking = true;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed);
			isWalking = true;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed);
			isWalking = true;
        }

		if (isWalking && canLoseEnergy) {
			loseEnergy (1);
			StartCoroutine (waitForLoseEnergy ());
			isWalking = false;
		}
    }


	void loseEnergy(int amount){
		
		EnergyBar.takeEnergy (amount);

	}



	IEnumerator waitForLoseEnergy(){

		canLoseEnergy = false;
		yield return new WaitForSeconds (5);
		canLoseEnergy = true;
	}
}
