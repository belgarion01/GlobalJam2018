using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParaNuage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-0.005f, 0f, 0f));
	}
}
