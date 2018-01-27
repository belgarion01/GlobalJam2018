using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollBlockA2 : MonoBehaviour {

	public static bool botjoueur;

	void Start () {

	}


	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			botjoueur = true; //Quand y'a qqun
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			botjoueur = false; //Quand y'a qqun
		}
	}
}
