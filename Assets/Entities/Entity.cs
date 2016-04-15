using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float health;
	public float energy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void takeHealth(int amount){

		health = health - amount;

	}

	public void takeEnergy(int amount){

		energy = energy - amount;

	}
}
