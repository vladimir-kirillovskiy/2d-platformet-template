using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject enemy;
	public float spawnWait;
	public Transform enemySpawn;


	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
	}

	IEnumerator SpawnEnemies() {
		yield return new WaitForSeconds(spawnWait);
		while(true) {
			Instantiate(enemy, enemySpawn.position, enemySpawn.rotation);
			yield return new WaitForSeconds(spawnWait);
		}
	}
	
}
