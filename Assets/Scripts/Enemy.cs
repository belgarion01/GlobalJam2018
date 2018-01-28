using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

	public List<SpriteRenderer> renderers;
	[HideInInspector]
	public LaneController lane {get; private set;}
	public bool isInvincible = false;
	public bool destroysArrow = true;

	public void SetLane(LaneController newLane) {
		lane = newLane;
		int lineIndex = GameManager.Instance.lanes.IndexOf(lane);
		
		foreach (SpriteRenderer sprite in renderers) {
			sprite.sortingOrder = lineIndex;
		}
	}

}