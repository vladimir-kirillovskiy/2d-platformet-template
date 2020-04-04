using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	private Rigidbody rb;
	public bool isGrounded = true;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	public float fallMultiplier = 1.5f;
	public float lowJumpMultiplier = 1.0f;

	public Joystick joystick;

	public int extraJumps = 1;
	private bool facingRight = true;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		// Input.GetButton("Fire1")
		if (CrossPlatformInputManager.GetButtonDown("Shoot") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		
	}

	void FixedUpdate() {

		// float moveHorizontal = Input.GetAxis("Horizontal");
		// float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal;
		float moveVertical;

		if (joystick.Horizontal >= 0.2f) {
			moveHorizontal = speed;
		} else if (joystick.Horizontal <= -0.2f) {
			moveHorizontal = -speed;
		} else {
			moveHorizontal = 0.0f;
		}

		moveVertical = joystick.Vertical;

		// Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		// replace moveHorizontal with speed to make autorunner
		rb.velocity = new Vector3(speed * Time.deltaTime, rb.velocity.y, 0.0f);
		// rb.AddForce(movement * speed);

		// Vector3 jump = new Vector3(moveHorizontal, 1.0f, moveVertical);
		// double jump?

		

		// if (Input.GetButton("Jump")) {
		// Double jump works only with space press
		if (
			(moveVertical >= 0.5f || Input.GetKeyDown("space") || CrossPlatformInputManager.GetButtonDown("Jump")) 
			&& (isGrounded || extraJumps > 0)
		) {
			// rb.AddForce(jump * speed, ForceMode.Impulse);
			rb.velocity = Vector3.up * jumpHeight;
			// rb.AddForce(Vector3.up * jumpHeight);
			extraJumps--;
			isGrounded = false;
		}


		// if (Input.touchCount > 0) {
		// 	Touch touch = Input.GetTouch(0);
		// 	// touch.phase
		// 	Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
		// 	touchPosition.z = 0.0f
		// 	transform.position = touchPosition
		// }

		for (int i = 0; i < Input.touchCount; i++) {
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
			Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
		}

		if (rb.velocity.y < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier) * Time.deltaTime;
		// } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
		// 	rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}

		// should flip player
		// if (!facingRight && moveHorizontal >= 0.5f) {
		// 	Flip();
		// } else if (facingRight && moveHorizontal <= -0.5f) {
		// 	Flip();
		// }

	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Boundary") {
			isGrounded = true;	
			extraJumps = 2;		
		}
	}

	private void Flip() {
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
