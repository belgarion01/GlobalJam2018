using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonCommand : MonoBehaviour {

	public Camera cam;

	private bool hover = false;
	private bool change  = false;

	public Sprite noir;
	public Sprite rouge;
	public Sprite blanc;

	private SpriteRenderer spriter;

	void Start () {
		spriter = GetComponent<SpriteRenderer> ();
	}
	

	void Update () {

		if (!change) {
			if (hover) {
				spriter.sprite = noir;
				if (Input.GetMouseButtonDown (0)) {
					spriter.sprite = rouge;
					change = true;
					Invoke ("RetourPrincipal", 0.1f);
				}
			} else {
				spriter.sprite = blanc;
			}
		}

	}

	void RetourPrincipal()
	{
		cam.transform.position = new Vector3 (0, 0, -1f);
		change = false;
		spriter.sprite = blanc;
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
