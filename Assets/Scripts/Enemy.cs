using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

	public List<SpriteRenderer> renderers;
	[HideInInspector]
	public LaneController lane;

}