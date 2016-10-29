using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {
	public string[] PrimaryGuns = {"Gun1", "Gun2", "Gun3"};
	public string[] SecondaryGuns = { "Pistol1", "Pistol2", "Pistol3" };
	//Current Primary & Secondary Guns
	public int currentPGun;
	public int currentSGun;
	//If a primary or secondary gun is held
	bool holdingPGun;
	bool holdingSGun;
	// Use this for initialization
	void Start () {
		//starting guns
		currentPGun = -1;
		currentSGun = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentPGun > -1) {
			holdingPGun = true;
		} else {
			holdingPGun = false;
		}
		if (currentSGun > -1) {
			holdingSGun = false;
		} else {
			holdingSGun = true;
		}
	}
}
