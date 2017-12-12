using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_Controller : MonoBehaviour {

	public delegate void onSolved();
	public static event onSolved onPuzzleSolved;
	public float tolerance = .1f;

	private GameObject mTable;
	private GameObject indicatorSetter;
	#region SlotsDeclaration
		#region CherrySlotDeclaration
			private GameObject mMediumCherrySlot;
			private GameObject mSmallCherrySlot;
		#endregion
		#region WalnutSlotDeclaration
			private GameObject mMediumWalnutSlot;
			private GameObject mSmallWalnutSlot;
		#endregion
		#region OakSlotDeclaration
			private GameObject mMediumOakSlot;
			private GameObject mSmallOakSlot;
		#endregion
	#endregion
	#region CubesDeclaration
		#region CherryCubeDeclaration
			private GameObject mMediumCherryCube;
			private GameObject mSmallCherryCube;
		#endregion
		#region WalnutCubeDeclaration
			private GameObject mMediumWalnutCube;
			private GameObject mSmallWalnutCube;
		#endregion
		#region OakCubeDeclaration
			private GameObject mMediumOakCube;
			private GameObject mSmallOakCube;
		#endregion
	#endregion
	#region IndicatorDeclaration
		#region CherryIndicators
			private GameObject CMI1;
			private GameObject CMI2;
			private GameObject CSI1;
			private GameObject CSI2;
		#endregion
		#region WalnutIndicators
			private GameObject WMI1;
			private GameObject WMI2;
			private GameObject WSI1;
			private GameObject WSI2;
		#endregion
		#region OakIndicators
			private GameObject OMI1;
			private GameObject OMI2;
			private GameObject OSI1;
			private GameObject OSI2;
		#endregion
	#endregion

	// Use this for initialization
	void Start () {
		mTable = transform.Find("Puzzle2_Table").gameObject;
		#region SetSlots
			#region SetCherrySlots
				mMediumCherrySlot = transform.Find("Cherry_Medium_Slot").gameObject;
				mSmallCherrySlot = transform.Find("Cherry_Small_Slot").gameObject;
	    	#endregion
			#region SetWalnutSlots
				mMediumWalnutSlot = transform.Find("Walnut_Medium_Slot").gameObject;
	    		mSmallWalnutSlot = transform.Find("Walnut_Small_Slot").gameObject;
	    	#endregion
			#region SetOakSlots
				mMediumOakSlot = transform.Find("Oak_Medium_Slot").gameObject;
				mSmallOakSlot = transform.Find("Oak_Small_Slot").gameObject;
	    	#endregion
		#endregion
		#region SetCubes
			#region SetCherryCubes
				mMediumCherryCube = transform.Find("Cherry_Medium_Cube").gameObject;
	    		mSmallCherryCube = transform.Find("Cherry_Small_Cube").gameObject;
	    	#endregion
			#region SetWalnutCubes
				mMediumWalnutCube = transform.Find("Walnut_Medium_Cube").gameObject;
	    		mSmallWalnutCube = transform.Find("Walnut_Small_Cube").gameObject;
	    	#endregion
			#region SetOakCubes
				mMediumOakCube = transform.Find("Oak_Medium_Cube").gameObject;
	    		mSmallOakCube = transform.Find("Oak_Small_Cube").gameObject;
			#endregion
		#endregion
		#region SetIndicators
			#region SetCherryIndicators
				indicatorSetter = transform.Find("Cherry_MediumIndicator").gameObject;
				CMI1 = indicatorSetter.transform.Find("Red_Green_Indicator1").gameObject;
				CMI2 = indicatorSetter.transform.Find("Red_Green_Indicator2").gameObject;
				indicatorSetter = transform.Find("Cherry_SmallIndicator").gameObject;
				CSI1 = indicatorSetter.transform.Find("Red_Green_Indicator1").gameObject;
				CSI2 = indicatorSetter.transform.Find("Red_Green_Indicator2").gameObject;
			#endregion
			#region SetWalnutIndicators
				indicatorSetter = transform.Find("Walnut_MediumIndicator").gameObject;
				WMI1 = indicatorSetter.transform.Find("Red_Green_Indicator1").gameObject;
				WMI2 = indicatorSetter.transform.Find("Red_Green_Indicator2").gameObject;
				indicatorSetter = transform.Find("Walnut_SmallIndicator").gameObject;
				WSI1 = indicatorSetter.transform.Find("Red_Green_Indicator1").gameObject;
				WSI2 = indicatorSetter.transform.Find("Red_Green_Indicator2").gameObject;
			#endregion
			#region SetOakIndicators
				indicatorSetter = transform.Find("Oak_MediumIndicator").gameObject;
				OMI1 = indicatorSetter.transform.Find("Red_Green_Indicator1").gameObject;
				OMI2 = indicatorSetter.transform.Find("Red_Green_Indicator2").gameObject;
				indicatorSetter = transform.Find("Oak_SmallIndicator").gameObject;
				OSI1 = indicatorSetter.transform.Find("Red_Green_Indicator1").gameObject;
				OSI2 = indicatorSetter.transform.Find("Red_Green_Indicator2").gameObject;
			#endregion
		#endregion
	}
	
	// Return true if the puzzle is solved
	bool isSolved() {
		if (isCherrySolved() 
		 && isWalnutSolved() 
		 && isOakSolved()) { return true; }
		else { return false; }
	}

	#region isCherrySolved
		// Return true if cherry is solved
		bool isCherrySolved() {
			if (isCherryMediumSolved() 
		 	 && isCherrySmallSolved()) { return true; }
			else { return false; }
		}

		// Return true if cherry medium is solved
		bool isCherryMediumSolved() {
			Vector3 CMS_Pos = mMediumCherrySlot.transform.position;
			Vector3 CMC_Pos = mMediumCherryCube.transform.position;
			if (Mathf.Abs (CMS_Pos.x - CMC_Pos.x) < tolerance
		 	 && Mathf.Abs (CMS_Pos.y - CMC_Pos.y) < tolerance
		 	 && Mathf.Abs (CMS_Pos.z - CMC_Pos.z) < tolerance) {
				CMI1.GetComponent<Renderer>().material.color = Color.green;
				CMI2.GetComponent<Renderer>().material.color = Color.green;
				return true;
			}
			else {
				CMI1.GetComponent<Renderer>().material.color = Color.red;
				CMI2.GetComponent<Renderer>().material.color = Color.red;
				return false;
			}
		}

		// Return true if cherry small is solved
		bool isCherrySmallSolved() {
			Vector3 CSS_Pos = mSmallCherrySlot.transform.position;
			Vector3 CSC_Pos = mSmallCherryCube.transform.position;
			if (Mathf.Abs (CSS_Pos.x - CSC_Pos.x) < tolerance
		 	 && Mathf.Abs (CSS_Pos.y - CSC_Pos.y) < tolerance
		 	 && Mathf.Abs (CSS_Pos.z - CSC_Pos.z) < tolerance) {
				CSI1.GetComponent<Renderer>().material.color = Color.green;
				CSI2.GetComponent<Renderer>().material.color = Color.green;
				return true;
			}
			else {
				CSI1.GetComponent<Renderer>().material.color = Color.red;
				CSI2.GetComponent<Renderer>().material.color = Color.red;
				return false;
			}
		}
	#endregion
	#region isWalnutSolved
		// Return true if walnut is solved
		bool isWalnutSolved() {
			if (isWalnutMediumSolved()
			 && isWalnutSmallSolved()) { return true; }
			else { return false; }
		}

		// Return true if walnut medium is solved
		bool isWalnutMediumSolved() {
			Vector3 WMS_Pos = mMediumWalnutSlot.transform.position;
			Vector3 WMC_Pos = mMediumWalnutCube.transform.position;
			if (Mathf.Abs (WMS_Pos.x - WMC_Pos.x) < tolerance
		 	 && Mathf.Abs (WMS_Pos.y - WMC_Pos.y) < tolerance
		 	 && Mathf.Abs (WMS_Pos.z - WMC_Pos.z) < tolerance) {
				WMI1.GetComponent<Renderer>().material.color = Color.green;
				WMI2.GetComponent<Renderer>().material.color = Color.green;
				return true;
			}
			else {
				WMI1.GetComponent<Renderer>().material.color = Color.red;
				WMI2.GetComponent<Renderer>().material.color = Color.red;
				return false;
			}
		}

		// Return true if walnut small is solved
		bool isWalnutSmallSolved() {
			Vector3 WSS_Pos = mSmallWalnutSlot.transform.position;
			Vector3 WSC_Pos = mSmallWalnutCube.transform.position;
			if (Mathf.Abs (WSS_Pos.x - WSC_Pos.x) < tolerance
		 	 && Mathf.Abs (WSS_Pos.y - WSC_Pos.y) < tolerance
			 && Mathf.Abs (WSS_Pos.z - WSC_Pos.z) < tolerance) {
				WSI1.GetComponent<Renderer>().material.color = Color.green;
				WSI2.GetComponent<Renderer>().material.color = Color.green;
				return true;
			}
			else {
				WSI1.GetComponent<Renderer>().material.color = Color.red;
				WSI2.GetComponent<Renderer>().material.color = Color.red;
				return false;
			}
		}
	#endregion
	#region isOakSolved
		// return true if oak is solved
		bool isOakSolved() {
			if (isOakMediumSolved()
			 && isOakSmallSolved()) { return true; }
			else { return false; }
		}

		// Return true if oak medium is solved
		bool isOakMediumSolved() {
			Vector3 OMS_Pos = mMediumOakSlot.transform.position;
			Vector3 OMC_Pos = mMediumOakCube.transform.position;
			if (Mathf.Abs (OMS_Pos.x - OMC_Pos.x) < tolerance
			 && Mathf.Abs (OMS_Pos.y - OMC_Pos.y) < tolerance
			 && Mathf.Abs (OMS_Pos.z - OMC_Pos.z) < tolerance) {
				OMI1.GetComponent<Renderer>().material.color = Color.green;
				OMI2.GetComponent<Renderer>().material.color = Color.green;
				return true;
			}
			else {
				OMI1.GetComponent<Renderer>().material.color = Color.red;
				OMI2.GetComponent<Renderer>().material.color = Color.red;
				return false;
			}
		}

		// Return true if oak small is solved
		bool isOakSmallSolved() {
			Vector3 OSS_Pos = mSmallOakSlot.transform.position;
			Vector3 OSC_Pos = mSmallOakCube.transform.position;
			if (Mathf.Abs (OSS_Pos.x - OSC_Pos.x) < tolerance
			 && Mathf.Abs (OSS_Pos.y - OSC_Pos.y) < tolerance
			 && Mathf.Abs (OSS_Pos.z - OSC_Pos.z) < tolerance) {
				OSI1.GetComponent<Renderer>().material.color = Color.green;
				OSI2.GetComponent<Renderer>().material.color = Color.green;
				return true;
			}
			else {
				OSI1.GetComponent<Renderer>().material.color = Color.red;
				OSI2.GetComponent<Renderer>().material.color = Color.red;
				return false;
			}
		}
	#endregion

	// Update is called once per frame
	void Update () {
		if(isSolved() && onPuzzleSolved != null) {
			// Notify the other game objects that the puzzle is solved
			onPuzzleSolved ();
		}
	}
}