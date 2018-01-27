using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repositionne : MonoBehaviour {

	public Camera mycam;

	public float distanceCible;
	public float distanceTP;

	private float distance;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Magnitude (transform.position - mycam.transform.position);
		if (distance > distanceCible) {
			transform.position += new Vector3 (distanceTP, 0f, 0f);
		}
		Debug.Log (distance);
	}
}
