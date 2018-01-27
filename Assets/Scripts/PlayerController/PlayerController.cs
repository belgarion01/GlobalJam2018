using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public static int objectactif1 = 1;
	public static bool echange1;

	public GameObject epee;
	public GameObject shield;

	private int position = 3;

	private int temp;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			echange1 = true;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			/*switch (objectactif1) {
			case: 1
				Instantiate (epee, transform.position, Quaternion.identity);
				break;
			case: 2
				Instantiate (shield, transform.position, Quaternion.identity);
			}*/
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)&&position!=1&&!CollBlockA1.topjoueur)
			{
				transform.position += new Vector3(0f, 2f, 0f);
			position -= 1; 
			}
		if(Input.GetKeyDown(KeyCode.DownArrow)&&position!=5&&!CollBlockA2.botjoueur)
		{
			transform.position += new Vector3(0f, -2f, 0f);
			position += 1; 
		}
		Debug.Log (objectactif1);
	}
}
