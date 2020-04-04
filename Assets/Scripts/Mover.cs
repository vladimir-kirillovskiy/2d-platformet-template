using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float speed;

	void Start() {
		rb = GetComponent<Rigidbody>();
		// rb.velocity = transform.right * speed;
		rb.AddForce(transform.right * speed, ForceMode.Impulse);
		// Debug.Log(rb.velocity.y);
	}
}
