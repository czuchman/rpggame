using UnityEngine;
using System.Collections;
using QuestSystem;
using UnityEngine.UI;

public class Test : MonoBehaviour {


	public GameObject item;
	IQuestObjective qo;
	public int nbItems;

	public bool destroyWhenActivated;

	public TextAsset textFile;

	public TextBoxManager theTextBox;




	// Use this for initialization
	void Start () {
		if (nbItems == 0){
			nbItems = 1; 
		}
		qo = new CollectionObjective ("Gather", nbItems, item, "Gather 10 meat!", false);
		Debug.Log (qo.ToString());

		createItems ();
	}
	
	// Update is called once per frame
	void Update () {


	
	}


	public void createItems(){
		for(int i = 0 ; i < nbItems ; i++) {
				
			float x = Random.Range (-5.0F, 5.0F);
			float y = Random.Range (-5.0F, 5.0F);

			Vector2 position = new Vector2 (x, y);

			GameObject obj = Instantiate (item, position, Quaternion.identity) as GameObject;
		}

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
				//print (" Congrats, quest finished");
				theTextBox = FindObjectOfType<TextBoxManager> ();
				theTextBox.ReloadScript (textFile);
				theTextBox.EnableTextBox ();
			}

		}



	}


}
