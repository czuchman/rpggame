using UnityEngine;
using System.Collections;

public class SpawnApple : MonoBehaviour {


	public GameObject prefab;
	public bool canSpawn = true;





	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		if (canSpawn) {

			float x = Random.Range (-5.0F, 5.0F);
			float y = Random.Range (-5.0F, 5.0F);

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
