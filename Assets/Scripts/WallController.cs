using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	private GameObject mTarget;

	// Use this for initialization
	void Start () {
		mTarget = transform.Find("ClickyButtonTargetThingy").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (mTarget.GetComponent<Renderer> ().material.color == Color.red) {
			transform.Translate(0, -1100, 0);
		}
	}
}
