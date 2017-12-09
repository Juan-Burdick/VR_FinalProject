using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Controller : MonoBehaviour {

	private GameObject mWall;

	// Use this for initialization
	void Start () {
		mWall = transform.Find("Puzzle1_Wall").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (mWall.transform.position.y <= -1000) {
			// Delete invisible walls
		}
	}
}
