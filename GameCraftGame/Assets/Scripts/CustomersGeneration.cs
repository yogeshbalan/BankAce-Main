using UnityEngine;
using System.Collections;

// This script control the creation of the various customers gameobjects. This script is applied on the EntryPlane gameobject in the scene MainGame
// from where the customers are generated.
    
public class CustomersGeneration : MonoBehaviour {

	// These are the types of customers that can be generated 
	public GameObject oCoporate; 
	public GameObject oNormalGirl;
	public GameObject oThief;
	public GameObject oElderelyMale;
	public GameObject oElderelyFemale;
	public GameObject oImportant;
	public GameObject oMultiLingual;
	public GameObject oWealthy;
	public GameObject oNormalGuy;
	public GameObject oNRI;
	public GameObject oComplaining;
	public static float customersInWave=30;

	private bool bIsReadyToMakeCustomers=false;

	float iTimeBetweenCustomers=1.5f;
	// Use this for initialization
	void Start () {
		customersInWave = Random.Range (30f,60f);
		bIsReadyToMakeCustomers=true;

	}
	
	// Update is called once per frame
	void Update () {
		if(!Play.bIsGameOver)
		{
			if(!Play.bIsPaused)
			{
				float upgradeTime=0.0f;
				if(Play.bInfraUpgradesValid)
					upgradeTime=0.5f;

				if(bIsReadyToMakeCustomers & customersInWave>0)  // If the flag to generate new customers is set and no of customers generated in a wave is greater than 0
				{
					//GameObject temp;
					StartCoroutine(Wait(iTimeBetweenCustomers-upgradeTime));/*changed the probability of appearance of old people*/
					switch(Random.Range(0,Play.levelCleared+3)) // Select which kind of customer to instantiate
					{
					case 3 :Instantiate(oComplaining,gameObject.transform.position,Quaternion.identity);

						break;
					case 2 :Instantiate(oNormalGirl,gameObject.transform.position,Quaternion.identity);
						break;
					case 1 :Instantiate(oElderelyMale,gameObject.transform.position,Quaternion.identity);
						break;
					case 4:Instantiate(oNormalGuy,gameObject.transform.position,Quaternion.identity);
						break;
					//case 5:Instantiate(oThief,gameObject.transform.position,Quaternion.identity);
					//	break;
					case 5 :Instantiate(oElderelyFemale,gameObject.transform.position,Quaternion.identity);
						break;
					case 6 :Instantiate(oWealthy,gameObject.transform.position,Quaternion.identity);
						break;
					case 7 :Instantiate(oImportant,gameObject.transform.position,Quaternion.identity);
						break;
					case 8 :Instantiate(oNRI,gameObject.transform.position,Quaternion.identity);
						break;
					case 9 :Instantiate(oCoporate,gameObject.transform.position,Quaternion.identity);
						break;
					case 10:Instantiate(oMultiLingual,gameObject.transform.position,Quaternion.identity);
						break;
					
					
					
						
					}
					//yield return new WaitForSeconds(2.0f);

				}
			}
		}

	}
	private IEnumerator Wait(float seconds) //Functions created to make a delay in instantiation of the customers 
											// It reset the flag for generation of new customers and wait for some time to set it again.
	
	{
		
		//Debug.Log("start waiting");
		bIsReadyToMakeCustomers=false;
		///if(StartGame.g_bool_isNormalMode)
		{
			//customersInWave--;
		}
		yield return new WaitForSeconds(seconds);
		bIsReadyToMakeCustomers=true;
		//Debug.Log("waiting");
		
	}
}