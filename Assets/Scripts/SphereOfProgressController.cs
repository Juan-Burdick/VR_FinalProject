using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereOfProgressController : MonoBehaviour {
	private VRTK.VRTK_InteractableObject interactScript;

	// Use this for initialization
	void Start () {
		interactScript = GetComponent<VRTK.VRTK_InteractableObject>();
		interactScript.isGrabbable = false; //sphere is ungrabbable now
	}

	// Sphere is unlocked and may be grabbed
	void UnlockSphereOfProgress() {
		GetComponent<Renderer> ().material.color = Color.yellow;
		interactScript.isGrabbable = true;
	}

	// Called when object containing script is created or enabled
	void OnEnable() {
		SimpleBlockPuzzleController.onPuzzleSolved += UnlockSphereOfProgress;
	}

	// Called when disabled or destroyed
	void OnDisable() {
		SimpleBlockPuzzleController.onPuzzleSolved -= UnlockSphereOfProgress;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
