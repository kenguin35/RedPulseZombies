using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public double shootInterval = 0.5;
	public GameObject rayOrigin;
	LineRenderer lineRenderer;

	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
	}
	

	void FixedUpdate () {
		if (Input.GetMouseButton (0)) {
			Shoot ();
		}	
	}

	void Shoot(){
		
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		Physics.Raycast (Camera.main.transform.position, fwd, 20);

	}
}
