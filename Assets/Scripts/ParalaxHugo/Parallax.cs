using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public Vector3 value;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (value);
	}
}
