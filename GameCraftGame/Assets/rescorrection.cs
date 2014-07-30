using UnityEngine;
using System.Collections;

public class rescorrection : MonoBehaviour {
	public float adjusted;
	void awake()
	{
		adjusted = 40.0f * (Screen.currentResolution.width / 1280.0f);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.camera.orthographicSize=Screen.height*gameObject.camera.rect.height/adjusted/2.0f;
	}
}
