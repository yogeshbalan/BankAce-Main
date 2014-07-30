function Animate(iRow : int, iCol : int, iFPS : int, iStartFrameRow : int, iStartFrameCol : int, iTotalFrames : int)
{
	// iIndex will always be ranging from 0 to iTotalFrames-1
	var iIndex = (Time.time * iFPS) % iTotalFrames;
	
	//	uv co-ordinates:
	//	u should start with iStartFrameCol and keep on getting incremented but with modulo iCol (cos it can't exceed iCol)
	var U : int = (iStartFrameCol + iIndex) % iCol;
	
	//	v should start with iStartFrameRow and keep on getting incremented everytime a new row starts (i.e. when U becomes
	//	0) again after reaching its max val of iCol-1
	var V : int = iStartFrameRow + ((iStartFrameCol + iIndex) / iCol);
	
	//	size of each frame
	var v2Size = Vector2(1.0/iCol,1.0/iRow);
	
	//	offset to interpolate through each frame
	var v2OffSet = Vector2(U*v2Size.x,(1.0 - v2Size.y) - V*v2Size.y);
	
	//	apply
	renderer.material.mainTextureScale = v2Size;
	renderer.material.mainTextureOffset = v2OffSet;
	
	//	applying normal map
	//renderer.material.SetTextureScale("_BumpMap",v2Size);
	//renderer.material.SetTextureOffset("_BumpMap",v2OffSet);
}