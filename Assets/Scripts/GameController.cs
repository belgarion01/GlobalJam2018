using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public Transform spawner1;
	public Transform spawner2;
	public Transform spawner3;
	public Transform spawner4;
	public Transform spawner5;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public GameObject ennemy;

	private int wspawner;
	private int stockage;

	void Start () {
		//InvokeRepeating ("SpawnProj", 2f, 1f);
	}
	

	void Update () {
		if (PlayerController.echange1 && Player2Controller.echange2) {
			stockage = PlayerController.objectactif1;
			PlayerController.objectactif1 = Player2Controller.objectactif2;
			Player2Controller.objectactif2 = stockage;
			PlayerController.echange1 = false;
			Player2Controller.echange2 = false;
		}
		if (PlayerController.echange1 && PlayerController3.echange3) {
			stockage = PlayerController.objectactif1;
			PlayerController.objectactif1 = PlayerController3.objectactif3;
			PlayerController3.objectactif3 = stockage;
			PlayerController.echange1 = false;
			PlayerController3.echange3 = false;
		}
		if (PlayerController.echange1 && PlayerController4.echange4) {
			stockage = PlayerController.objectactif1;
			PlayerController.objectactif1 = PlayerController4.objectactif4;
			PlayerController4.objectactif4 = stockage;
			PlayerController.echange1 = false;
			PlayerController4.echange4 = false;
		}
		if (Player2Controller.echange2 && PlayerController3.echange3) {
			stockage = Player2Controller.objectactif2;
			Player2Controller.objectactif2 = PlayerController3.objectactif3;
			PlayerController3.objectactif3 = stockage;
			Player2Controller.echange2 = false;
			PlayerController3.echange3 = false;
		}
		if (Player2Controller.echange2 && PlayerController4.echange4) {
			stockage = Player2Controller.objectactif2;
			Player2Controller.objectactif2 = PlayerController4.objectactif4;
			PlayerController4.objectactif4 = stockage;
			Player2Controller.echange2 = false;
			PlayerController4.echange4 = false;
		}
		if (PlayerController3.echange3 && PlayerController4.echange4) {
			stockage = PlayerController3.objectactif3;
			PlayerController3.objectactif3 = PlayerController4.objectactif4;
			PlayerController4.objectactif4 = stockage;
			PlayerController3.echange3 = false;
			PlayerController4.echange4 = false;
		}

	}
		
	void SpawnProj()
	{
		wspawner = Random.Range (0, 5);
		switch(wspawner)
		{
		case 0:
			Instantiate (ennemy, spawner1.position, Quaternion.identity);
			break;
		case 1:
			Instantiate (ennemy, spawner2.position, Quaternion.identity);
			break;
		case 2:
			Instantiate (ennemy, spawner3.position, Quaternion.identity);
			break;
		case 3:
			Instantiate (ennemy, spawner4.position, Quaternion.identity);
			break;
		case 4:
			Instantiate (ennemy, spawner5.position, Quaternion.identity);
			break;
		}
	}
}
