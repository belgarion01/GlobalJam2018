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

	public float invincibilityDuration;
	private float actualInvincibilityCooldown;

	[HideInInspector]
	public bool isSwapping;
	//[HideInInspector]
	public bool canSwap { get {return actualWeaponCooldown <= 0 && !isMoving;} }
	[HideInInspector]
	public bool isInvincible { get {return actualInvincibilityCooldown > 0;} }
	//[HideInInspector]
	public bool isUsingWeapon;
	//[HideInInspector]
	public bool canUseWeapon { get {return actualWeaponCooldown <= 0 && !isMoving;} }
	
	private float actualWeaponCooldown;

	[HideInInspector]
	public bool isMoving = false;

	void Update() {
		if (actualWeaponCooldown > 0) {
			actualWeaponCooldown = Mathf.Max(0, actualWeaponCooldown - Time.deltaTime);
			Vector3 weaponCooldown = GameManager.GetWeaponCooldown(activeWeapon);
			isUsingWeapon = false;
			if (actualWeaponCooldown <= weaponCooldown.y + weaponCooldown.z) {
				isUsingWeapon = true;
			}
			if (actualWeaponCooldown <= weaponCooldown.z) {
				isUsingWeapon = false;
			}

		}
		if (actualInvincibilityCooldown > 0) {
			if (Time.frameCount % 5 == 0) {
				bottomSprite.enabled = !bottomSprite.enabled;
				topSprite.enabled = !topSprite.enabled;
			}
			
			actualInvincibilityCooldown = Mathf.Max(0, actualInvincibilityCooldown - Time.deltaTime);
			if (actualInvincibilityCooldown <= 0) {
				bottomSprite.enabled = true;
				topSprite.enabled = true;
			}
		}
		
		if (Input.GetKeyDown(weaponButton)) {
			UseWeapon();
		}
		if (Input.GetKeyDown(swapButton)) {
			if (!isSwapping) {
				if (canSwap) {
					isSwapping = true;
				} 
			}
			else {
				isSwapping = false;
			}
		}
		if (Input.GetKeyDown(upButton)) {
			MoveUp();
		}
		if (Input.GetKeyDown(downButton)) {
			MoveDown();
		}

		if (isUsingWeapon && activeWeapon == Weapon.WEAPON_SHIELD) {
			Collider2D coll = Physics2D.OverlapBox(transform.position + new Vector3(1, 0, 0), Vector2.one, 0);
			if (coll && coll.tag == "EnnemyProjectile" && coll.GetComponent<Enemy>().lane == lane) {
				Destroy(coll.gameObject);
			}
		}
		if (isUsingWeapon && activeWeapon == Weapon.WEAPON_SWORD) {
			Collider2D coll = Physics2D.OverlapBox(transform.position + new Vector3(1, 0, 0), Vector2.one, 0);
			if (coll && coll.tag == "Ennemy" && coll.GetComponent<Enemy>().lane == lane) {
				Destroy(coll.gameObject);
			}
		}
	}

	public void UseWeapon() {
		if (!canUseWeapon) {
			return;
		}
		if (isSwapping) {
			isSwapping = false;
		}
		Vector3 weaponCooldown = GameManager.GetWeaponCooldown(activeWeapon);
		actualWeaponCooldown = weaponCooldown.x + weaponCooldown.y + weaponCooldown.z;
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

	void UseSword() { }

	void UseShield() { }

	void UseBow() { }

	void UsePill() { }

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag.Contains("Ennemy") && collider.GetComponent<Enemy>().lane == lane) {
			if (!isInvincible) {
				GameManager.Instance.actualLives -= 1;
				actualInvincibilityCooldown = invincibilityDuration;
			}
		}
	}

}