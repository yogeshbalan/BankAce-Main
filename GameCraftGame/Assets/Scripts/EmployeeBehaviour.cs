using UnityEngine;
using System.Collections;

public class EmployeeBehaviour : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 vMyPosition;
	private Vector3 vMovePosition;
	private Vector3 vDeskPosition;
	private bool bIsSettled=false;
	private bool bIsAllowedToMove=true;
	public bool bIsStatic=false;
	public bool bIsAttended=false;
	public GameObject oPrefab;
	private float localTimeOffDesk=3.0f;
	private bool bOriginalEmployee=false;
	private bool bOnAnotherEmployee;
	Animation m_objAnimationScript;
	// Use this for initialization
	void Start () {
		bIsSettled=false;
		bOriginalEmployee=false;
		bIsAllowedToMove=true;
		localTimeOffDesk=3.0f;
		m_objAnimationScript=gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!bIsSettled && !bIsAttended && !bIsStatic)
		{
			localTimeOffDesk-=Time.deltaTime;
			if(localTimeOffDesk<0)
				Destroy (gameObject);
			//m_objAnimationScript.Animate(1,5,18,0,0,5);
		}
		if(!bIsStatic)
			if(bOnAnotherEmployee)
			if(Play.bEmployeeChange)
			{	
				if(bOriginalEmployee)
					Destroy(gameObject);
				else
					bOriginalEmployee=true;
				Play.bEmployeeChange=false;
			}
		if(bIsSettled)
			m_objAnimationScript.Animate(1,5,6,0,0,5);
		else
			m_objAnimationScript.Animate(1,5,6,0,1,1);
	
	}
	void OnTriggerEnter(Collider hitinfo)
	{

		if(hitinfo.gameObject.tag=="EmployeePosition")
		{
			bIsSettled=true;
			vDeskPosition=hitinfo.gameObject.transform.position;
		}	
		if(hitinfo.gameObject.tag=="Employee")
		{
			//bOnAnotherEmployee=true;
		}
	}
	void OnTriggerStay(Collider hitinfo)
	{
		
		if(hitinfo.gameObject.tag=="EmployeePosition")
		{
			bIsSettled=true;
			//vDeskPosition=hitinfo.gameObject.transform.position;
			bOriginalEmployee=true;
		}	
	}
	void OnTriggerExit (Collider hitinfo)
	{
		if(hitinfo.gameObject.tag=="EmployeePosition")
		{
			bIsSettled=false;
		}
		if(hitinfo.gameObject.tag=="Employee")
		{
			bOnAnotherEmployee=false;
		}
	}
	void OnMouseDown()
	{
		if(!bIsStatic)
		{
			if(!bIsSettled && bIsAllowedToMove )
			{
				vMyPosition=gameObject.transform.position;
				
				screenPoint = Camera.main.WorldToScreenPoint(vMyPosition);
				
				offset = vMyPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

				
				vMovePosition=vMyPosition;
				
				bIsAttended=true;
			}
		}
		else {
			Vector3 temp=transform.position;
			temp.y+=0.5f;
			Instantiate(oPrefab,temp,Quaternion.Euler(0,-90,0));


				}
	}
	void OnMouseUp()
	{
		if(!bIsStatic)
		{
			if(bIsSettled  )
			{
				transform.position=vDeskPosition;
					bIsAllowedToMove=false;
				Play.bEmployeeChange=true;
				
			}
			else// If the customer is not placed anywhere, on desk or on queue. then return it to original location
			{
				//transform.position=vMovePosition;
				Destroy(gameObject);
				
				
			}
		}

		
		
	}
	void OnMouseDrag()
	{


		if(!bIsStatic)
		{

			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint),offset;
			if(!Play.  bIsGameOver  )
			{
				
				//if((curPosition.z<(oRightCounter.transform.position.z + 5) && curPosition.z>(oLeftCounter.transform.position.z -5)) || curPosition.x<-7 )
				{
					transform.position = curPosition;
				}

			}

		}
		//bIsAttended=true;
		
	}
}
