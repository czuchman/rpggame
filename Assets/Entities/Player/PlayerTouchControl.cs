using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerTouchControl : MonoBehaviour
{ 
    Rigidbody2D playercharacter;
    public float playerspeed; 


	// Use this for initialization
	void Start () {
	
    playercharacter = this.GetComponent<Rigidbody2D>();


	}
	
	// Update is called once per frame
	void Update () {
    Vector2 movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * playerspeed;
        playercharacter.transform.Translate(movement);
	}
}
