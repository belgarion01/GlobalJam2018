using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VraiBoutonCommande : MonoBehaviour {

	public Camera cam;

	private bool hover = false;

	void Start () {
	}


	void Update () {
			if (hover) {
				if (Input.GetMouseButtonDown (0)) {
					Invoke ("RetourPrincipal", 0.1f);
				}
			}

	}

	void RetourPrincipal()
	{
		cam.transform.position = new Vector3 (20.5f, 0f, -1f);
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
