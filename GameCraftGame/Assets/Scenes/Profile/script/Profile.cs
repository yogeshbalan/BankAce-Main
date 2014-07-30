using UnityEngine;
using System.Collections;

public class Profile : MonoBehaviour {

	public Texture ProfileTexture;
	public Texture ProfileTexture1;
	public Texture ProfileTexture2;
	public Texture ProfileTexture3;
	public Texture ProfileTexture4;
	public Texture ProfileTexture5;
	public Texture ProfileTexture6;
	public GUIStyle round1;
	public GUIStyle round2;
	public GUIStyle round3;
	public GUIStyle round4;
	public GUIStyle round5;
	public GUISkin profileSkin;
	public GUIStyle cityHead;
	float x=0.0f;
	public float startSec= 1.0f;

	public Touch touch;

	//public Vector2 scrollPosition = Vector2.zero;

	void Start () {
		StartCoroutine (WaitProfile());
	}

	void OnGUI(){

				if (profileSkin != null)
						GUI.skin = profileSkin; //adding custom GUIskin
		if (x < 0.7f) {
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), ProfileTexture); //drawing background
				}
				if(x>0.7f&&Play.levelCleared==0)
				{
						GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),ProfileTexture1);
				}
				if(x>0.7f&&Play.levelCleared==1)
				{
							GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),ProfileTexture2);
				}
		if(x>0.7f&&Play.levelCleared==2)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),ProfileTexture3);
		}
		if(x>0.7f&&Play.levelCleared==3)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),ProfileTexture4);
		}
		if(x>0.7f&&Play.levelCleared==4)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),ProfileTexture5);
		}
		if(x>0.7f&&Play.levelCleared==5)
		{
			GUI.DrawTexture (new Rect(0,0,Screen.width, Screen.height),ProfileTexture6);
		}
						//Round Buttons

				//adding scrollMenu
				//	scrollPosition = GUI.BeginScrollView(new Rect(0, Screen.height/6, Screen.width, Screen.height/2), scrollPosition, new Rect(0, 0, Screen.width*2, Screen.height/3.1f));

				//if (GUI.Button (new Rect (Screen.width / 19.5f, Screen.height / 22.2f, 300, 50), "Town Head")) {}
				//if(GUI.Button(new Rect(Screen.width/19.5f, Screen.height/7.4f, 400,150),"", round1))
				//{
				//	Application.LoadLevel("MainGame");
				//}
				//if (GUI.Button (new Rect (Screen.width / 2.4f, Screen.height / 22.2f, 300, 50), "City Head")) {}
				//if(GUI.Button(new Rect(Screen.width/2.2f, Screen.height/7.4f, 400,150),"", round2))
				//{
				//Application.LoadLevel("MainGame");
				//}
				//if (GUI.Button (new Rect (Screen.width / 1.32f, Screen.height / 22.2f, 300, 50), "Zonal Head")) {}
				//if(GUI.Button(new Rect(Screen.width/1.1f, Screen.height/7.4f, 250,150),"", round3))
				//{
				//Application.LoadLevel("MainGame");
				//}
				//if (GUI.Button (new Rect (Screen.width / 0.9f, Screen.height / 22.2f, 300, 50), "Regional Head")) {}
				//	if(GUI.Button(new Rect(Screen.width/0.81f, Screen.height/7.4f, 250,150),"", round4))
				//	{
				//Application.LoadLevel("MainGame");
				//	}
				//if (GUI.Button (new Rect (Screen.width / 0.68f, Screen.height / 22.2f, 300, 50), "Country Head")) {}
				//	if(GUI.Button(new Rect(Screen.width/0.64f, Screen.height/7.4f, 250,150),"", round5))
				//	{
				//Application.LoadLevel("MainGame");
				//	}

				//	GUI.EndScrollView();
	
				//}

				// Use this for initialization

				// Update is called once per frame
		}
			void Update () {

		if(Input.touchCount>0){
			Application.LoadLevel("CharacterTUT");

		}

		x += Time.deltaTime;
		}
		IEnumerator WaitProfile(){
			yield return new WaitForSeconds (startSec);

			
			
		}
	}
