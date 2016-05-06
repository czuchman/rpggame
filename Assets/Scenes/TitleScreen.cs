using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public void NewGame()
    {
        SceneManager.LoadScene("Level 0");
    }
}
