using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

	public List<Transform> spawnPositions;

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

	void SpawnObject(GameObject prefab, Transform lane) {
		Instantiate(prefab, lane.position + new Vector3(0, prefab.transform.localScale.y/2, 0), Quaternion.identity, GameManager.Instance.dynamicObjects);
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

	Transform GetSpawnPosition() {
		return spawnPositions[Random.Range(0, spawnPositions.Count)].transform;
	}

}