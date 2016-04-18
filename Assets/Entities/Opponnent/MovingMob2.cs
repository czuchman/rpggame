	using UnityEngine;
	using System.Collections;

public class MovingMob2 : Entity
{

    public Vector2 farEnd;
    private Vector2 frometh;
    private Vector2 untoeth;
    private float secondsForOneLength = 5f;

    public GameObject target;

    public bool aggro = false;

    bool StartFollow = false;
    GameObject CollisionTarget;

	public GameObject attackingg;
	public Entity attacking;

	public GameObject healthBarr;
	public Entity healthBar;


	public int distance;

	public int x;
	public int y;


	private bool canAttack;

    void Start()
    {
		farEnd.x = x;
        farEnd.y = y;
        frometh = transform.position;
        untoeth = farEnd;

		canAttack = true;
		if (attackingg == null) {
			attackingg = GameObject.FindGameObjectWithTag ("Player");
			attacking = attackingg.GetComponent<Entity>();
		}

		if (healthBarr == null) {
			healthBarr = GameObject.FindGameObjectWithTag ("HealthBar");
			healthBar = healthBarr.GetComponent<Entity>();
		}

    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.05F);
        if (StartFollow)
        {
            transform.position = Vector3.MoveTowards(transform.position, CollisionTarget.transform.position, 0.04F);

			if (Vector2.Distance (GetComponent<Rigidbody2D>().transform.position, attacking.transform.position) <= distance && canAttack) {
				attackEntity ();
				StartCoroutine (waitForAttack ());
			}

			if (Vector2.Distance (GetComponent<Rigidbody2D> ().transform.position, attacking.transform.position) > distance*5) {
				StartFollow = false;
			}
        }
        else
        {
            transform.position = Vector2.Lerp(frometh, untoeth,
                Mathf.SmoothStep(0f, 1f,
                Mathf.PingPong(Time.time / secondsForOneLength, 1f)
                ));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       // print("Collision");
        aggro = true;
        // Si le collider en question est celui du joueur
        if (other.name == "Player")
        {
            //print("it is a player");
            CollisionTarget = other.gameObject;
            StartFollow = true;
            
        }



    }

	public void die(){

	}

	public void attackEntity(){
		int take = Random.Range (1, 20);
		attacking.takeHealth (take);
		healthBar.takeHealth (take);

	}

	IEnumerator waitForAttack(){

		canAttack = false;
		yield return new WaitForSeconds (2);
		canAttack = true;
	}
}


