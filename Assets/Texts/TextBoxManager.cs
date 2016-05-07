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

	public bool isTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;





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

			if (Input.GetMouseButtonDown(0) && currentLine < endAtLine) {
			/*	if (!isTyping) {
					currentLine += 1;
					currentLine2 += 1;
				} else {
					StartCoroutine (TextScroll (textLines [currentLine]));
				}*/

				currentLine += 1;
				currentLine2 += 1;
			}

			/*
			if (isTyping && !cancelTyping) {
				cancelTyping = true;
			}
			*/

			if (Input.GetMouseButtonDown(0) && currentLine == endAtLine) {
				currentLine2 += 1;
			}

			if (currentLine2 == currentLine + 2) {
				DisableTextBox ();
				endOfText = true;
				currentLine = 0;
				currentLine2 = 0;
				endAtLine = 0;
			}
		}

		if (endOfText) {
			currentLine = 0;
			currentLine2 = 0;
			endAtLine = 0;
			playerr.GetComponent<Test> ().enabled = true;
			//playerr.GetComponent<Test> ().
			endOfText = false;
		}
			
	}


	public void EnableTextBox(){
		currentLine = 0;
		currentLine2 = 0;
		textBox.SetActive (true);
		isActive = true;

		if (stopPlayerMovement) {
			print ("stop movement");
			player.stopMoving();
			//player.canMove = false;
		}
	}

	public void DisableTextBox(){
		textBox.SetActive (false);
		isActive = false;
		player.startMoving ();
	}



	public void ReloadScript(TextAsset theText){
		//print ("reload");
		if (theText != null) {
			//print ("not null");
			textLines = new String[1];
			textLines = (theText.text.Split ('\n'));
			endAtLine = textLines.Length - 1;
		} else {
			print (" text null ...?");
		}
	}


	private IEnumerator TextScroll (string lineOfText){
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1)) {
			theText.text += lineOfText [letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
	}
}
