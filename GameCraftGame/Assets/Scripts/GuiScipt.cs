using UnityEngine;
using System.Collections;

public class GuiScipt : MonoBehaviour {

	GameObject m_obj_Loan;
	GameObject m_obj_Deposit;
	GameObject m_obj_Withdrawl;
	GameObject m_obj_Water;
	GameObject m_obj_Bench;
	public GUISkin m_skin_GuiSkin;
	// Use this for initialization
	void Start () {
		/*m_obj_Loan=GameObject.FindGameObjectWithTag("Loan");
		m_obj_Deposit=GameObject.FindGameObjectWithTag("Deposit");
		m_obj_Withdrawl=GameObject.FindGameObjectWithTag("Withdrawl");
		m_obj_Water=GameObject.FindGameObjectWithTag("Water");
*/

			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{

		//GUI.Box(new Rect(0, 0, Screen.width/2, Screen.height/2), "This is a title");
	}

}
