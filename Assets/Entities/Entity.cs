using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float health;
	public float energy;

	public bool canMove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void takeHealth(int amount){

		health = health - amount;
		if(health>100){
			health = 100;
		}

	}

	public void takeEnergy(int amount){

		energy = energy - amount;
		if(energy > 100 ){
			energy = 100 ;
		}
	}

	public void stopMoving(){
		canMove = false;
	}

	public void startMoving(){
		canMove = true;
	}
}
