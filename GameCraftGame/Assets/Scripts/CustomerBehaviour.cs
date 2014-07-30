using UnityEngine;
using System.Collections;

// This script governs the behaviour of a cutomer and its interaction with different components of environment. This script is applied on the prefab of every customer.

public class CustomerBehaviour : MonoBehaviour {


	// Variables used to locate and in drag drop.
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 vMyPosition;
	private Vector3 vMovePosition;

	// Different flags used to check the config of a customer.
	private bool bOnQueue=false;
	private bool bIsSettled=false;
	private bool bIsAttended=false;
	private bool bOnAnotherCustomer=false;
	private bool bIsAllowedToMove=true;
	private bool bDroppedOnQueue=false;
	private bool bEnteredCoroutine=false;
	private bool bIsWaiting=false;


	// Flags to check where the customer has been dragged. Right side or left side.
	private bool bRightCounters=false;
	private bool bLeftCounters=false;
	private bool bDragBack=false;
	public GameObject oRightCounter;
	public GameObject oLeftCounter;


	// Variables used to position the customer when on bench or on desk 
	private Vector3 vBenchCenter;
	private Vector3 vDeskCenter;


	// Flags for waiting time for customers and getting them angry
	public int moodOffTime;
	private float moodOffLocalTime=10.0f;
	public float normalWaitTime=10.0f;
	public float deskTime=10.0f;
	private int queueNumber=0;
	private float localTimeOffDesk;
	private bool bDoneWithTechUpgrades=true;
	private bool bIsWaitRight=true;
	//private int p_int_CustomersAttached=0;
	private bool bWaitQueueEnd=false;
	private bool bIsAllowedToDragInWait=false;
	// Variables for Score 
	public int multiplier;
	Animation m_objAnimationScript;//=new Animation();



