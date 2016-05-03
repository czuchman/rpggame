using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerFollowMouse : Entity
{

	public float speed;
	public float bulletSpeed;

	public GameObject bullet;

	public GameObject EnergyBarr;
	public Entity EnergyBar;

	public bool isWalking = false;
	public bool canLoseEnergy = true;

	public string direction;
	public Vector2 shootinDirection;


	//public float speed = 3.0f;
	private Vector3 targetPos;
	private Vector3 targetPos2;


	public int nbBullet;
	public Text theText;

	void Start() {


		if (EnergyBarr == null) {

			EnergyBarr = GameObject.FindGameObjectWithTag ("HealthBar");
			EnergyBar = EnergyBarr.GetComponent<Entity>();
		}



		targetPos = transform.position;    
	}

	void Update () {

		theText.text = nbBullet.ToString();

		if (!canMove) {
			return;
		}


		if (Input.GetMouseButtonDown(0)) {

			isWalking = true;

			float distance = transform.position.z - Camera.main.transform.position.z;
			targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
			targetPos = Camera.main.ScreenToWorldPoint(targetPos);
		}

		if (isWalking && canLoseEnergy) {
			loseEnergy (1);
			StartCoroutine (waitForLoseEnergy ());
			isWalking = false;
		}


		if (Input.GetMouseButtonDown(1) && (nbBullet > 0)){


			nbBullet--;

			targetPos2 = Input.mousePosition;
			targetPos2.z = 0.0f;
			targetPos2 = Camera.main.ScreenToWorldPoint (targetPos2);
			targetPos2 = targetPos2 - transform.position;

			GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
			Rigidbody2D rb2d = bulletInstance.GetComponent<Rigidbody2D> ();
			rb2d.velocity = new Vector2(targetPos2.x * bulletSpeed, targetPos2.y * bulletSpeed);





			/*float distance2 = transform.position.z - Camera.main.transform.position.z;
			targetPos2 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			targetPos2 = Camera.main.ScreenToWorldPoint(targetPos2);*/



			/*

			Vector2 position = new Vector2 (transform.position.x, transform.position.y);

			GameObject obj = (GameObject)Instantiate (bullet, position, Quaternion.identity) as GameObject;

			//obj.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, bulletSpeed);

			obj.GetComponent<Rigidbody2D>().velocity = targetPos2;*/
		}

		transform.position = Vector3.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);
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


	public void getDirection2(){

		if (targetPos.x > transform.position.x) {
			shootinDirection.y = 0;
			shootinDirection.x = bulletSpeed;
			return;
		}

		if (targetPos.x < transform.position.x) {
			shootinDirection.y = 0;
			shootinDirection.x = -bulletSpeed;
			return;
		}


		if (targetPos.y < transform.position.y) {
			shootinDirection.y = -bulletSpeed;
			shootinDirection.x = 0;
			return;
		}

		if (targetPos.y > transform.position.y) {
			shootinDirection.y = bulletSpeed;
			shootinDirection.x = 0;
			return;
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

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "PickBullet")
		{
			nbBullet++;

		}



	}
}