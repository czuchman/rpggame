using UnityEngine;
using System.Collections;

public class Player : Entity {

	private static Location location;
	public bool readyToSpeak;

	public static Location GetLocation {
		get { return location; }
	}


	//this class will have references to your inventory
	//stats
	//quests



	void Start () {
	
	}
	

	void Update () {
	
	}

	public void Die(){

		print ("I've been killed");
	}
}
