using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLidController : MonoBehaviour {
	private VRTK.VRTK_InteractableObject interactScript;

	// Use this for initialization
	void Start () {
		interactScript = GetComponent<VRTK.VRTK_InteractableObject>();
		interactScript.isGrabbable = false; //lid is ungrabbable now
	}
	
	// Sphere is unlocked and may be grabbed
	void UnlockChest() {
		interactScript.isGrabbable = true;
	}

	// Called when object containing script is created or enabled
	void OnEnable() {
		Puzzle2_Controller.onPuzzleSolved += UnlockChest;
	}

	// Called when disabled or destroyed
	void OnDisable() {
		Puzzle2_Controller.onPuzzleSolved -= UnlockChest;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
