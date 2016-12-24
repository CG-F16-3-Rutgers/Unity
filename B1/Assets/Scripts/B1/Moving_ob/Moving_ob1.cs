using UnityEngine;
using System.Collections;

public class Moving_ob1 : MonoBehaviour {
	private float min;
	private float max;
	// Use this for initialization
	void Start () {

		min=transform.position.z;
		max=transform.position.z + 5;

	}

	// Update is called once per frame
	void Update () {


		transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time*2,max-min) + min);

	}
}
