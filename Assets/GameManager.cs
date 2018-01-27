﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public List<PlayerController> players;
	public List<LaneController> lanes;

	private void Awake() {
		if (Instance != null && Instance != this) {
			Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

		InitializeGame();
    }

	void Update() {

		List<PlayerController> playersSwapping = new List<PlayerController>();

		for (int i=0;i< players.Count; i++) {
			PlayerController player = players[i];
			if (player.isSwapping) {
				if (playersSwapping.Count == 0) {
					playersSwapping.Add(player);
				}
				else {
					SwapWeapon(player, playersSwapping[0]);
					playersSwapping.Clear();
				}
			}
		}
	}

	public void InitializeGame() {
		for (int i=0; i< players.Count; i++) {
			PlayerController player = players[i];
			player.transform.position = lanes[i].transform.position + new Vector3(0, player.transform.localScale.y/2, 0);
			player.lane = lanes[i];
			lanes[i].player = player;
			player.topSprite.sortingOrder = i;
			player.bottomSprite.sortingOrder = i;
		}
	}

	public void SwapWeapon(PlayerController player1, PlayerController player2) {
		Weapon temp = player1.activeWeapon;
		player1.activeWeapon = player2.activeWeapon;
		player2.activeWeapon = temp;
		player1.isSwapping = false;
		player2.isSwapping = false;
	}

}