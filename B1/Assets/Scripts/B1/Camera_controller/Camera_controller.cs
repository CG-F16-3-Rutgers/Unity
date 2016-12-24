using UnityEngine;
using System.Collections;

public class Camera_controller : MonoBehaviour {
	public float cameraSensitivity = 90;
	public float normalMoveSpeed = 10;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;


	void Update ()
	{
		rotationX += Input.GetAxis("Horizontal1") * cameraSensitivity * Time.deltaTime;
		rotationY += Input.GetAxis("Vertical1") * cameraSensitivity * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, -90, 90);

		transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

		transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("forward_backward") * Time.deltaTime;

			
	}
}
