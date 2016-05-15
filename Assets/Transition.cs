using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {

    public GameObject TransitionTo;

    public int offsetx, offsety;

   

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector2 target;
            target.x = TransitionTo.transform.position.x + offsetx;
            target.y = TransitionTo.transform.position.y + offsety;
            GameObject.FindGameObjectWithTag("Player").transform.position = target;
        }
    }
}
