using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Animate(int iRow ,int iCol ,int iFPS ,int iStartFrameRow ,int iStartFrameCol ,int iTotalFrames )
	{
		// iIndex will always be ranging from 0 to iTotalFrames-1
		var iIndex = (Time.time * iFPS) % iTotalFrames;
		
		//	uv co-ordinates:
		//	u should start with iStartFrameCol and keep on getting incremented but with modulo iCol (cos it can't exceed iCol)
		int U = (iStartFrameCol + Mathf.FloorToInt(iIndex)) % iCol;
		
		//	v should start with iStartFrameRow and keep on getting incremented everytime a new row starts (i.e. when U becomes
		//	0) again after reaching its max val of iCol-1
		int V = iStartFrameRow + ((iStartFrameCol + Mathf.FloorToInt(iIndex)) / iCol);
		
		//	size of each frame
		Vector2 v2Size =new  Vector2(1.0f/iCol,1.0f/iRow);
		
		//	offset to interpolate through each frame
		Vector2 v2OffSet =new Vector2(U*v2Size.x,(1.0f - v2Size.y) - V*v2Size.y);
		
		//	apply
		renderer.material.mainTextureScale = v2Size;
		renderer.material.mainTextureOffset = v2OffSet;
		
		//	applying normal map
		//renderer.material.SetTextureScale("_BumpMap",v2Size);
		//renderer.material.SetTextureOffset("_BumpMap",v2OffSet);
	}
}
