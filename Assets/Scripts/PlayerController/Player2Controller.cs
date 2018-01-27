using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

	public static int objectactif2 = 1;
	public static bool echange2;

	public GameObject epee;
	public GameObject shield;

	private int position = 2;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			echange2 = true;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			/*switch (objectactif2) {
			case: 1
				Instantiate (epee, transform.position, Quaternion.identity);
				break;
			case: 2
				Instantiate (shield, transform.position, Quaternion.identity);
			};*/
		}
		if(Input.GetKeyDown(KeyCode.Z)&&position!=1&&!CollBlockB1.topjoueur)
		{
			transform.position += new Vector3(0f, 2f, 0f);
			position -= 1; 
		}
		if(Input.GetKeyDown(KeyCode.S)&&position!=5&&!CollBlockB2.botjoueur)
		{
			transform.position += new Vector3(0f, -2f, 0f);
			position += 1; 
		}
	}
}
