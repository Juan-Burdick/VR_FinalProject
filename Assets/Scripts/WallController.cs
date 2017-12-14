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
	private bool doCheck = true;
	
	// Use this for initialization
	void Start () {
		mTarget = transform.Find("ClickyButtonTargetThingy").gameObject;
		mBall1 = transform.Find("GrabSphere1").gameObject;
		mBall2 = transform.Find("GrabSphere2").gameObject;
		mBall3 = transform.Find("GrabSphere3").gameObject;
		mBall4 = transform.Find("GrabSphere4").gameObject;
	}

	// Check if any ball hit targets
	bool wasHit() {
		if (did1hit() || did2hit() || did3hit() || did4hit()) { return true; }
		else { return false; }
	}

	#region SphereHits
		// check if sphere 1 hit
		bool did1hit() {
			Vector3 wall = mTarget.transform.position;
			Vector3 ball = mBall1.transform.position;
			if ((Mathf.Abs (wall.x - ball.x) < tolerance)
	 	 	 && (Mathf.Abs (wall.y - ball.y) < tolerance)
	 		 && (Mathf.Abs (wall.z - ball.z) < tolerance)) { return true; }
			else { return false; }
		}

		// check if sphere 2 hit
		bool did2hit() {
			Vector3 wall = mTarget.transform.position;
			Vector3 ball = mBall2.transform.position;
			if ((Mathf.Abs (wall.x - ball.x) < tolerance)
	 		 && (Mathf.Abs (wall.y - ball.y) < tolerance)
	 		 && (Mathf.Abs (wall.z - ball.z) < tolerance)) { return true; }
			else { return false; }
		}

		// check if sphere 3 hit
		bool did3hit() {
			Vector3 wall = mTarget.transform.position;
			Vector3 ball = mBall3.transform.position;
			if ((Mathf.Abs (wall.x - ball.x) < tolerance)
	 		 && (Mathf.Abs (wall.y - ball.y) < tolerance)
	 		 && (Mathf.Abs (wall.z - ball.z) < tolerance)) { return true; }
			else { return false; }
		}

		// check if sphere 4 hit
		bool did4hit() {
			Vector3 wall = mTarget.transform.position;
			Vector3 ball = mBall4.transform.position;
			if ((Mathf.Abs (wall.x - ball.x) < tolerance)
	 		 && (Mathf.Abs (wall.y - ball.y) < tolerance)
	 		 && (Mathf.Abs (wall.z - ball.z) < tolerance)) { return true; }
			else { return false; }
		}
	#endregion

	// Update is called once per frame
	void Update () {
		if (doCheck) {
			if (wasHit()) {
				transform.Translate(0, -1100, 0);
				Destroy(mBall1);
				Destroy(mBall2);
				Destroy(mBall3);
				Destroy(mBall4);
				doCheck = false;
			}
		}
	}
}
