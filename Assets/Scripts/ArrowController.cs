using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {

	public float moveSpeed;
	public LaneController lane {get; private set;}
	public List<SpriteRenderer> renderers;

	public void SetLane(LaneController newLane) {
		lane = newLane;
		int lineIndex = GameManager.Instance.lanes.IndexOf(lane);
		
		foreach (SpriteRenderer sprite in renderers) {
			sprite.sortingOrder = lineIndex;
		}
	}

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
				enemy.Die();
			}
			if (enemy.destroysArrow) {
				Destroy(gameObject);
			}
		}
	}

}