	using UnityEngine;
	using System.Collections;

	public class MovingMob : MonoBehaviour
	{
		
		public Vector2 farEnd;
		private Vector2 frometh;
		private Vector2 untoeth;
		private float secondsForOneLength = 5f;

		public GameObject target;

	public bool aggro = false;

		void Start()
		{
		farEnd.x = -5;
		farEnd.y = 2;
			frometh = transform.position;
			untoeth = farEnd;
	
		}

		void Update()
		{
			transform.position = Vector2.Lerp(frometh, untoeth,
				Mathf.SmoothStep(0f,1f,
					Mathf.PingPong(Time.time/secondsForOneLength, 1f)
				) ); 
		//transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.05F);

		}

	void OntriggerEnter2D(Collider other)
		{
		aggro = true;
			// Si le collider en question est celui du joueur
			if (other.name == "Player")
			{
				transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.05F);
			}



		}
	}


