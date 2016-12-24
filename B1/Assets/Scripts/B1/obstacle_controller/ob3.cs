using UnityEngine;
using System.Collections;

public class ob3 : MonoBehaviour {

	private bool selected;
	private Renderer rend;
	private Rigidbody rb;
	public float factor;


	void Start () 
	{
		selected = false;
		rb = GetComponent<Rigidbody>();
		rend = GetComponent<Renderer>();
	}

	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0))  
		{
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.tag == "ob3") {
					Debug.Log ("selected");
					if (selected == true) {
						selected = false;
						rend.material.SetColor ("_Color", Color.green);
					} else {	
						selected = true;
						rend.material.SetColor ("_Color", Color.blue);
					}
				}
			}
		}
		if(selected == true)
		{
			{
				float moveHorizontal = Input.GetAxis ("Horizontal")/factor;
				float moveVertical = Input.GetAxis ("Vertical")/factor;

				Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
				rb.position = rb.position + movement;
			}
		}


	}
}