	// Use this for initialization
	void Start () {
		bIsSettled=false;
		bOnQueue=false;
		bIsAttended=false;
		vBenchCenter=Vector3.zero;
		vDeskCenter=Vector3.zero;
		bOnAnotherCustomer=false;
		bRightCounters=false;
		bLeftCounters=false;
		bIsAllowedToMove=true;
		bDroppedOnQueue=false;
		vMyPosition=gameObject.transform.position;
		vMovePosition = vMyPosition;
		localTimeOffDesk=deskTime;
		moodOffLocalTime=Random.Range(moodOffTime-4,moodOffTime+4);
		//normalWaitTime=Random.Range(5,10);
		Quaternion temp=gameObject.transform.rotation;
		temp*=Quaternion.Euler(0,270,0);
		oRightCounter=GameObject.FindGameObjectWithTag("RightCounters");
		oLeftCounter=GameObject.FindGameObjectWithTag("LeftCounters");
		//temp.x=0;
		//temp.y=180;
		//temp.z=90;
		gameObject.transform.rotation=temp;
		//p_int_CustomersAttached = 0;
		bEnteredCoroutine=false;
		bDoneWithTechUpgrades=!Play.bTechUpgradesValid;
		queueNumber=0;
		bIsWaitRight=false;
		bIsAllowedToDragInWait=false;
		m_objAnimationScript = gameObject.GetComponent<Animation>();
	}
	// Resetting of various flag when the customre interacts with different components
	void OnTriggerExit (Collider hitinfo)
	{
		//if (hitinfo.gameObject.tag == "LastPlace") {
			//p_bool_LastPlace=false;
		//	Debug.Log("LastPlace LEft");
		//}
		if(hitinfo.gameObject.tag=="RightCounters")
		{
			bRightCounters=true;
			bLeftCounters=false;
			bIsSettled=false;
			
		}
		if(hitinfo.gameObject.tag=="LeftCounters")
		{
			bRightCounters=false;
			bLeftCounters=true;
			bIsSettled=false;
		}
		if(hitinfo.gameObject.tag=="Customer" )
		{
			//p_bool_LastPlace=false;
//			gameObject.collider.isTrigger.Equals(true);

			bOnAnotherCustomer=false;
			//--p_int_CustomersAttached;
			//if(p_int_CustomersAttached!=0 || p_bool_LastPlace)
			if(bWaitQueueEnd)
				StartCoroutine(Wait(0.5f));

			//p_bool_LastPlace=false;
			//vDeskCenter=hitinfo.gameObject.transform.position;
		}
		if(!bIsAttended)
		{
			/*if(hitinfo.gameObject.tag=="CustomerLimit") // When any customer crosses the plane with tag "CustomerLimit". GAMEOVER
			{
				Play.timeLeft-=5; // If customers returns angry our time to operate the bank decreases
				Play.score-=10;
			}*/

		}
		if(hitinfo.gameObject.tag=="Queue1" || hitinfo.gameObject.tag=="Queue2"| hitinfo.gameObject.tag=="Queue3"| hitinfo.gameObject.tag=="Queue4"| hitinfo.gameObject.tag=="Queue5"| hitinfo.gameObject.tag=="Queue6")
		{
			bOnQueue=false;
			//FindQueue(hitinfo);//bIsSettled=true;
			//Debug.Log("out of bench");
			
		}
		if(hitinfo.gameObject.tag=="Loan")
		{
			bIsSettled=false;
			
		}
		if(hitinfo.gameObject.tag=="Deposit")
		{
			bIsSettled=false;
		}
		if(hitinfo.gameObject.tag=="Withdrawl")
		{
			bIsSettled=false;
		}

		if(hitinfo.gameObject.tag=="Deposit")
		{
			bIsSettled=false;
		}
		if(hitinfo.gameObject.tag=="OutOfWait")
		{
			bIsWaiting=false;
			bIsWaitRight=false;
			bIsAllowedToDragInWait=false;
		}
		if(hitinfo.gameObject.tag=="WaitQueueEnd")
		{	
			bIsWaiting=false;
			bWaitQueueEnd=false;
			//bIsWaitRight=true;
			
			
		}
	}
	// Setting of various flag when the customre interacts with different components
	void OnTriggerEnter(Collider hitinfo)
	{
		//if (hitinfo.gameObject.tag == "LastPlace") {
		//	p_bool_LastPlace=true;
		//}
		if(hitinfo.gameObject.tag=="Customer")
		{

//			gameObject.collider.isTrigger.Equals(false);
			//p_int_CustomersAttached++;
			bEnteredCoroutine=false;
			bOnAnotherCustomer=true;
			bIsAllowedToMove=false;
			SetMoveQueue(queueNumber,false);
			if(hitinfo.gameObject.name=="Complaining")  // If the customer is standing near a complaining character , he/she will also get angry soon.
			{
				moodOffLocalTime-=2;
				
			}
			//vDeskCenter=hitinfo.gameObject.transform.position;
		}
		if(hitinfo.gameObject.tag=="Loan")
		{
			bIsSettled=true;
			vDeskCenter=hitinfo.gameObject.transform.position;
		}
		if(hitinfo.gameObject.tag=="Deposit")
		{
			bIsSettled=true;
			vDeskCenter=hitinfo.gameObject.transform.position;
		}
		if(hitinfo.gameObject.tag=="Withdrawl")
		{
			bIsSettled=true;
			vDeskCenter=hitinfo.gameObject.transform.position;
		}
		if(hitinfo.gameObject.tag=="Queue1" || hitinfo.gameObject.tag=="Queue2"| hitinfo.gameObject.tag=="Queue3"| hitinfo.gameObject.tag=="Queue4"| hitinfo.gameObject.tag=="Queue5"| hitinfo.gameObject.tag=="Queue6")
		{
			vBenchCenter=hitinfo.gameObject.transform.position;
			bOnQueue=true;
			FindQueue(hitinfo);//bIsSettled=true;
			//Debug.Log("out of bench");
			
		}
		if(hitinfo.gameObject.tag=="CustomerLimit")
		{
			Destroy (gameObject);
			Play.timeLeft-=10; // If customers returns angry our time to operate the bank decreases
			Play.score-=10;
		}

		if(hitinfo.gameObject.tag=="WaitingQueue")
		{	
			bIsWaiting=true;
			bIsWaitRight=true;
			hitinfo.gameObject.tag="WaitingQueue1";

		}
		else if(hitinfo.gameObject.tag=="WaitingQueue1")
		{	
			bIsWaiting=true;
			bIsWaitRight=false;
			hitinfo.gameObject.tag="WaitingQueue";

		}
		if(hitinfo.gameObject.tag=="WaitQueueEnd")
		{	
			bIsWaiting=true;
			bWaitQueueEnd=true;
			bIsAllowedToDragInWait=true;
			//bIsWaitRight=true;

			
		}
		//Debug.Log(hitinfo.gameObject.tag);

	}
	void OnTriggerStay(Collider hitinfo)
	{
		if(!Play.bIsPaused && !Play.bIsGameOver)
		{
		
			/*if(hitinfo.gameObject.CompareTag("Customer"))
			{
				Debug.Log ("HELLO THERE");
			}*/
			// If the customer is in contact with any of the desk . Time taken to service the customer and awarding of score
			if(hitinfo.gameObject.CompareTag("Loan") || hitinfo.gameObject.CompareTag("Deposit") || hitinfo.gameObject.CompareTag("Withdrawl"))
			{
				localTimeOffDesk-=Time.deltaTime;
				if(localTimeOffDesk<0 && bIsSettled)
				{
					Play.customersSatisfied++;
					Play.score+= 10 * multiplier;
					Play.timeLeft+=2; // Plus 5 sec for each customer serviced
					SetMoveQueue(queueNumber,true);
					Destroy(gameObject);

				}
			}


		}
/*		if( Play.moveQueue)
		Debug.Log("destroyed end");*/
	}
	void customerPlacementOnBench() // Function of assigning the x position of bench to customers x coordinate
	{
		bOnQueue=true;
		Vector3 v=gameObject.transform.position;
		v.x=vBenchCenter.x;
		gameObject.transform.position=v;

	}
	void customerPlacementOnDesk() // Function of assigning the x position of desk to customers x coordinate
	{
		bIsSettled=true;
		Vector3 v=gameObject.transform.position;
		v.x=vDeskCenter.x+2.0f;
		gameObject.transform.position=v;
	}

/*	void collsionUpdates( )
	{
		if(bIsAttended)
			bIsSettled=true;
		else
			Play.  bIsGameOver=true;

	}*/
	// Update is called once per frame
	void Update () {

		if(!Play.  bIsGameOver)
		{
			if(!Play.bIsPaused)
			{
				if(!bOnQueue && !bIsAttended && !bIsWaiting && !bIsAllowedToDragInWait ) // Traverse the customer only if the customer is unattended or he/she is not on bench
				{
					transform.position+=(new Vector3(-0.15f,0,0));
					m_objAnimationScript.Animate(3,5,18,0,0,5);

				}

				else if((bOnQueue && !bIsSettled && bIsAllowedToMove )|| bIsWaiting) // Traverse in the direction of counters if it has been placed on queue
				{	
					if(!bOnAnotherCustomer )
					{
						if(bRightCounters || (bIsWaitRight && !bWaitQueueEnd && !bIsAllowedToDragInWait))
						{
							transform.position+=(new Vector3(0,0,0.15f));
							m_objAnimationScript.Animate(3,5,18,2,0,5);

						}
						else if(bLeftCounters || (!bIsWaitRight && !bWaitQueueEnd && !bIsAllowedToDragInWait))
						{
							transform.position+=(new Vector3(0,0,-0.15f));
							m_objAnimationScript.Animate(3,5,18,1,0,5);

						}
					}
				}
				else if(bDragBack)
				{
					vMovePosition += new Vector3(-0.1f,0,0);
				}

				if(!bIsSettled && bIsAttended || bIsWaiting) // If the customer is attended and not serviced . Countdown is used to calculate time taken by him/her to get angry.
				{	normalWaitTime-=Time.deltaTime;
					if(normalWaitTime<0 ) 
					{

						//smoodOffLocalTime-=Time.deltaTime;
						//gameObject.renderer.material.color= Color.Lerp(Color.blue, Color.red,1.0f- moodOffLocalTime/(moodOffTime+0.0f));// Change of face colour as time passes
					}

					if(moodOffLocalTime<=0 && !ReturnMoveQueue(queueNumber)) // if the timer of the customers getting angry time goes to zero. Destory the customer
					{
						Play.customersReturnedAngry++;
						Play.timeLeft-=10; // If customers returns angry our time to operate the bank decreases
						Play.score-=20;    //  and also score also decreases as well
						SetMoveQueue(queueNumber,true);
						Destroy(gameObject);
					}
				}
				if( ReturnMoveQueue(queueNumber))/*&& p_bool_LastPlace && !bOnAnotherCustomer)*/
				{
					//p_int_CustomersAttached--;
					SetMoveQueue(queueNumber,false);
					StartCoroutine(Wait (0.5f));

				}
			}
			else
			{
				if(bLeftCounters)
					m_objAnimationScript.Animate(3,5,18,1,1,1);
				else if (bRightCounters)
					m_objAnimationScript.Animate(3,5,18,2,1,1);
				else
					m_objAnimationScript.Animate(3,5,18,0,1,1);
			}
			if(!bDoneWithTechUpgrades)
			techUpgrades();

		}
		else
		{


		}


	}

