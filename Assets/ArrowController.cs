using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

	public float moveSpeed;
	public LaneController lane;
	public List<SpriteRenderer> renderers;

	void Update() {
		transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
		if (transform.position.x > 20) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Ennemy") {
			Enemy enemy = collider.GetComponent<Enemy>();
			if (enemy.lane != lane) {
				return;
			}
			if (!enemy.isInvincible) {
				Destroy(collider.gameObject);
			}
			if (enemy.destroysArrow) {
				Destroy(gameObject);
			}
		}
	}

}