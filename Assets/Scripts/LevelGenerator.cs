using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public List<Transform> groundList;
	public GameObject player;
	public Transform groundStart;
	private Vector3 lastEndPostion;
	private const float PLAYER_DISTANCE_SPAWN = 100.0f;

	private void Awake() {
		lastEndPostion = groundStart.Find("EndPosition").position;
		SpawnGround();
	}

	private void Update() {
		// need to destroy old ones
		// need to add variety
		if (Vector3.Distance(player.transform.position, lastEndPostion) < PLAYER_DISTANCE_SPAWN) {
			SpawnGround();
		}
	}

	private void SpawnGround() {
		Transform choosenGround = groundList[Random.Range(0, groundList.Count)];
		Transform lastGroundTransform = SpawnGround(choosenGround, lastEndPostion);
		lastEndPostion = lastGroundTransform.Find("EndPosition").position;
	}

	private Transform SpawnGround(Transform ground, Vector3 spawnPosition) {
		Transform GroundTransform = Instantiate(ground, spawnPosition + new Vector3 (ground.Find("Ground").localScale.x / 2, 0.0f, 0.0f), Quaternion.identity);
		return GroundTransform;
	}
}
