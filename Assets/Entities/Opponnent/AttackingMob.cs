using UnityEngine;
using System.Collections;

public class AttackingMob : Entity {

	public GameObject attackingg;
	public Entity attacking;
	public int distance;


	private bool canAttack;

	// Use this for initialization
	void Start () {
		canAttack = true;
		if (attackingg == null) {
			attackingg = GameObject.FindGameObjectWithTag ("Player");
			attacking = attackingg.GetComponent<Entity>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.05F);

		if (Vector2.Distance (GetComponent<Rigidbody2D>().transform.position, attacking.transform.position) <= distance && canAttack) {
			attackEntity ();
			StartCoroutine (waitForAttack ());
		}


	}



	public void die(){

	}

	public void attackEntity(){
		int take = Random.Range (1, 20);
		attacking.takeHealth (take);
	}

	IEnumerator waitForAttack(){

		canAttack = false;
		yield return new WaitForSeconds (2);
		canAttack = true;
	}
}
