using UnityEngine;
using System.Collections;

// This Script handles all the gui items displayed on the screen during the start of a game, basically its modes of playing.
// This script has been applied on Main Camera of scene StartScene

public class StartGame : MonoBehaviour {
	// Variables related to GamePlay and mode od playing
	private bool bPlayMode=false;     
	public static bool bIsEndlessMode; // Flag for endless mode
	public static bool bIsNormalMode; // Flag for normal mode.
	public Texture backgroundTexture;
	public Texture buttonTexture;
	public GUISkin guiSkin;
	public GUIStyle playButtonSkin;
	//public GUIStyle normalMode;
	//public GUIStyle endlessMode;
	public GUIStyle backButton;
	public GUIStyle exitButton;
	public GUIStyle resetButton;
	public GUIStyle infoButton;
	public GUIStyle playButton;
	public GUIStyle MenuPOPup;


	//about button parameters
	public float X1;
	public float Y1;
	public float width;
	public float height;



	// Use this for initialization
	void Start () {
		bPlayMode=false;
		bIsEndlessMode=false;
		bIsNormalMode=false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI()
		{
		if(guiSkin != null) GUI.skin = guiSkin; //adding custom GUIskin

		//draw our Background Texture
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height),backgroundTexture );

		GUI.Box (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", MenuPOPup);

		if(!bPlayMode) // This menu is displayed a the scene starts.  
		{
			if(GUI.Button(new Rect(Screen.width/1.66f-Screen.width/200,Screen.height/1.5f-Screen.height/3, 140,55),"", playButtonSkin)) // Button to select the mode.
			{

				bPlayMode=true;
				Application.LoadLevel("Story");
				//GUI.skin.button.normal.background.Equals(playButton);

				
			}
			if(GUI.Button(new Rect(Screen.width/1.66f-Screen.width/200,Screen.height/1.26f-Screen.height/2.9f, 140,55),"", resetButton)) // Button to select the mode.
			{
				PlayerPrefs.SetInt("Money",0);
			}
			if(GUI.Button(new Rect(Screen.width/1.66f-Screen.width/200, Screen.height/1.51f-Screen.height/9.5f, 140,55), "", infoButton)){
				//Application.LoadLevel("About_info");
			} 
			if(GUI.Button(new Rect(Screen.width/1.66f-Screen.width/200,Screen.height/1.5f, 140,55),"", exitButton))
			{
				Application.Quit(); // Api call for quitting the game.
				//Play.bIsGameOver=true;
			}
		}
		else // It will show a menu to select mode from normal or endless mode  
		{
			/*
			if(GUI.Button(new Rect(Screen.width/1.7f-Screen.width/8,Screen.height/2-Screen.height/1.6f, 400,400),"", normalMode)) // Button to set the flag for normal mode.
			{
				Play.bIsPlaying=true;
				bIsNormalMode=true;
				Application.LoadLevel("Profile");
			}
			if(GUI.Button(new Rect(Screen.width/1.7f-Screen.width/8,Screen.height/2-Screen.height/2.4f, 400,400),"", endlessMode)) // Button to set the flag for endless mode
			{
				Play.bIsPlaying=true;
				bIsEndlessMode=true;
				Application.LoadLevel("Profile");
			}
			if(GUI.Button(new Rect(Screen.width/1.7f-Screen.width/10,Screen.height/2+Screen.height/5-Screen.height/3.1f, 400,400),"", backButton)) // Button to Go to previous menu
			{
				bPlayMode=false;
				Application.LoadLevel("StartScene");

			}


			*/
		}


	}
}
