using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class TextBoxManager : Entity {



	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int currentLine2;
	public int endAtLine;

	public GameObject playerr;
	public Entity player;

	public bool endOfText;

	public bool isActive;

	public bool stopPlayerMovement;


	void Start () {

		if (playerr == null) {
			playerr = GameObject.FindGameObjectWithTag ("Player");
			player = playerr.GetComponent<Entity>();
		}

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));

		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		if (isActive) {
			print("is Active");
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
			


	}
	
	// Update is called once per frame
	void Update () {

		if (!isActive) {

			return;
		}

		if (!endOfText) {
			theText.text = textLines [currentLine];

			if (Input.GetKeyDown (KeyCode.Return) && currentLine < endAtLine) {
				currentLine += 1;
				currentLine2 += 1;
			}

			if (Input.GetKeyDown (KeyCode.Return) && currentLine == endAtLine) {
				currentLine2 += 1;
			}

			if (currentLine2 == currentLine + 2) {
				DisableTextBox ();
				endOfText = true;
			}
		}
			
	}


	public void EnableTextBox(){
		textBox.SetActive (true);
		isActive = true;

		if (stopPlayerMovement) {
			print ("stop movement");
			player.stopMoving();
			player.canMove = false;
		}
	}

	public void DisableTextBox(){
		textBox.SetActive (false);
		isActive = false;
		player.startMoving ();
	}



	public void ReloadScript(TextAsset theText){
		if(theText != null){
			textLines = new String[1];
			textLines = (theText.text.Split ('\n'));
		}
	}
}
