using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	public Texture storyTexture;
	//public GUIStyle continueStyle;
	public GUIStyle storyStyle;
	public GUIStyle NextStyle;
	public GUIStyle PreviousStyle;
	//public GUIStyle styleOFtext;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI(){

		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),storyTexture);
		//drawing background



		GUI.Box (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", storyStyle);

		//GUI.Box (new Rect(220,Screen.height/3, Screen.width/2f, Screen.height/2f),"Rahul is a fresher, recently out of college. \nHe dreams of becoming the Global Head\n of ICICI Bank.\n For that he needs to perform well at his\n branch and serve maximum customers.\n Rahul wants to have a good life and retire \nrich. Help him make the right financial\n decisions and achieve his goals!",styleOFtext);
		//GUI.Button (new Rect (Screen.width / 1.6f, Screen.height / 3.5f, 150, 300), "", Character);

		if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
			Application.LoadLevel("Story_last");
		};

		if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
			Application.LoadLevel("Story_middle");
		};
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
