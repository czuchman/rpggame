using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    // Use this for initialization

    public void ToMenu()
    {
        Debug.Log("Klik");
        SceneManager.LoadScene("TitleScreen");
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
