﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RangedGuyController : Enemy {

	private enum State {
		STATE_RUNNING_LEFT,
		STATE_RUNNING_RIGHT,
		STATE_SHOOTING
	}

	public float additionalMoveSpeed;

	public float waitDurationBeforeFire;
	public float waitDurationAfterFire;
	public float waitDurationBeforeChangingLane;
	public float waitDurationAfterChangingLane;
	public float changingLaneDuration;
	public float backwardDistance = 5;
	public float forwardDistance = 12;

	public GameObject projectilePrefab;

	private State state;

	private Vector3 startingPosition;

	void Awake() {
		state = State.STATE_RUNNING_LEFT;
		startingPosition = transform.position;
		StartCoroutine(AIBehaviour());
	}

	IEnumerator AIBehaviour() {
		while (true) {
			//Move left
			while (transform.position.x >= startingPosition.x - 12) {
				transform.position -= new Vector3((GameManager.Instance.scrollSpeed + additionalMoveSpeed) * Time.deltaTime, 0, 0);
				yield return null;
			}
			//Fire
			yield return new WaitForSeconds(waitDurationBeforeFire);
			Fire();
			yield return new WaitForSeconds(waitDurationAfterFire);
			while (transform.position.x <= startingPosition.x - backwardDistance) {
				transform.position += new Vector3((additionalMoveSpeed) * Time.deltaTime, 0, 0);
				yield return null;
			}
			yield return new WaitForSeconds(waitDurationBeforeChangingLane);
			ChangeLane();
			yield return new WaitForSeconds(changingLaneDuration);
			yield return new WaitForSeconds(waitDurationAfterChangingLane);
		}
	}

	void Fire() {
		Enemy projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity, GameManager.Instance.dynamicObjects).GetComponent<Enemy>();
		projectile.lane = lane;
		List<SpriteRenderer> renderers = projectile.renderers;
		int lineIndex = GameManager.Instance.lanes.IndexOf(lane);
		
		foreach (SpriteRenderer sprite in renderers) {
			sprite.sortingOrder = lineIndex;
		}
	}

	void ChangeLane() {
		LaneController newLane = GameManager.Instance.lanes[Random.Range(0, GameManager.Instance.lanes.Count)];
		
		while (newLane == lane) {
			newLane = GameManager.Instance.lanes[Random.Range(0, GameManager.Instance.lanes.Count)];
		}

		transform.DOMove(newLane.transform.position + new Vector3(20 - backwardDistance, transform.localScale.y/2, 0), changingLaneDuration);
		lane = newLane;
	}

	void OnDestroy() {
		StopAllCoroutines();
	}
}