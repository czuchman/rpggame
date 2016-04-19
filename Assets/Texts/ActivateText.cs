using UnityEngine;
using System.Collections;

public class ActivateText : MonoBehaviour {


	public TextAsset firstText;
	public TextAsset secondText;
	private TextAsset currentText;
	public int currentTextID;

	public int startLine;
	public int endLine;

	public TextBoxManager theTextBox;

	public bool requireButtonPress;
	private bool waitForPress;

	public bool destroyWhenActivated;


	// Use this for initialization
	void Start () {
		currentTextID = 1;
		//currentText = firstText;
		theTextBox = FindObjectOfType<TextBoxManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		chooseText ();
		if (waitForPress && Input.GetKeyDown (KeyCode.J)) {

			currentTextID++;

			theTextBox.ReloadScript (currentText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destroyWhenActivated) {
				Destroy (gameObject);
			}

		}
			
	}


	void OnTriggerEnter2D(Collider2D other){
		//print ("enter area");
		if (other.name == "Player") {

			if (requireButtonPress) {
				waitForPress = true;
				return;
			}

			theTextBox.ReloadScript (currentText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destroyWhenActivated) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.name == "Player") {
			waitForPress = false;
		}
	}

	public void chooseText(){
		if (currentTextID == 1) {
			currentText = firstText;
		}

		if (currentTextID == 2) {
			currentText = secondText;
		}
	}
}
