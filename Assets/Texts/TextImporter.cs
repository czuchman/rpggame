using UnityEngine;
using System.Collections;

public class TextImporter : MonoBehaviour {


	public TextAsset textFile;
	public string[] textLines;


	void Start () {
	
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
