using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLidController : MonoBehaviour {
	private VRTK.VRTK_InteractableObject interactScript;

	private bool cmGreen = false;
	private bool csGreen = false;
	private bool wmGreen = false;
	private bool wsGreen = false;
	private bool omGreen = false;
	private bool osGreen = false;

	// Use this for initialization
	void Start () {
		interactScript = GetComponent<VRTK.VRTK_InteractableObject>();
		interactScript.isGrabbable = false; //lid is ungrabbable now
	}
	
	// Sphere is unlocked and may be grabbed
	void UnlockChest() {
		interactScript.isGrabbable = true;
	}

	#region Cherry
		// CherryMedium was solved
		void setCherryMediumGreen() { cmGreen = true; } 
		// CherryMedium was de-solved
		void setCherryMediumRed() { cmGreen = false; }
		// CherrySmall was solved
		void setCherrySmallGreen() { csGreen = true; } 
		// CherrySmall was de-solved
		void setCherrySmallRed() { csGreen = false; } 
	#endregion
	#region Walnut
		// WalnutMedium was solved
		void setWalnutMediumGreen() { wmGreen = true; } 
		// WalnutMedium was de-solved
		void setWalnutMediumRed() { wmGreen = false; }
		// WalnutSmall was solved
		void setWalnutSmallGreen() { wsGreen = true; } 
		// WalnutSmall was de-solved
		void setWalnutSmallRed() { wsGreen = false; } 
	#endregion
	#region Oak
		// OakMedium was solved
		void setOakMediumGreen() { omGreen = true; } 
		// OakMedium was de-solved
		void setOakMediumRed() { omGreen = false; }
		// OakSmall was solved
		void setOakSmallGreen() { osGreen = true; } 
		// OakSmall was de-solved
		void setOakSmallRed() { osGreen = false; } 
	#endregion

	// Called when object containing script is created or enabled
	void OnEnable() {
		#region CherryCalls
			CherryMediumController.onCherryMediumCubeInSlot += setCherryMediumGreen;
			CherryMediumController.onCherryMediumCubeOutOfSlot += setCherryMediumRed;
			CherrySmallController.onCherrySmallCubeInSlot += setCherrySmallGreen;
			CherrySmallController.onCherrySmallCubeOutOfSlot += setCherrySmallRed;
		#endregion
		#region WalnutCalls
			WalnutMediumController.onWalnutMediumCubeInSlot += setWalnutMediumGreen;
			WalnutMediumController.onWalnutMediumCubeOutOfSlot += setWalnutMediumRed;
			WalnutSmallController.onWalnutSmallCubeInSlot += setWalnutSmallGreen;
			WalnutSmallController.onWalnutSmallCubeOutOfSlot += setWalnutSmallRed;
		#endregion
		#region OakCalls
			OakMediumController.onOakMediumCubeInSlot += setOakMediumGreen;
			OakMediumController.onOakMediumCubeOutOfSlot += setOakMediumRed;
			OakSmallController.onOakSmallCubeInSlot += setOakSmallGreen;
			OakSmallController.onOakSmallCubeOutOfSlot += setOakSmallRed;
		#endregion
	}

	// Called when disabled or destroyed
	void OnDisable() {
		#region CherryCalls
			CherryMediumController.onCherryMediumCubeInSlot -= setCherryMediumGreen;
			CherryMediumController.onCherryMediumCubeOutOfSlot -= setCherryMediumRed;
			CherrySmallController.onCherrySmallCubeInSlot -= setCherrySmallGreen;
			CherrySmallController.onCherrySmallCubeOutOfSlot -= setCherrySmallRed;
		#endregion
		#region WalnutCalls
			WalnutMediumController.onWalnutMediumCubeInSlot -= setWalnutMediumGreen;
			WalnutMediumController.onWalnutMediumCubeOutOfSlot -= setWalnutMediumRed;
			WalnutSmallController.onWalnutSmallCubeInSlot -= setWalnutSmallGreen;
			WalnutSmallController.onWalnutSmallCubeOutOfSlot -= setWalnutSmallRed;
		#endregion
		#region OakCalls
			OakMediumController.onOakMediumCubeInSlot -= setOakMediumGreen;
			OakMediumController.onOakMediumCubeOutOfSlot -= setOakMediumRed;
			OakSmallController.onOakSmallCubeInSlot -= setOakSmallGreen;
			OakSmallController.onOakSmallCubeOutOfSlot -= setOakSmallRed;
		#endregion
	}

	// Update is called once per frame
	void Update () {
		if (cmGreen && csGreen 
		 && wmGreen && wsGreen
		 && omGreen && osGreen) { UnlockChest(); }
	}
}
