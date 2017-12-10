using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Controller : MonoBehaviour {

	private GameObject mVisibleWall;
	private GameObject mInvisibleWalls;

	// Use this for initialization
	void Start () {
		mVisibleWall = transform.Find("Puzzle1_Wall").gameObject;
		mInvisibleWalls = transform.Find("Puzzle1_TeleportBoundaries").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (mVisibleWall.transform.position.y <= -1000) {
			Destroy(mInvisibleWalls);
		}
	}
}
