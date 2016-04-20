using UnityEngine;
using System.Collections;

public class PlayerMovement : Entity {

    public float speed;
	public float bulletSpeed;

	public GameObject bullet;

	public GameObject EnergyBarr;
	public Entity EnergyBar;

	public bool isWalking = false;
	public bool canLoseEnergy = true;

	public string direction;
	public Vector2 shootinDirection;

	//public bool canMove = true;

	void Start () {



		if (EnergyBarr == null) {
			
			EnergyBarr = GameObject.FindGameObjectWithTag ("HealthBar");
			EnergyBar = EnergyBarr.GetComponent<Entity>();
		}


	}
	
	void Update () {

		if (!canMove) {
			return;
		}

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed);
			isWalking = true;

			direction = "right";

        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed);
			isWalking = true;

			direction = "down";
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed);
			isWalking = true;

			direction = "up";
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed);
			isWalking = true;

			direction = "left";
        }

		if (isWalking && canLoseEnergy) {
			loseEnergy (1);
			StartCoroutine (waitForLoseEnergy ());
			isWalking = false;
		}


		if(Input.GetKeyDown (KeyCode.Space)){

			getDirection ();

			Vector2 position = new Vector2 (transform.position.x, transform.position.y);

			GameObject obj = (GameObject)Instantiate (bullet, position, Quaternion.identity) as GameObject;

			//obj.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, bulletSpeed);

			obj.GetComponent<Rigidbody2D>().velocity = shootinDirection;
		}
    }


	void getDirection(){

		switch (direction){
			
		case "right":
			shootinDirection.y = 0;
			shootinDirection.x = bulletSpeed;
			break;

		case "down":
			shootinDirection.y = -bulletSpeed;
			shootinDirection.x = 0;
			break;

		case "left":
			shootinDirection.y = 0;
			shootinDirection.x = -bulletSpeed;
			break;

		case "up":
			shootinDirection.y = bulletSpeed;
			shootinDirection.x = 0;
			break;


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
