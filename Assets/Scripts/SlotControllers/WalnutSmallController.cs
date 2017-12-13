using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalnutSmallController : MonoBehaviour {

	public delegate void onWalnutSmallSolved();
	public delegate void onWalnutSmallUnsolved();

	public static event onWalnutSmallSolved onWalnutSmallCubeInSlot;
	public static event onWalnutSmallUnsolved onWalnutSmallCubeOutOfSlot;

	public float tolerance = 0.3f;

	private GameObject mSlot;
	private GameObject mCube;
	private bool wasSolved = false;

	// Use this for initialization
	void Start () {
		mSlot = transform.Find("Walnut_Small_Slot").gameObject;
		mCube = transform.Find("Walnut_Small_Cube").gameObject;
	}

	// Return true if Walnut Small is solved
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
		onWalnutSmallCubeInSlot();
		wasSolved = true;
	}

	// Called onUpdate if unsolved - if wasSolved, inform scripts
	void unSolved() {
		if(wasSolved == true) {
			onWalnutSmallCubeOutOfSlot();
			wasSolved = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if(isSolved()) { solved(); }
		else { unSolved(); }
	}
}
