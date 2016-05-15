using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Shooting : MonoBehaviour {

	public GameObject bullet;

	//public float speed;



	public float bulletSpeed;
	private Vector3 targetPos2;

	public int nbBullet;
	public Text theText;

	// Use this for initialization
	void Start () {

		theText.text = nbBullet.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {

		theText.text = nbBullet.ToString();

        targetPos2.x = CrossPlatformInputManager.GetAxis("Horizontal");
        targetPos2.y = CrossPlatformInputManager.GetAxis("Vertical");
        targetPos2.z = 0.0f;
    }

    public void shoot()
    {
        if (nbBullet > 0 && (targetPos2.x !=0) && (targetPos2.y !=0))
        {


            nbBullet--;

           // targetPos2 = Input.mousePosition;
          //  targetPos2.z = 0.0f;
           // targetPos2 = Camera.main.ScreenToWorldPoint(targetPos2);
            //targetPos2 = targetPos2 - transform.position;

            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            Rigidbody2D rb2d = bulletInstance.GetComponent<Rigidbody2D>();
            rb2d.velocity = bulletSpeed * (new Vector2(targetPos2.x * bulletSpeed, targetPos2.y * bulletSpeed).normalized);
        }
    }


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "PickBullet")
		{
			nbBullet++;

		}



	}
}
