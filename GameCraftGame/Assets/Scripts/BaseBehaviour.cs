using UnityEngine;
using System.Collections;

public class BaseBehaviour : MonoBehaviour {
	bool bIsLevelChanged=false;
	int currentLevel=Play.levelCleared;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Play.bchangeBackGround)
		{
			Texture2D background=Resources.LoadAssetAtPath<Texture2D>("Assets/Textures/background "+(Play.levelCleared+1)+".jpg");
			if(background)
			{
				renderer.material.mainTexture=background;
				Play.bchangeBackGround=false;
			}
			else
			{
				Debug.Log("Failed to load texture");
			}
		}
	
	}
}
