using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	private Character character;

    // Start is called before the first frame update
    void Start() {
		character = transform.parent.GetComponent<Character>();
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (null == character) {
			Start();
		}
		if (other.CompareTag("Ground"))  {
			character.grounded = true;
			character.canUseSpeciality = false;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("Ground")) {
				character.grounded = true;
			character.canUseSpeciality = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Ground")) {
			character.grounded = false;
			character.canUseSpeciality = true;
		}
	}
}
