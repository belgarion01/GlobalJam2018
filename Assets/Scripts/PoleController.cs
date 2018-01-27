using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : Enemy {

	void Update() {
		transform.position -= new Vector3((GameManager.Instance.scrollSpeed) * Time.deltaTime, 0, 0);
		if (transform.position.x < -20) {
			Destroy(gameObject);
		}
	}

}