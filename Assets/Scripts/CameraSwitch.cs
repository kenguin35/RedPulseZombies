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
		if (Input.GetKeyDown(KeyCode.Q)){
			if (fpc.isActiveAndEnabled == true){
				ShowOverheadView ();
			}else{
				ShowFirstPersonView ();
			}
		}
	}
}