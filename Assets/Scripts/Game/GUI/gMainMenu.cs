using UnityEngine;
using System.Collections;

public class gMainMenu : MonoBehaviour
{
	public Object settingsMenu;
	int screenWidth = Screen.width;
	int screenHeight = Screen.height;

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	void OnGUI()
	{
		int groupWidth = 500;
		int groupHeight = 452;
		
		int groupX = ( screenWidth - groupWidth ) / 2;
		int groupY = ( screenHeight - groupHeight ) / 2;
		
		GUI.BeginGroup( new Rect( groupX, groupY, groupWidth, groupHeight ) );
		GUI.Box( new Rect( 0, 0, groupWidth, groupHeight ), "Pause" );
		
		if ( GUI.Button( new Rect( 23, 71, 452, 71), "Zurück zum Spiel" ) )
		{
			Destroy(gameObject);
		}
		if ( GUI.Button( new Rect( 23, 166, 452, 71 ), "Einstellungen" ) )
		{
			Instantiate(settingsMenu);
			Destroy(gameObject);
		}

		if ( GUI.Button( new Rect( 23, 261, 452, 71), "Speichern und beenden" ) ) { }

		if ( GUI.Button( new Rect( 23, 357, 452, 71 ), "Speichern und Spiel beenden" ) )
		{
			Application.Quit();
		}

		GUI.EndGroup();
	}
}
