using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public bool developerMode = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (developerMode) {
			if (Input.GetKey (KeyCode.Escape)){
				Application.Quit ();
			}
		}
	}
}