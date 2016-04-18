using UnityEngine;
using System.Collections;
using QuestSystem;

public class Test : MonoBehaviour {


	public GameObject item;
	IQuestObjective qo;

	// Use this for initialization
	void Start () {
	
		qo = new CollectionObjective ("Gather", 3, item, "Gather 10 meat!", false);
		Debug.Log (qo.ToString());
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//print("Collision");

		// Si le collider en question est celui du joueur
		if (other.tag == "Pill")
		{


			print(" OK +1");

			qo.UpdateProgress ();
			qo.CheckProgress ();
			if (qo.IsComplete) {
				print (" Congrats, quest finished");
			}

		}



	}
}
