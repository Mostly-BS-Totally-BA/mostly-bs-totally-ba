using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public float smooth_camera = 0.125f;
	public Transform camera_target;
	public Vector3 camera_offset;

	void LateUpdate()
	{
		Vector3 des_position = camera_target.position + camera_offset;
		Vector3 smooth_pos = Vector3.Lerp (transform.position, des_position, smooth_camera);
		transform.position = smooth_pos;
	}
}
