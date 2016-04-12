using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    public Animator anim;


	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

	}
	

	void Update () {


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Right", true);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Left", false);
        }

        else anim.SetBool("Right", false);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Down", true);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("Up", false);
        }

        else anim.SetBool("Down", false);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
        }

        else anim.SetBool("Up", false);


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Left", true);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Right", false);
        }

        else anim.SetBool("Left", false);

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
                {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Right", false);
            anim.SetBool("Left", false);
            anim.SetBool("LeftUp", true);
        }

       

    }
}
