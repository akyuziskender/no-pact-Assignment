using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : Character
{
	private float dashSpeed = 20;
	private float dashCooldown = 1f;

	public Alice() {
		speed = 200f;
		maxSpeed = 4f;
		jumpVelocity = 6.75f;
		fallMultiplier = 2.5f;
		lowJumpMultiplier = 2f;
	}

	protected override void JumpSpeciality() {  // Forward dash
		StartCoroutine(ForwardDash(0.15f));
	}

	IEnumerator ForwardDash(float dashDur) {
		float time = 0;		// create float to store the time this coroutine is operating
		canUseSpeciality = false;

		while (dashDur > time)
		{
			time += Time.deltaTime;
			rb2d.velocity = new Vector2(dashSpeed * transform.localScale.x, 0);
			yield return 0; // go to next frame
		}
		yield return new WaitForSeconds(dashCooldown);
		canUseSpeciality = true;	// set back to true so that we can dash again.
	}
}
