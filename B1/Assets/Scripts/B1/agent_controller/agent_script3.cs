using UnityEngine;
using System.Collections;

public class agent_script3 : MonoBehaviour {

	private NavMeshAgent agent;
	private NavMeshObstacle obstacle;
	private bool selected;
	private Renderer rend;



	void Start () 
	{
		selected = false;
		agent = GetComponent<NavMeshAgent> ();
		obstacle = GetComponent<NavMeshObstacle> ();
		obstacle.enabled = false;

		rend = GetComponent<Renderer>();
	}

	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown (0))  
		{
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.tag == "agent3") {
					Debug.Log ("selected");
					if (selected == true) {
						selected = false;
						rend.material.SetColor ("_Color", Color.white);
					} else {	
						selected = true;
						rend.material.SetColor ("_Color", Color.blue);
					}
				}
			}
		}
		if(Input.GetMouseButtonDown (1) && selected == true)
		{
			if(Physics.Raycast(ray, out hit, 100))
			{
				agent.SetDestination (hit.point);
				if ((transform.position - hit.point).sqrMagnitude < Mathf.Pow (agent.stoppingDistance, 2)) {
					obstacle.enabled = true;
					agent.enabled = false;
				} else {
					obstacle.enabled = false;
					agent.enabled = true;
				}
			}
		}


	}
}
