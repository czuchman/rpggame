using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    public Animator anim;

    public PlayerTouchControl data;



    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();

        data = GetComponent<PlayerTouchControl>();

	}
	

	void Update ()
    { 

    

        //reading data from player control and setting animator parameters

        anim.SetFloat("Xpos", data.x);
        anim.SetFloat("Ypos", data.y);



    }
}
