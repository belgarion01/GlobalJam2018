using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGuyController : MonoBehaviour {

	public float additionnalMoveSpeed;

	void Awake() {

	}

	void Update() {
		transform.position -= new Vector3((GameManager.Instance.scrollSpeed + additionnalMoveSpeed) * Time.deltaTime, 0, 0);
		if (transform.position.x < -20) {
			Destroy(gameObject);
		}
	}

}