using UnityEngine;
using System.Collections;

public class Shooting : PlayerFollowMouse {

	public GameObject bullet;

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if(Input.GetKeyDown (KeyCode.Space) && (nbBullet > 0)){
			
			Vector2 position = new Vector2 (-2.0F, 2.0F);

			GameObject obj = Instantiate (bullet, position, Quaternion.identity) as GameObject;

			nbBullet = nbBullet - 1;
		}

	}
}
