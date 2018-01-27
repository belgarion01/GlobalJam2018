using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGuyController : Enemy {

	public float additionalMoveSpeed;

	void Awake() {

	}

	void Update() {
		transform.position -= new Vector3((GameManager.Instance.scrollSpeed + additionalMoveSpeed) * Time.deltaTime, 0, 0);
		if (transform.position.x < -20) {
			Destroy(gameObject);
		}
	}

}