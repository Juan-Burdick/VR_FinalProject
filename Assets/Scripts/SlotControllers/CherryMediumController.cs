using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryMediumController : MonoBehaviour {

	public delegate void onCherryMediumSolved();
	public delegate void onCherryMediumUnsolved();

	public static event onCherryMediumSolved onCherryMediumCubeInSlot;
	public static event onCherryMediumUnsolved onCherryMediumCubeOutOfSlot;

	public float tolerance = 0.3f;

	private GameObject mSlot;
	private GameObject mCube;
	private bool wasSolved = false;

	// Use this for initialization
	void Start () {
		mSlot = transform.Find("Cherry_Medium_Slot").gameObject;
		mCube = transform.Find("Cherry_Medium_Cube").gameObject;
	}

	// Return true if cherry medium is solved
	bool isSolved() {
		Vector3 SlotV = mSlot.transform.position;
		Vector3 CubeV = mCube.transform.position;
		if (Mathf.Abs (SlotV.x - CubeV.x) < tolerance
	 	 && Mathf.Abs (SlotV.y - CubeV.y) < tolerance
	 	 && Mathf.Abs (SlotV.z -CubeV.z) < tolerance) { return true; }
		else { return false; }
	}

	// Inform scripts of solved state
	void solved() {
		onCherryMediumCubeInSlot();
		wasSolved = true;
	}

	// Called onUpdate if unsolved - if wasSolved, inform scripts
	void unSolved() {
		if(wasSolved == true) {
			onCherryMediumCubeOutOfSlot();
			wasSolved = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if(isSolved()) { solved(); }
		else { unSolved(); }
	}
}
