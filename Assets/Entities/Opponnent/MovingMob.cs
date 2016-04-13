	using UnityEngine;
	using System.Collections;

	public class MovingMob : MonoBehaviour
	{
		
		public Vector3 farEnd;
		private Vector3 frometh;
		private Vector3 untoeth;
		private float secondsForOneLength = 5f;

		void Start()
		{
		farEnd.x = -5;
		farEnd.y = 2;
			frometh = transform.position;
			untoeth = farEnd;
		}

		void Update()
		{
			transform.position = Vector3.Lerp(frometh, untoeth,
				Mathf.SmoothStep(0f,1f,
					Mathf.PingPong(Time.time/secondsForOneLength, 1f)
				) );
		}
	}


