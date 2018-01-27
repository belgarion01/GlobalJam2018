using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour {

	public static int objectactif3 = 2;
	public static bool echange3;

	public GameObject epee;
	public GameObject shield;

	private int position = 1;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad4)) {
			echange3 = true;
		}
		if (Input.GetKeyDown (KeyCode.Keypad6)) {
			/*switch (objectactif3) {
			case: 1
				Instantiate (epee, transform.position, Quaternion.identity);
				break;
			case: 2
				Instantiate (shield, transform.position, Quaternion.identity);
			}*/
		}
		if(Input.GetKeyDown(KeyCode.Keypad8)&&position!=1&&!CollBlockC1.topjoueur)
		{
			transform.position += new Vector3(0f, 2f, 0f);
			position -= 1; 
		}
		if(Input.GetKeyDown(KeyCode.Keypad5)&&position!=5&&!CollBlockC2.botjoueur)
		{
			transform.position += new Vector3(0f, -2f, 0f);
			position += 1; 
		}
	}
}
