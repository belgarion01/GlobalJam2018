using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour {

	public static int objectactif4 = 2;
	public static bool echange4;
	
	public GameObject epee;
	public GameObject shield;

	private int position = 4;

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			echange4 = true;
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			/*switch (objectactif4) {
			case: 1
				Instantiate (epee, transform.position, Quaternion.identity);
				break;
			case: 2
				Instantiate (shield, transform.position, Quaternion.identity);
			}*/
		}
		if(Input.GetKeyDown(KeyCode.Y)&&position!=1&&!CollBlockD1.topjoueur)
		{
			transform.position += new Vector3(0f, 2f, 0f);
			position -= 1; 
		}
		if(Input.GetKeyDown(KeyCode.H)&&position!=5&&!CollBlockD2.botjoueur)
		{
			transform.position += new Vector3(0f, -2f, 0f);
			position += 1; 
		}
	}
}
