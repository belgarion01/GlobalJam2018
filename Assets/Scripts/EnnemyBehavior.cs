using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour {

	public float speed;

	void Start () {
		
	}

	void Update () {
		transform.Translate(new Vector2(speed, 0f));
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Destroy(other.gameObject);
		}
	}
}
