using UnityEngine;
using System.Collections;

public class CharacterTUT : MonoBehaviour {

	public Texture TutorialTexture1;
	public Texture TutorialTexture2;
	public Texture TutorialTexture3;
	public Texture TutorialTexture4;
	public Texture TutorialTexture5;
	public GUIStyle BackGroundStyle;
	public GUIStyle ContinueStyle;
	public Texture round2;
	
	void OnGUI(){
		
		//if(guiSkin != null) GUI.skin = guiSkin; //adding custom GUIskin
		
		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),TutorialTexture1); //drawing background
		//GUI.Box (new Rect(120, 30, Screen.width - 240, Screen.height - 60),"", BackGroundStyle);
		
		if(GUI.Button(new Rect(Screen.width/2.33f-Screen.width/200, Screen.height/1.13f-Screen.height/9.5f, 140,55), "", ContinueStyle)){
			Application.LoadLevel("MainGame");
		}

		if (Play.levelCleared == 1) {
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),TutorialTexture2);	
			if(GUI.Button(new Rect(Screen.width/2.33f-Screen.width/200, Screen.height/1.13f-Screen.height/9.5f, 140,55), "", ContinueStyle)){
				Application.LoadLevel("MainGame");
			}

		}
		if (Play.levelCleared == 2) {
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),TutorialTexture3);	
			if(GUI.Button(new Rect(Screen.width/2.33f-Screen.width/200, Screen.height/1.13f-Screen.height/9.5f, 140,55), "", ContinueStyle)){
				Application.LoadLevel("MainGame");
			}

		}
		if (Play.levelCleared == 3) {
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),TutorialTexture4);	
			if(GUI.Button(new Rect(Screen.width/2.33f-Screen.width/200, Screen.height/1.13f-Screen.height/9.5f, 140,55), "", ContinueStyle)){
				Application.LoadLevel("MainGame");
			}

		}
		if (Play.levelCleared == 4) {
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),TutorialTexture5);	
			if(GUI.Button(new Rect(Screen.width/2.33f-Screen.width/200, Screen.height/1.13f-Screen.height/9.5f, 140,55), "", ContinueStyle)){
				Application.LoadLevel("MainGame");
			}

		}


		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
