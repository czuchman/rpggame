using UnityEngine;
using System.Collections;

public class Wolfanimation : MonoBehaviour {


	public Animator anim;

	public Vector3 old_pos;

	void Start () {
		anim = GetComponent<Animator> ();
		old_pos.x = anim.transform.position.x;
		old_pos.y = anim.transform.position.y;

	}


	void Update () 
	{

		if (old_pos.x < anim.transform.position.x)
		{
			anim.SetBool("Right", true);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
			anim.SetBool("Left", false);
		}

		else anim.SetBool("Right", false);

		if (old_pos.x > anim.transform.position.x)
		{

			anim.SetBool("Left", true);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
			anim.SetBool("Right", false);

		}

		else anim.SetBool("Down", false);

	/*
		if (old_pos.y < anim.transform.position.y)
		{
			anim.SetBool("Up", true);
			anim.SetBool("Down", false);
			anim.SetBool("Right", false);
			anim.SetBool("Left", false);
		}

		else anim.SetBool("Up", false);


		if (old_pos.y > anim.transform.position.y)
		{

			anim.SetBool("Down", true);
			anim.SetBool("Right", false);
			anim.SetBool("Left", false);
			anim.SetBool("Up", false);

		}

		else anim.SetBool("Left", false);
*/


		old_pos.x = anim.transform.position.x;
		old_pos.y = anim.transform.position.y;


	}
}
