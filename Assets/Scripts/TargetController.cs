﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void onCollisionEnter(Collision collision) {
		GetComponent<Renderer> ().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
