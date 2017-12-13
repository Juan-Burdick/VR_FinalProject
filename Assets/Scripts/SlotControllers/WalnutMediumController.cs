using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalnutMediumController : MonoBehaviour {

	public delegate void onWalnutMediumSolved();
	public delegate void onWalnutMediumUnsolved();

	public static event onWalnutMediumSolved onWalnutMediumCubeInSlot;
	public static event onWalnutMediumUnsolved onWalnutMediumCubeOutOfSlot;

	public float tolerance = 0.3f;

	private GameObject mSlot;
	private GameObject mCube;
	private bool wasSolved = false;

	// Use this for initialization
	void Start () {
		mSlot = transform.Find("Walnut_Medium_Slot").gameObject;
		mCube = transform.Find("Walnut_Medium_Cube").gameObject;
	}

	// Return true if Walnut medium is solved
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
		onWalnutMediumCubeInSlot();
		wasSolved = true;
	}

	// Called onUpdate if unsolved - if wasSolved, inform scripts
	void unSolved() {
		if(wasSolved == true) {
			onWalnutMediumCubeOutOfSlot();
			wasSolved = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if(isSolved()) { solved(); }
		else { unSolved(); }
	}
}
