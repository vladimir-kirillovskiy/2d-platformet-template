using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Debug.Log("Start");
	}
	
	void OnTriggerEnter(Collider other) {
		// Debug.Log("OnTriggerEnter");
		if (other.tag == "Boundary") {
			// Debug.Log("Boundary");
			return;
		}

		if (other.tag == "Enemy") {
			// Debug.Log("Enemy Tag");
		}

		if (other.tag == "Player") {
			// Debug.Log("Player Tag");
		}
		// destroy both
		Destroy(other.gameObject);

	}
}
