using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	public float tolerance = 0.3f;

	private GameObject mTarget;
	private GameObject mBall1;
	private GameObject mBall2;
	private GameObject mBall3;
	private GameObject mBall4;
	private Vector3 mTargetPos;
	private Vector3 mSphere1;
	private Vector3 mSphere2;
	private Vector3 mSphere3;
	private Vector3 mSphere4;
	
	// Use this for initialization
	void Start () {
		mTarget = transform.Find("ClickyButtonTargetThingy").gameObject;
		mBall1 = transform.Find("GrabSphere1").gameObject;
		mBall2 = transform.Find("GrabSphere2").gameObject;
		mBall3 = transform.Find("GrabSphere3").gameObject;
		mBall4 = transform.Find("GrabSphere4").gameObject;
		mTargetPos = mTarget.transform.position;
		mSphere1 = mBall1.transform.position;
		mSphere2 = mBall2.transform.position;
		mSphere3 = mBall3.transform.position;
		mSphere4 = mBall4.transform.position;
	}

	// Check if target was hit, turn blue if it was
	bool wasHit() {
		if (wasHitX() && wasHitY() && wasHitZ()) { return true; }
		else { return false; }
	}

	// Check if x is within tolerance
	bool wasHitX() {
		if ((Mathf.Abs (mTargetPos.x - mSphere1.x) < tolerance)
	 	 || (Mathf.Abs (mTargetPos.x - mSphere2.x) < tolerance)
	 	 || (Mathf.Abs (mTargetPos.x - mSphere3.x) < tolerance)
		 || (Mathf.Abs (mTargetPos.x - mSphere4.x) < tolerance)) { return true; }
		else { return false; }
	}

	// Check if y is within tolerance
	bool wasHitY() {
		if ((Mathf.Abs (mTargetPos.y - mSphere1.y) < tolerance)
	 	 || (Mathf.Abs (mTargetPos.y - mSphere2.y) < tolerance)
	 	 || (Mathf.Abs (mTargetPos.y - mSphere3.y) < tolerance)
		 || (Mathf.Abs (mTargetPos.y - mSphere4.y) < tolerance)) { return true; }
		else { return false; }
	}

	// Check if z is within tolerance
	bool wasHitZ() {
		if ((Mathf.Abs (mTargetPos.z - mSphere1.z) < tolerance)
	 	 || (Mathf.Abs (mTargetPos.z - mSphere2.z) < tolerance)
	 	 || (Mathf.Abs (mTargetPos.z - mSphere3.z) < tolerance)
		 || (Mathf.Abs (mTargetPos.z - mSphere4.z) < tolerance)) { return true; }
		else { return false; }
	}
	
	// Update is called once per frame
	void Update () {
		if (wasHit()) {
			transform.Translate(0, -1100, 0);
			Destroy(mBall1);
			Destroy(mBall2);
			Destroy(mBall3);
			Destroy(mBall4);
		}
	}
}
