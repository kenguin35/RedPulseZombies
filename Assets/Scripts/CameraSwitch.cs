using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	//fpc = first person camera
	public Camera fpc;
	//tpc = third person camera
	public Camera tpc;
    public static Camera ACTIVE_CAMERA;
	void Start(){
		fpc.enabled = true;
		tpc.enabled = false;
        ACTIVE_CAMERA = fpc;
	}
	public void ShowOverheadView() {
		fpc.enabled = false;
		tpc.enabled = true;
        ACTIVE_CAMERA = tpc;
    }

	public void ShowFirstPersonView() {
		tpc.enabled = false;
		fpc.enabled = true;
        ACTIVE_CAMERA = fpc;
    }
	void Update(){
		print ("Update is running");
		if (Input.GetKeyDown(KeyCode.Q)){
			print ("Key press is working");
			if (fpc.isActiveAndEnabled == true){
				print ("Camera check is working");
				ShowOverheadView ();
			}else{
				ShowFirstPersonView ();
			}
		}
	}
}