using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NormalGuyController : Enemy {

	public float additionalMoveSpeed;
	public Animator animator;

	void Awake() {

	}

	void Update() {
		transform.position -= new Vector3((GameManager.Instance.scrollSpeed + additionalMoveSpeed) * Time.deltaTime, 0, 0);
		if (transform.position.x < -20) {
			Destroy(gameObject);
		}
	}

	public override void Die() {
		if (!animator) {
			Destroy(gameObject);
			return;
		}
		animator.SetBool("Dying", true);
		GetComponent<BoxCollider2D>().enabled = false;
	}
}