using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

	public Vector2 spawnCooldownMinMax;
	private float actualCooldown;

	public GameObject normalGuyPrefab;
	public GameObject rangedGuyPrefab;
	public GameObject polePrefab;

	void Awake() {
		actualCooldown = Random.Range(spawnCooldownMinMax.x, spawnCooldownMinMax.y);
	}

	void Update() {
		actualCooldown -= Time.deltaTime;
		if (actualCooldown <= 0) {
			SpawnObject(GetSpawningPrefab(), GetSpawnPosition());
			actualCooldown = Random.Range(spawnCooldownMinMax.x, spawnCooldownMinMax.y);
		}
	}

	void SpawnObject(GameObject prefab, LaneController lane) {
		GameObject newObject = Instantiate(prefab, lane.transform.position + new Vector3(20, prefab.transform.localScale.y/2, 0), Quaternion.identity, GameManager.Instance.dynamicObjects);
		Enemy enemy = newObject.GetComponent<Enemy>();
		enemy.lane = lane;
		List<SpriteRenderer> renderers = enemy.renderers;
		int lineIndex = GameManager.Instance.lanes.IndexOf(lane);
		
		foreach (SpriteRenderer sprite in renderers) {
			sprite.sortingOrder = lineIndex;
		}
	}

	GameObject GetSpawningPrefab() {
		switch (Random.Range(0, 3)) {
			case 0: 
				return normalGuyPrefab;
			case 1: 
				return rangedGuyPrefab;
			case 2: 
				return polePrefab;
			default: return polePrefab;
		}
	}

	LaneController GetSpawnPosition() {
		return GameManager.Instance.lanes[Random.Range(0, GameManager.Instance.lanes.Count)];
	}

}