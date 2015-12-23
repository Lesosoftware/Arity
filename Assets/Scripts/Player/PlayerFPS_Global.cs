using UnityEngine;
using System.Collections;

public class PlayerFPS_Global : MonoBehaviour {
	public float walkSpeed = 1f;
	public float walkAccel = 0.7f;
	public float runSpeed = 1.4f;
	public float jumpVel = 0.8f;
	public int canJump = 0;
	private Rigidbody rigidbody;
	float actHorizSpeed;

	private Transform camera;
	public Transform mRigNeck;
	public Transform mRigHead;
	private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	private RotationAxes axes = RotationAxes.MouseXAndY;
	public float CamSensitivityX = 8F;
	public float CamSensitivityY = 8F;
	private float MinCamX = -360F;
	private float MaxCamX = 360F;
	public float MinCamY = -70F;
	public float MaxCamY = 60F;
	float CamRotationY = 0F;
	Animator anim;
	Animator animCam;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
		camera = GameObject.Find ("Cam_Main").transform;
		animCam = camera.parent.gameObject.GetComponent<Animator> ();
		mRigNeck = GameObject.Find ("metarig|neck").transform;
		mRigHead = GameObject.Find ("metarig|head").transform;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ((rigidbody.velocity.magnitude < walkSpeed * 3.3 && !Input.GetKey (KeyCode.LeftShift)) || (rigidbody.velocity.magnitude < runSpeed * 3.3 && Input.GetKey (KeyCode.LeftShift))) {
			if (Input.GetKey (KeyCode.W)) {
				// Forward
				rigidbody.AddRelativeForce (new Vector3 (0, 0, walkAccel * 40));
			}
			if (Input.GetKey (KeyCode.S)) {
				// Back
				rigidbody.AddRelativeForce (new Vector3 (0, 0, -walkAccel * 30));
			}
			if (Input.GetKey (KeyCode.A)) {
				// Left
				rigidbody.AddRelativeForce (new Vector3 (-walkAccel * 35, 0, 0));
			}
			if (Input.GetKey (KeyCode.D)) {
				// Right
				rigidbody.AddRelativeForce (new Vector3 (walkAccel * 35, 0, 0));
			}
		}
		if (Input.GetKey (KeyCode.Space)) {
			// Jump
			if (canJump > 0) {
				rigidbody.AddRelativeForce (new Vector3 (0, jumpVel * 200, 0));
			}
		}
		float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * CamSensitivityX;
		
		CamRotationY += Input.GetAxis ("Mouse Y") * CamSensitivityY;
		CamRotationY = Mathf.Clamp (CamRotationY, MinCamY, MaxCamY);
		
		camera.localEulerAngles = new Vector3 (-CamRotationY, 0, 0);
		transform.Rotate (0, Input.GetAxis ("Mouse X") * CamSensitivityX, 0);
		actHorizSpeed = Mathf.Lerp (actHorizSpeed, (Mathf.Abs (rigidbody.velocity.x) + Mathf.Abs (rigidbody.velocity.z)) / 4, 0.2f);
		anim.SetFloat ("walkSpeed", actHorizSpeed);
		animCam.SetFloat ("walkSpeed", actHorizSpeed);
		animCam.SetFloat ("velAmmount", rigidbody.velocity.magnitude);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "jumpable") {
			canJump++;
			animCam.SetBool ("touchesGround", canJump > 0);
		}
	}
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "jumpable") {
			canJump--;
			animCam.SetBool ("touchesGround", canJump > 0);
		}
	}
}