using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bob : Character {
	private float groundBreakSpeed = 30f;
	private float groundBreakCooldown = 1f;

	public Bob() {
		speed = 80f;
		maxSpeed = 2.5f;
		jumpVelocity = 6.75f;
		fallMultiplier = 2.5f;
		lowJumpMultiplier = 2f;
	}

	protected override void JumpSpeciality() {  // Break ground
		StartCoroutine(BreakGround());
	}

	IEnumerator BreakGround() {
		canUseSpeciality = false;

		while (!grounded) {
			rb2d.velocity = new Vector2(0, -groundBreakSpeed);
			yield return 0; // go to next frame
		}
		yield return new WaitForSeconds(groundBreakCooldown);
		canUseSpeciality = true;    // set back to true so that we can break again
	}
}
