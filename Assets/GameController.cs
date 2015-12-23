using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static bool developerMode = true;
	public Object inGameMenuEnt;
	static bool _menuShown = false;
	public static bool menuShown {
		get{
			return _menuShown;
		}
		set{
			if (value) {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}else{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			_menuShown = value;
		}
	}
	bool escWasPressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (developerMode) {
			// CHEATS AND OTHER DEVELOPER PRIVILEGES
		}
		if (Input.GetKey (KeyCode.Escape) && !menuShown){

		}
		if (Input.GetKey (KeyCode.Escape)) {
			if (!menuShown){
				escWasPressed = true;
			}
		} else {
			if (escWasPressed) {
				escWasPressed = false;
				menuShown = true;
				Instantiate (inGameMenuEnt);
			}
		}
	}
}