	// All the functions after it is for drag and drop
	void OnMouseDown()
	{
		if(!bIsSettled && !bOnQueue && !bDroppedOnQueue )
		{
			if(bIsWaiting )
			{
				if(bWaitQueueEnd && bIsAllowedToDragInWait)
					{
						vMyPosition=gameObject.transform.position;

						screenPoint = Camera.main.WorldToScreenPoint(vMyPosition);
						
						offset = vMyPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

						bDragBack=true;

						vMovePosition=vMyPosition;

						bIsAllowedToMove=false;

					}
			}
			else{
				vMyPosition=gameObject.transform.position;
				
				screenPoint = Camera.main.WorldToScreenPoint(vMyPosition);
				
				offset = vMyPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
				
				bDragBack=true;
				
				vMovePosition=vMyPosition;
				
				bIsAllowedToMove=false;
			}
		}

	}
	void OnMouseUp()
	{
		if(bIsWaiting )
		{
			if(bWaitQueueEnd )
			{
				if(bOnQueue && !bOnAnotherCustomer )
				{
					customerPlacementOnBench();
					bDroppedOnQueue=true;

				}
				else if (!bDroppedOnQueue)// If the customer is not placed anywhere, on desk or on queue. then return it to original location
				{
					transform.position=vMovePosition;
					bDragBack=false;
					bIsAttended=false;
					bOnQueue=false;
					bRightCounters=false;
					bLeftCounters=false;


				}
				bIsAllowedToMove=true;
				bIsAllowedToDragInWait=false;
			}
		}
		else
		{
			if(bOnQueue && !bOnAnotherCustomer )
			{
				customerPlacementOnBench();
				bDroppedOnQueue=true;
				
			}
			else if (!bDroppedOnQueue)// If the customer is not placed anywhere, on desk or on queue. then return it to original location
			{
				transform.position=vMovePosition;
				bDragBack=false;
				bIsAttended=false;
				bOnQueue=false;
				bRightCounters=false;
				bLeftCounters=false;
				
				
			}
			bIsAllowedToMove=true;
			bIsAllowedToDragInWait=false;
		}

	}
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint),offset;
		if(bIsWaiting )
		{
			if(bWaitQueueEnd  || bIsAllowedToDragInWait)
			{
				if(!Play.  bIsGameOver && !bIsSettled  && !bDroppedOnQueue)
				{

					if((curPosition.z<(oRightCounter.transform.position.z + 5) && curPosition.z>(oLeftCounter.transform.position.z -5)&& curPosition.x>-7) || (curPosition.x<-7 && curPosition.x>-10) )
					{
						transform.position = curPosition;
					}
					else if(curPosition.x<-10 && bWaitQueueEnd)
					{
						Vector3 temp;
						temp.x=curPosition.x;
						temp.y=curPosition.y;
						temp.z=transform.position.z;
						transform.position=temp;
					}
					else if(curPosition.x<-10)
					{
						Vector3 temp;
						temp.z=curPosition.z;
						temp.y=curPosition.y;
						temp.x=transform.position.x;
						transform.position=temp;
					}
					else
					{
						Vector3 temp;
						temp.x=curPosition.x;
						temp.y=curPosition.y;
						temp.z=transform.position.z;
						transform.position=temp;
					}
				}
				bIsAttended=true;
			}
		}
		else
		{
			if(!Play.  bIsGameOver && !bIsSettled  && !bDroppedOnQueue)
			{
				
				if((curPosition.z<(oRightCounter.transform.position.z + 5) && curPosition.z>(oLeftCounter.transform.position.z -5)&& curPosition.x>-7) || (curPosition.x<-7 && curPosition.x>-10) )
				{
					transform.position = curPosition;
				}
				else if(curPosition.x<-10 && bWaitQueueEnd)
				{
					Vector3 temp;
					temp.x=curPosition.x;
					temp.y=curPosition.y;
					temp.z=transform.position.z;
					transform.position=temp;
				}
				else if(curPosition.x<-10)
				{
					Vector3 temp;
					temp.z=curPosition.z;
					temp.y=curPosition.y;
					temp.x=transform.position.x;
					transform.position=temp;
				}
				else
				{
					Vector3 temp;
					temp.x=curPosition.x;
					temp.y=curPosition.y;
					temp.z=transform.position.z;
					transform.position=temp;
				}
			}
			bIsAttended=true;
		}
	}
	private IEnumerator Wait(float seconds) //Functions created to make a delay in instantiation of the customers 0000
		// It reset the flag for generation of new customers and wait for some time to set it again.
		
	{
		if (!bEnteredCoroutine)
		{
			yield return new WaitForSeconds (seconds);
			bEnteredCoroutine=true;
			//Debug.Log ("COROUTINE ENCOUNTERED");
		//	if(!bOnAnotherCustomer)
				bIsAllowedToMove = true;
			if (bOnAnotherCustomer) 
			{
				bOnAnotherCustomer = false;

			}
		}
	
		
	}
	void OnBecameInvisible() {  // Destroy the customer if it not visible
		Destroy(gameObject);
	}
	void FindQueue(Collider hitinfo)
	{
		if(hitinfo.gameObject.tag=="Queue1")
		{
			queueNumber=1;
		}
		if(hitinfo.gameObject.tag=="Queue2")
		{
			queueNumber=2;
		}
		if(hitinfo.gameObject.tag=="Queue3")
		{
			queueNumber=3;
		}
		if(hitinfo.gameObject.tag=="Queue4")
		{
			queueNumber=4;
		}
		if(hitinfo.gameObject.tag=="Queue5")
		{
			queueNumber=5;
		}
		if(hitinfo.gameObject.tag=="Queue6")
		{
			queueNumber=6;
		}
	}
	bool ReturnMoveQueue(int QueueNo)
	{
		switch(QueueNo)
		{
			case 1 : return Play.moveQueue1;
			break;
			case 2 : return Play.moveQueue2;
			break;
			case 3 : return Play.moveQueue3;
			break;
			case 4 : return Play.moveQueue4;
			break;
			case 5 : return Play.moveQueue5;
			break;
			case 6 : return Play.moveQueue6;
			break;
		default: return false;
			
		}
	}
	void SetMoveQueue(int QueueNo,bool value)
	{
		switch(QueueNo)
		{
			case 1 : Play.moveQueue1=value;
					break;
			case 2 : Play.moveQueue2=value;
					break;
			case 3 : Play.moveQueue3=value;
					break;
			case 4 : Play.moveQueue4=value;
					break;
			case 5 : Play.moveQueue5=value;
					break;
			case 6 : Play.moveQueue6=value;
					break;
		}
	}
	void techUpgrades()
	{
			//Play.bTechUpgradesValid=false;
		bDoneWithTechUpgrades=true;
			localTimeOffDesk-=5;
		//	Play.timeLeft-=5;

	}
}
	
