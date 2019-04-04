using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	protected Rigidbody2D rb2d;

	public bool grounded;
	public bool canUseSpeciality = false;

	private float horizontal_movement;
	protected float speed;
	protected float maxSpeed;
	protected float jumpVelocity;
	protected float fallMultiplier;
	protected float lowJumpMultiplier;

    // Start is called before the first frame update
    void Start() {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.freezeRotation = true;
	}

    // Update is called once per frame
    void Update() {
		bool jump_movement = false;
		jump_movement = Input.GetButtonDown("Jump");
		Move();
		if (jump_movement) {
			if (grounded)
				Jump();
			else if (canUseSpeciality)
				JumpSpeciality();
		}
    }

	protected void Move() {
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.x *= 0.70f;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;

		if (grounded)	// Fake friction / easing the x speed of the player
			rb2d.velocity = easeVelocity;

		// Moving the player
		horizontal_movement = Input.GetAxis("Horizontal");    // Getting horizontal movement (-1,1)
		rb2d.AddForce((Vector2.right * speed) * horizontal_movement);

		// Limiting the speed of the player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}

		// Flipping the sprite vertically with respect to the player's direction
		if (Input.GetAxis("Horizontal") < -0.1f) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if (Input.GetAxis("Horizontal") > 0.1f) {
			transform.localScale = new Vector3(1, 1, 1);
		}
	}

	protected void Jump() {
		rb2d.velocity = Vector2.up * jumpVelocity;

		if (rb2d.velocity.y < 0) {  // Falling
			rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump")) {
			rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}

	protected virtual void JumpSpeciality() {

	}
}
