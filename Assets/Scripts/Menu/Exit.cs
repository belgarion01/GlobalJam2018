using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	private bool hover;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hover) {
			if (Input.GetMouseButtonDown (0)) {
				Invoke ("ExitGame", 0.1f);
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

	void ExitGame()
	{
		Application.Quit();
	}
}
