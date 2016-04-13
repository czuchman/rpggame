using UnityEngine;
using System.Collections;

public class Wolfanimation : MonoBehaviour {


	public Animator anim;

	public float old_pos;

	void Start () {
		anim = GetComponent<Animator> ();
		old_pos = anim.transform.position;
	}


	void Update () 
	{

		if (old_pos < anim.transform.position.x)
		{
			anim.SetBool("Right", true);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
			anim.SetBool("Left", false);
		}

		else anim.SetBool("Right", false);

		if (old_pos > anim.transform.position.x)
		{
			anim.SetBool("Down", true);
			anim.SetBool("Right", false);
			anim.SetBool("Left", false);
			anim.SetBool("Up", false);
		}

		else anim.SetBool("Down", false);

		if (old_pos < anim.transform.position.y)
		{
			anim.SetBool("Up", true);
			anim.SetBool("Down", false);
			anim.SetBool("Right", false);
			anim.SetBool("Left", false);
		}

		else anim.SetBool("Up", false);


		if (old_pos > anim.transform.position.y)
		{
			anim.SetBool("Left", true);
			anim.SetBool("Up", false);
			anim.SetBool("Down", false);
			anim.SetBool("Right", false);
		}

		else anim.SetBool("Left", false);



	}
}
