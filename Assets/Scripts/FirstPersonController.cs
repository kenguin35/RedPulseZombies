﻿using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	public int playerspeed = 2;
	public int sens = 2;
	public int jumpSpeed = 5;
	float vrot = 0;
	public int vrange = 60;
	float vvelocity = 0;
	float bob = 0.01f;
	float bobrange = 0.15f;
	float tbob = 0f;
	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		characterController = GetComponent<CharacterController>();
	}

	void Update ()
	{
		float hrot = Input.GetAxis ("Mouse X") * sens;
		transform.Rotate (0, hrot, 0);

		if (GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>().enabled == true) {
			vrot -= Input.GetAxis ("Mouse Y") * sens;
			vrot = Mathf.Clamp (vrot, -vrange, vrange);
            
			CameraSwitch.ACTIVE_CAMERA.transform.localRotation = Quaternion.Euler (vrot, 0, 0);
			//view bobbing
				if ((characterController.velocity != Vector3.zero) && (characterController.isGrounded == true)) {
					tbob += bob;
					Vector3 bobbing = new Vector3 (0, bob, 0);
					CameraSwitch.ACTIVE_CAMERA.transform.position = CameraSwitch.ACTIVE_CAMERA.transform.position + bobbing;
						if ((tbob > bobrange)) {
							bob = -0.01f;
						} else if (tbob == 0) {
							if (Random.Range (0, 3) == 1) {
								bob = 0.01f;
							} else {
								bob = 0.0f;
						}
					}
				}
			}
			// Movement

			float forwardSpeed = Input.GetAxis ("Vertical") * playerspeed;
			float strafe = Input.GetAxis ("Horizontal") * playerspeed;

			vvelocity += Physics.gravity.y * Time.deltaTime;

			if (characterController.isGrounded && Input.GetButton ("Jump")) {
				vvelocity = jumpSpeed;
			}

			Vector3 speed = new Vector3 (strafe, vvelocity, forwardSpeed);

			speed = transform.rotation * speed;

			characterController.Move (speed * Time.deltaTime);
		}
	}