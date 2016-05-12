using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerTouchControl : Entity
{ 
    Rigidbody2D playercharacter;
    public float playerspeed; 


	public float speed;

	public Vector3 pos;

    public float x, y; 


	public GameObject EnergyBarr;
	public Entity EnergyBar;

	public bool isWalking = false;
	public bool canLoseEnergy = true;







	// Use this for initialization
	void Start () {
	
   		playercharacter = this.GetComponent<Rigidbody2D>();

		if (EnergyBarr == null) {

			EnergyBarr = GameObject.FindGameObjectWithTag ("HealthBar");
			EnergyBar = EnergyBarr.GetComponent<Entity>();
		}


	}
	
	// Update is called once per frame
	void Update () {

		pos = transform.position;

		if (canMove) {
			Vector2 movement = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical")) * playerspeed;
			playercharacter.transform.Translate (movement);

            x = movement.x * 1000 ;
            y = movement.y * 1000 ;

           


        }

		if (pos != transform.position) {
			isWalking = true;
		}


		if (!canMove) {
			return;
		}




		if (isWalking && canLoseEnergy) {
			loseEnergy (2);
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
