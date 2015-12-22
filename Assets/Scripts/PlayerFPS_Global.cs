using UnityEngine;
using System.Collections;

public class PlayerFPS_Global : MonoBehaviour {
	public float walkSpeed = 1f;
	public float walkAccel = 0.7f;
	public float runSpeed = 1.4f;
	public float jumpVel = 0.8f;
	public int canJump = 0;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((rigidbody.velocity.magnitude < walkSpeed*5 && !Input.GetKey (KeyCode.LeftShift)) || (rigidbody.velocity.magnitude < runSpeed*5 && Input.GetKey (KeyCode.LeftShift))) {
			if (Input.GetKey (KeyCode.W)) {
				// Forward
				rigidbody.AddRelativeForce(new Vector3(0,0,walkAccel*40));
			}
			if (Input.GetKey (KeyCode.S)) {
				// Back
				rigidbody.AddRelativeForce(new Vector3(0,0,-walkAccel*30));
			}
			if (Input.GetKey (KeyCode.A)) {
				// Left
				rigidbody.AddRelativeForce(new Vector3(-walkAccel*35,0,0));
			}
			if (Input.GetKey (KeyCode.D)) {
				// Right
				rigidbody.AddRelativeForce(new Vector3(walkAccel*35,0,0));
			}
		}
		if (Input.GetKey (KeyCode.Space)) {
			// Jump
			if (canJump>0) {
				rigidbody.AddRelativeForce(new Vector3(0,jumpVel*200,0));
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "jumpable") {
			canJump++;
		}
	}
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "jumpable") {
			canJump--;
		}
	}
}