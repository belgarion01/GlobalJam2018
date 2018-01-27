using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollBlockC1 : MonoBehaviour {

	public static bool topjoueur;

	void Start () {

	}


	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			topjoueur = true; //Quand y'a qqun
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			topjoueur = false; //Quand y'a qqun
		}
	}
}
