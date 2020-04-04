using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotator : MonoBehaviour {

	private Rigidbody rb;
	public float tumble;
	private float r;

	void Start() {
		rb = GetComponent<Rigidbody>();
		// rb.angularVelocity = Random.insideUnitSphere * tumble;
		// transform.rotation.x = rb.rotation.x + tumble;
	}

	void Update() {
		r += Time.deltaTime * tumble;
        transform.rotation = Quaternion.Euler(90, r, 0);
	}
}
