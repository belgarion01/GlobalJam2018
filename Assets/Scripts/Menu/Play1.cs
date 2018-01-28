using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play1 : MonoBehaviour {

	private bool hover;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hover) {
			if (Input.GetMouseButton(0)) {
				SceneManager.LoadScene ("main");
			}
		}
	}

	void OnMouseEnter()
	{
		hover = true;
	}
	void OnMouseExit()
	{
		hover = false;
	}
}
