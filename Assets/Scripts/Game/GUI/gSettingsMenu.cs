using UnityEngine;
using System.Collections;

public class gSettingsMenu : MonoBehaviour
{
	public Object mainMenu;
	int screenWidth = Screen.width;
	int screenHeight = Screen.height;
	bool escWasPressed = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			escWasPressed = true;
		} else {
			if (escWasPressed) {
				escWasPressed = false;
				GameController.menuShown = false;
				Destroy (gameObject);
			}
		}
	}

	void OnGUI()
	{
		int settingsGroupWidth = 500;
		int settingsGroupHeight = 452;
		
		int settingsGroupX = (screenWidth - settingsGroupWidth) / 2;
		int settingsGroupY = (screenHeight - settingsGroupHeight) / 2;
		
		GUI.BeginGroup (new Rect (settingsGroupX, settingsGroupY, settingsGroupWidth, settingsGroupHeight));
		GUI.Box (new Rect (0, 0, settingsGroupWidth, settingsGroupHeight), "Einstellungen");

		if (GUI.Button (new Rect (23, 71, 452, 71), "Grafik"))
		{
			GameController.menuShown = false;
			Destroy (gameObject);
		}

		if (GUI.Button (new Rect (23, 166, 452, 71), "Audio"))
		{
			Application.LoadLevel (2);
		}

		if (GUI.Button (new Rect (23, 261, 452, 71), "Steuerung"))
		{
			Application.LoadLevel (3);
		}
		
		if (GUI.Button (new Rect (23, 357, 452, 71), "Zurück"))
		{
			Instantiate(mainMenu);
			Destroy (gameObject);
		}
		
		GUI.EndGroup ();
	}
}
