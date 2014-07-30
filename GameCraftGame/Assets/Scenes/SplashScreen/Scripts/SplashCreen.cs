using UnityEngine;
using System.Collections;

public class SplashCreen : MonoBehaviour {

	public Texture splashScreenTexture;
	public Texture splashScreenTexture1;
	public Texture splashScreenTexture2;
	public Texture splashScreenTexture3;
	public Texture splashScreenTexture4;
	public Texture splashScreenTexture5;
	public Texture splashScreenTexture6;
	public Texture splashScreenTexture7;
	public Texture splashScreenTexture8;
	public float X1;
	public float Y1;
	public float width;
	public float height;
	public GUIStyle fill;
	float x=0.0f;
	//public AnimationState ;

	public float startSeconds = 8f;



	// Use this for initialization
	 void Start () {

		StartCoroutine (WaitSplash());

	}

	public void OnGUI(){
		
		//if(guiSkin != null) GUI.skin = guiSkin; //adding custom GUIskin
		
		GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture); //drawing background
		if(x<2)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture);
		}
		if(x<2.5f&&x>2f)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture1);
		}
		if(x<3&&x>2.5f)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture2);
		}
		if(x>3f&&x<3.5f)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture3);
		}
		if(x>3.5f&&x<4)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture4);
		}
		if(x>4f&&x<4.5f)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture5);
		}
		if(x>4.5f&&x<5)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture6);
		}
		if(x>5&&x<5.5f)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture7);
		}
		if(x>5.5f)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),splashScreenTexture8);
		}
		}

		//if(GUI.Button(new Rect(Screen.width*X1, Screen.height*Y1, width, height),"Main Menu")){}
		


	
	// Update is called once per frame
	void Update () {

		x += Time.deltaTime*2;

	}

	IEnumerator WaitSplash(){
		yield return new WaitForSeconds (startSeconds);
		Application.LoadLevel("StartScene");


	}
}
