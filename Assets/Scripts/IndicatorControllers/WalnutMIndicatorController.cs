using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalnutMIndicatorController : MonoBehaviour {

	private GameObject indicator1;
	private GameObject indicator2;

	// Use this for initialization
	void Start () {
		indicator1 = transform.Find("Red_Green_Indicator1").gameObject;
		indicator2 = transform.Find("Red_Green_Indicator2").gameObject;
	}
	
	// Box is in place, show green indicator
	void greenLight() {
		indicator1.GetComponent<Renderer>().material.color = Color.green;
		indicator2.GetComponent<Renderer>().material.color = Color.green;
	}

	// Box was moved out of place, show red indicator
	void redLight() {
		indicator1.GetComponent<Renderer>().material.color = Color.red;
		indicator2.GetComponent<Renderer>().material.color = Color.red;
	}

	// Called when object containing script is created or enabled
	void OnEnable() {
		WalnutMediumController.onWalnutMediumCubeInSlot += greenLight;
		WalnutMediumController.onWalnutMediumCubeOutOfSlot += redLight;
	}

	// Called when disabled or destroyed
	void OnDisable() {
		WalnutMediumController.onWalnutMediumCubeInSlot -= greenLight;
		WalnutMediumController.onWalnutMediumCubeOutOfSlot -= redLight;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
