using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	public int playerspeed = 2;
	public int sens = 2;
	public int jumpSpeed = 5;
	float vrot = 0;
	public int vrange = 60;
	float vvelocity = 0;

	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		characterController = GetComponent<CharacterController>();
	}

	void Update ()
	{
		// Camera switching

			float hrot = Input.GetAxis ("Mouse X") * sens;
			transform.Rotate (0, hrot, 0);

			vrot -= Input.GetAxis ("Mouse Y") * sens;

			vrot = Mathf.Clamp (vrot, -vrange, vrange);

			Camera.main.transform.localRotation = Quaternion.Euler (vrot, 0, 0);


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