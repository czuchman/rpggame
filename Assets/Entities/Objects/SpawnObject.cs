using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {


	public GameObject prefab;
	public bool canSpawn = true;

	public float x;
	public float y;




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		if (canSpawn) {

			x = Random.Range (x-10, x+10);
			y = Random.Range (y-10, y+10);

			Vector2 position = new Vector2 (x, y);

			GameObject obj = Instantiate (prefab, position, Quaternion.identity) as GameObject;
			StartCoroutine (waitForSpawn ());
		}
	}




	IEnumerator waitForSpawn(){

		canSpawn = false;
		yield return new WaitForSeconds (5);
		canSpawn = true;
	}

}
