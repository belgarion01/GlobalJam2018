﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaIle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-0.0025f, 0f, 0f));
	}
}
