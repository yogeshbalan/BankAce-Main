#pragma strict

var m_objAnimationScript : AnimateSpriteScript ;


/********************************
Name 				: Start
Auhtor 				: Siddharth
Input Paprameters   : None
Output Paprameters  : None
Return Type 		: Void
Description         : This is the function for initiation
********************************/
function Start(){
	m_objAnimationScript = GetComponent(AnimateSpriteScript);
}

/********************************
Name 				: Update
Auhtor 				: Siddharth
Input Paprameters   : None
Output Paprameters  : None
Return Type 		: Void
Description         : This is the function used to call the fuction which animates the coin
********************************/
function Update () {
	m_objAnimationScript.Animate(3,5,12,0,0,5);
}
