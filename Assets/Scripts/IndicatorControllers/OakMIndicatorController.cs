using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OakMIndicatorController : MonoBehaviour {

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
		OakMediumController.onOakMediumCubeInSlot += greenLight;
		OakMediumController.onOakMediumCubeOutOfSlot += redLight;
	}

	// Called when disabled or destroyed
	void OnDisable() {
		OakMediumController.onOakMediumCubeInSlot -= greenLight;
		OakMediumController.onOakMediumCubeOutOfSlot -= redLight;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
