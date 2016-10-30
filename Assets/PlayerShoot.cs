using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public double shootInterval = 0.5d;
	public GameObject rayOrigin;
	LineRenderer lineRenderer;

	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
	}

    void Update()
    {
        if (shootInterval > 0)
        {
            shootInterval -= Time.deltaTime;
        }

    }
	void FixedUpdate () {
        if ((Input.GetMouseButton(0) && shootInterval <= 0)) {
			Shoot ();
            shootInterval = 0.5d;
		}	
	}

	void Shoot(){
		
		RaycastHit hit;
		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		Physics.Raycast (Camera.main.transform.position, fwd, 20);

	}
}
