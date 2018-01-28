using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour {

	private bool hover;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (hover) {
			if (Input.GetMouseButtonDown (0)) {
				Invoke ("LaunchGamet", 0.1f);
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

	void LaunchGamet()
	{
		SceneManager.LoadScene ("Game");
	}

}
