using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupEpee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.CompareTag("Ennemy"))
			{
				Destroy(other.gameObject);
			}
	}
}
