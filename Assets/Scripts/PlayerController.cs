using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Weapon {
	WEAPON_NONE,
	WEAPON_SWORD,
	WEAPON_SHIELD,
	WEAPON_BOW,
	WEAPON_PILL
}

public class PlayerController : MonoBehaviour {

	public SpriteRenderer topSprite;
	public SpriteRenderer bottomSprite;

	public KeyCode weaponButton;
	public KeyCode swapButton;
	public KeyCode upButton;
	public KeyCode downButton;

	[HideInInspector]
	public LaneController lane;

	public Weapon activeWeapon = Weapon.WEAPON_BOW;

	public float movementDuration = 0.5f;

	[HideInInspector]
	public bool isSwapping;

	[HideInInspector]
	public bool isMoving = false;

	void Update() {
		if (Input.GetKeyDown(weaponButton)) {
			UseWeapon();
		}
		if (Input.GetKeyDown(swapButton)) {
			isSwapping = !isSwapping;
		}
		if (Input.GetKeyDown(upButton)) {
			MoveUp();
		}
		if (Input.GetKeyDown(downButton)) {
			MoveDown();
		}
	}

	public void UseWeapon() {
		switch (activeWeapon) {
			case Weapon.WEAPON_SWORD: UseSword(); break;
			case Weapon.WEAPON_SHIELD: UseShield(); break;
			case Weapon.WEAPON_BOW: UseBow(); break;
			case Weapon.WEAPON_PILL: UsePill(); break;
		}
	}

	private void MoveUp() {
		if (isMoving) {
			return;
		}
		List<LaneController> lanes = GameManager.Instance.lanes;

		int laneIndex = lanes.IndexOf(lane);

		if (laneIndex != 0 && lanes[laneIndex-1].player == null) {
			MoveToLane(lane, lanes[laneIndex-1]);
		}
	}

	private void MoveDown() {
		if (isMoving) {
			return;
		}
		List<LaneController> lanes = GameManager.Instance.lanes;

		int laneIndex = lanes.IndexOf(lane);

		if (laneIndex != lanes.Count-1 && lanes[laneIndex+1].player == null) {
			MoveToLane(lane, lanes[laneIndex+1]);
		}
	}

	private void MoveToLane(LaneController oldLane, LaneController newLane) {
		if (isMoving) {
			return;
		}
		isMoving = true;
		transform.DOMove(newLane.transform.position  + new Vector3(0, transform.localScale.y/2, 0), movementDuration).OnComplete(() => {
			isMoving = false;
		});
		oldLane.player = null;
		newLane.player = this;
		lane = newLane;
		topSprite.sortingOrder = GameManager.Instance.lanes.IndexOf(newLane);
		bottomSprite.sortingOrder = GameManager.Instance.lanes.IndexOf(newLane);
	}

	private void UseSword() {}

	private void UseShield() {}

	private void UseBow() {}

	private void UsePill() {}

}