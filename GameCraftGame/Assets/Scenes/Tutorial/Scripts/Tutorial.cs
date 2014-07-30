using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public Texture TutorialTexture;
	public GUIStyle BackGroundStyle;
	public GUIStyle ContinueStyle;

	void OnGUI(){
		
		//if(guiSkin != null) GUI.skin = guiSkin; //adding custom GUIskin
		
		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),TutorialTexture); //drawing background
		GUI.Box (new Rect(120, 30, Screen.width - 240, Screen.height - 60),"", BackGroundStyle);

		if(GUI.Button(new Rect(Screen.width/1.58f-Screen.width/200, Screen.height/1.37f-Screen.height/9.5f, 140,55), "", ContinueStyle)){
			Application.LoadLevel("Profile");
		}

		
	}

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
	
	}
}
