using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

	public Vector2 spawnCooldownMinMax;
	private float actualCooldown;

	public GameObject normalGuyPrefab;
	public GameObject rangedGuyPrefab;
	public GameObject polePrefab;

	private float actualDiminution = 0;

	void Awake() {
		actualCooldown = Random.Range(spawnCooldownMinMax.x, spawnCooldownMinMax.y);
	}

	void Update() {
		actualCooldown -= Time.deltaTime;
		if (actualCooldown <= 0) {
			SpawnObject(GetSpawningPrefab(), GetSpawnPosition());
			actualCooldown = Mathf.Max(Random.Range(spawnCooldownMinMax.x, spawnCooldownMinMax.y) - actualDiminution, 1);
			actualDiminution -= 0.05f;
		}
	}

	void SpawnObject(GameObject prefab, LaneController lane) {
		GameObject newObject = Instantiate(prefab, lane.transform.position + new Vector3(20, prefab.transform.localScale.y/2, 0), Quaternion.identity, GameManager.Instance.dynamicObjects);
		Enemy enemy = newObject.GetComponent<Enemy>();
		enemy.SetLane(lane);
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