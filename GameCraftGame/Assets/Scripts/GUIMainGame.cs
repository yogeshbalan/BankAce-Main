using UnityEngine;
using System.Collections;

// This Script handles all the gui items displayed on the screen during gameplay. This script has been applied on Main Camera of scene MainGame


public class GUIMainGame : MonoBehaviour {
	public float x,y,h,w;
	private float a;
	private float b;
	private Vector2 res;
	Touch touch;
	int moneyEarnedThisSession=0;
	bool bGameOverScreen=true;
	bool bQuestionScreen=false;
	bool bAnswerScreen=false;
	bool bPolicyTaken=false;
	public GUIStyle ans_box4;
	bool bAccidentOccured=false;
	bool bpolicyDetails=false;
	bool scenario_screen=false;
	bool summaryscreen=false;
	int accidentDeduction=0;
	bool bInfraUpgradeWindow=false;
	bool bTechUpgradeWindow=false;
	float returnsFromPolicies=0;
	public GUIStyle timedanger;
	public GUIStyle blank;
	public GUIStyle the_bar;
	public GUIStyle invest_button;
	public GUIStyle ans_funds;
	public GUIStyle ans_button_continue;
	public GUIStyle pause_button;
	public GUIStyle play_button;
	public GUIStyle exit_button;
	public GUISkin bottomGUISkin;
	public GUIStyle ans_box;
	public GUIStyle ans_box2;
	public GUIStyle ans_box3;
	public GUIStyle scenario;
	public GUIStyle test;
	public GUIStyle the_bar2;
	public GUIStyle ans_button;
	public GUIStyle ans_button1;
	public GUIStyle ans_button2;
	public GUIStyle ans_button_next;
	public GUIStyle ans_button_y;
	public GUIStyle ans_button_n;
	public GUIStyle ques;
	public GUIStyle info;
	public GUIStyle info2;
	public GUIStyle text1;
	public GUIStyle text2;
	public GUIStyle info3;
	public GUIStyle after_round_1;
	public GUIStyle after_round_2;
	public GUIStyle after_round_3;
	public GUIStyle after_round_4;
	public GUIStyle after_round_5;
	public GUIStyle after_round_6;
	public GUIStyle after_round_7;
	public GUIStyle after_round_8;
	public GUIStyle after_round_9;
	public GUIStyle after_round_10;
	public GUIStyle after_round_11;
	public GUIStyle after_round_12;
	public GUIStyle after_round_13;
	public GUIStyle Pausepopup;
	public GUIStyle Pausepopup1;
	public GUIStyle Pausepopup2;
	public GUIStyle Pausepopup3;
	public GUIStyle Pausepopup4;
	public GUIStyle PreviousStyle;
	public GUIStyle NextStyle;
	//public GUIStyle Pausepopup5;
	//Pause
	public GUIStyle PauseBoxStyle;
	public GUIStyle resumeButton;
	public GUIStyle investment_screen1;
	public GUIStyle investment_screen2;
	public GUIStyle investment_screen3;
	public GUIStyle investment_screen4;
	public GUIStyle investment_screen5;
	public GUIStyle investment_screen6;
	public GUIStyle investment_screen7;
	public GUIStyle investment_screen8;
	public GUIStyle investment_screen9;
	public GUIStyle investment_screen10;
	public GUIStyle investment_screen11;
	public GUIStyle investment_screen12;
	public GUIStyle investment_screen13;
	public GUIStyle investment_screen14;
	public GUIStyle investment_screen15;
	public GUIStyle investment_screen16;
	public GUIStyle investment_screen17;
	public GUIStyle investment_screen18;
	public GUIStyle investment_screen19;
	public GUIStyle investment_screen20;
	public GUIStyle investment_screen21;
	public GUIStyle investment_screen22;
	public GUIStyle investment_screen23;
	public GUIStyle investment_screen24;
	public GUIStyle investment_screen25;
	public GUIStyle investment_screen26;
	public GUIStyle investment_screen27;
	public GUIStyle investment_screen28;
	public GUIStyle investment_screen29;
	public GUIStyle investment_screen30;
	public GUIStyle investment_screen31;
	public GUIStyle investment_screen32;
	public GUIStyle investment_screen33;
	public GUIStyle investment_screen34;
	public GUIStyle investment_screen35;

	public GUIStyle star;
	public GUIStyle star1;
	public GUIStyle star2;
	public GUIStyle star3;

	public bool win1=false;
	public bool win2=false;
	public bool win3=false;

	public bool win4=false;

	public bool win5=false;

	public bool win6=false;
	public bool win7=false;


	public static bool bscreen_new=false;
	public GUIStyle screen_new;
	public GUIStyle screen_new1;
	public GUIStyle screen_new2;
	public GUIStyle screen2_new;
	public GUIStyle ans_button_retry;
	public GUIStyle ans_button_retry2;
	public GUIStyle amount_button;
	bool ar_2=true;
//	public GUIStyle after_round_5;
	float x1=0;
	float x2=0;
	float y1=0;
	float y2=0;
	// Use this for initialization
	void Start () {
		res = new Vector2 (Screen.width, Screen.height);
		a = Screen.width / 1920.0f;
		b = Screen.height / 1042.0f;
		moneyEarnedThisSession=0;
		bAnswerScreen=false;
		bGameOverScreen=true;
		bQuestionScreen=false;
		bPolicyTaken=false;
		bAccidentOccured=false;
		bpolicyDetails=false;
		accidentDeduction=0;
		bInfraUpgradeWindow=false;
		bTechUpgradeWindow=false;

		//StartCoroutine (bottomBar());
	}
	 
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			GUI.Box (new Rect(0, 0, Screen.width, Screen.height), "hi", test);
		}
		if(!Play.bIsGameOver) 
		{
			if(!Play.bIsPaused)
			{
				Play.timeLeft-=Time.deltaTime; // Timer Countdown . 
				//Debug.Log(Play.timeLeft);
				if (Play.timeLeft<=0)		   // As time left turns zero . 
				{
					Play.bIsGameOver=true;	// Set the flag for gameover.
					moneyEarnedThisSession=10000* Play.customersSatisfied;
					PlayerPrefs.SetInt("LevelCleared", ++Play.levelCleared);
					Play.moneyEarned=PlayerPrefs.GetInt("Money",0);
					//accidentOccured();


					returnsFromPolicies=Mathf.FloorToInt(policiesReturns(Play.levelCleared));
				}
					Play.g_int_MoneyLeft=Mathf.FloorToInt((Play.timeLeft * 5000.0f)/60.0f);
			}	

		}
		else
		{
			if(Play.score<=0)
				Play.score=0;

		}
	
	}
	Rect windowRect =new  Rect (0,0,Screen.width,Screen.height); // It sets the area for the window appearing after gameover
	void OnGUI()
	{
		//public Texture pause_button;
		//public Texture play_button;
		if(bottomGUISkin != null) GUI.skin = bottomGUISkin;
		//adding custom GUIskin
		/*if(Play.g_int_MoneyLeft>=0)
			GUI.Label(new Rect (Screen.width-Screen.width/6,Screen.height-Screen.height/1.1f,Screen.width/4,Screen.height/16),"MoneyLeft :" + Play.g_int_MoneyLeft); // Box for displaying the score 
		else
			GUI.Label(new Rect (Screen.width-Screen.width/6,Screen.height-Screen.height/1.1f,Screen.width/4,Screen.height/16),"MoneyLeft : 0"); // Box for displaying the score 
*/

		//GUI.Label(new Rect (Screen.width-Screen.width/6,Screen.height-Screen.height/1.2f,Screen.width/4,Screen.height/16),"Satisfied :" + Play.g_int_CustomersSatisfied); // Box for displaying the no of satisfied customers	
		//GUI.Label(new Rect (Screen.width-Screen.width/6,Screen.height-Screen.height/1.3f,Screen.width/4,Screen.height/16),"Angry :" + Play.g_int_CustomersReturnedAngry); // Box for displaying the no of angry customers .
		//GUI.Label(new Rect (Screen.width-Screen.width/6,Screen.height-Screen.height/1.4f,Screen.width/4,Screen.height/16),"Time Left :" + Mathf.FloorToInt(Play.timeLeft)); // Box for displaying the time left in completion of the level
		if(bInfraUpgradeWindow)
		{
			infraUpgradre();
		}
		else if(bTechUpgradeWindow )
		{
			techUpgrade();
		}

		else if(!Play.bIsGameOver ) // it check which GUI components to be displayed when game is over or not.
		{	
			sideBar();
			bottomBar();						// If the game is not over 
			pauseFunctionality();
		}
		else if(Play.bIsGameOver) // if the game is over then display the gameover window
		{	
			Window();
		}
	}

	void Window()
	{
		//if(WindowId==0)
			windowRect = GUI.Window (0,windowRect, DoMyWindow, "Time Over!!");
		/*else if(WindowId==1)
			windowRect = GUI.Window (1,windowRect, DoMyWindow, "Time Over!!");
		else if(WindowId==2)
			windowRect = GUI.Window (2,windowRect, DoMyWindow, "Time Over!!");*/

	}
	void DoMyWindow(int windowID) { // Used to display the gui components displayed in the window appearing after gameover
				Debug.Log (windowID);
				//if(windowID==0){
				DestroyGameObjects ();
				if (bGameOverScreen) {
						GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);
						GUI.Box (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", ans_box2);
						//GUI.Label (new Rect (0, Screen.height / 8, Screen.width, Screen.height / 5), "Customers satisfied : " + Play.customersSatisfied + "", after_round_1);
						//	GUI.Label (new Rect (500, 150, Screen.width / 7f, Screen.height / 8f), "" + Play.customersSatisfied + "", after_round_1);		
						if (Play.customersSatisfied < CustomersGeneration.customersInWave / 4) {
								GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * 0.43f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_2);
								//GUI.Box (new Rect (Screen.width / 1.8f, Screen.height / 3f, Screen.width / 40, Screen.height / 15), "", after_round_3);
								//GUI.Box (new Rect (Screen.width / 1.6f, Screen.height / 3f, Screen.width / 40, Screen.height / 15), "", after_round_3);
						}
						if (Play.customersSatisfied >= CustomersGeneration.customersInWave / 4 && Play.customersSatisfied < CustomersGeneration.customersInWave / 2) {
								GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * 0.43f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_3);
								x1 = 1;
						}
						if (Play.customersSatisfied >= CustomersGeneration.customersInWave / 2 && x1 != 1 && Play.customersSatisfied < (3 * (CustomersGeneration.customersInWave / 4))) {
								GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * 0.43f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_4);
								x2 = 1;
						}
						if (Play.customersSatisfied >= (3 * (CustomersGeneration.customersInWave / 4)) && x1 != 1 && x2 != 1) {
								GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * 0.43f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_5);

						}
						
				
						/*while(i<=6)
				{	float value=policiesReturns(i);

				if(value!=0)
					{
					height+=50;
						GUI.Label (new Rect(Screen.width/3,height ,Screen.width/3,Screen.height/10),policiesAccordingToLevel(i)+" : "+ value);
						sum+=value;
					}

				}*/
						
						
						/*PlayerPrefs.SetInt("Level1",0);
			PlayerPrefs.SetInt("Level2",0);
			PlayerPrefs.SetInt("Level3",0);
			PlayerPrefs.SetInt("Level4",0);
			PlayerPrefs.SetInt("Level5",0);
			PlayerPrefs.SetInt("Level6",0);*/
						//GUI.Box(new Rect (Screen.width/2,Screen.height/4f,Screen.width/3,Screen.height/24), "Policies Returns       "+sum +" Rupees");
						GUI.Box (new Rect (200, Screen.height / 2.9f, Screen.width - 400, Screen.height / 7), "", after_round_6);
						GUI.Box (new Rect (Screen.width * 0.2f, Screen.height * .357f, Screen.width * .5f, Screen.height * .07f), "", the_bar);
						GUI.Box (new Rect (Screen.width * .2f, Screen.height * .357f, (Screen.width * 0.5f * (Play.customersSatisfied / CustomersGeneration.customersInWave)), Screen.height * .07f), "", the_bar2);
						GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.36f, Screen.width * 0.1f, Screen.height * 0.1f), "" + Play.customersSatisfied + "/" + (int)CustomersGeneration.customersInWave + "", blank);
						GUI.Box (new Rect (Screen.width * 0.7f, Screen.height * 0.365f, Screen.width * 0.2f, Screen.height * 0.1f), "" + (int)((float)(Play.customersSatisfied / CustomersGeneration.customersInWave) * 100) + "% Success", blank);
						//	if(Input.GetMouseButtonDown(0))
						//	{
						//		GUI.Box(new Rect(100,100,100,100),"hi",test);
						//	
			if (Play.customersSatisfied > CustomersGeneration.customersInWave / 2) 
			//if(1==1)
			{
				GUI.Box (new Rect (230, 360, 550, 60), "", text1);

		if (GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2.4f, Screen.width * 0.12f, Screen.height * 0.08f), "", ans_button_retry)) 
				{
					//bQuestionScreen = true;
					bGameOverScreen = false;
					//Play.moneyEarned += moneyEarnedThisSession;
					//PlayerPrefs.SetInt ("Money", Play.moneyEarned);
					summaryscreen = true;
				}
			}
			else
			{
				GUI.Box (new Rect (230, 360, 550, 90), "", text2);
				if ((GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2f, Screen.width * 0.12f, Screen.height * 0.08f), "", ans_button_retry2))) {
					PlayerPrefs.SetInt ("LevelCleared", --Play.levelCleared);
					//Play.levelCleared--;
					ResetVariables ();
					Application.LoadLevel ("Profile");
				}
			}
			
			//GUI.Label (new Rect (Screen.width * .34f, Screen.height * .47f, Screen.width * .2f, Screen.height * .035f), "Salary Earned in this level"  /*+ "Rupees"*/, after_round_9);
						/*						GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.47f, Screen.width * 0.1f, Screen.height * 0.035f), ":" + moneyEarnedThisSession, after_round_9);
						//GUI.Box(new Rect(Screen.width *x, Screen.height*y, Screen.width *w, Screen.height*h),":"+ moneyEarnedThisSession,after_round_9);
						GUI.Label (new Rect (Screen.width * .34f, Screen.height * .52f, Screen.width * .2f, Screen.height * .035f), "Previous Savings", after_round_9);
						GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.52f, Screen.width * 0.1f, Screen.height * 0.035f), ":" + Play.moneyEarned, after_round_9);			
						//GUI.Label(new Rect (Screen.width/10,Screen.height/2.5f,Screen.width/3,Screen.height/24), "Money Earned       "+moneyEarnedThisSession +" Rupees");
						//GUI.Label(new Rect (Screen.width/2,Screen.height/2.0f,Screen.width/3,Screen.height/24), "Home Loan Deduction                  ");
						//	GUI.Label(new Rect (Screen.width/2,Screen.height/2.0f,Screen.width/3,Screen.height/24), "Accident to family memebers                  ");
						GUI.Box (new Rect (200, Screen.height / 1.9f, Screen.width - 400, Screen.height / 9), "", after_round_7);	
						GUI.Label (new Rect (Screen.width * .34f, Screen.height * .67f, Screen.width * .2f, Screen.height * .035f), "Home Assets", after_round_9);
						GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.67f, Screen.width * 0.1f, Screen.height * 0.035f), ":0", after_round_9);
						GUI.Label (new Rect (Screen.width * .34f, Screen.height * .718f, Screen.width * .2f, Screen.height * .035f), "Misc. Assets", after_round_9);
						GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.718f, Screen.width * 0.1f, Screen.height * 0.035f), ":0", after_round_9);
						//	GUI.Label(new Rect (Screen.width/2,Screen.height/1.75f,Screen.width/3,Screen.height/24),"Total Assets       "+(Play.moneyEarned + moneyEarnedThisSession)  +" Rupees");
						//GUI.Box(new Rect(200,Screen.height/1.4f,Screen.width-400,Screen.height/10),"");
						GUI.Box (new Rect (200, Screen.height / 1.45f, Screen.width - 400, Screen.height / 9), "", after_round_8);	
						GUI.Label (new Rect (Screen.width * 0.66f, Screen.height * 0.818f, Screen.width * 0.15f, Screen.height * 0.035f), "" + (Play.moneyEarned + moneyEarnedThisSession) + " Rupees", after_round_9);
						//PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money")+ moneyEarnedThisSession);
			*/			
						
						
					//	if (bAccidentOccured) {
					//			if (PlayerPrefs.GetInt ("Level1", 0) == 0)
					//					GUI.Box (new Rect (Screen.width / 2, Screen.height / 1.2f, Screen.width / 3, Screen.height / 24), "You have met an accident during the course. As u have not taken the health insurance 5000 rupees has been deducted from your account");
					//			else
					//					GUI.Box (new Rect (Screen.width / 2, Screen.height / 1.2f, Screen.width / 3, Screen.height / 24), "You have met an accident during the course. As u have taken the health insurance, the expenses has been covered in it or is minimized. Amout Deducted  :)" + accidentDeduction);
					//	
					//	}
				}
		else if (summaryscreen) 
		{
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);
			GUI.Box (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", ans_box4);
			        	GUI.Label (new Rect (Screen.width * .25f, Screen.height * .47f, Screen.width * .2f, Screen.height * .035f), "Salary Earned in this level :"  /*+ "Rupees"*/, after_round_9);
						GUI.Box (new Rect (Screen.width * 0.63f, Screen.height * 0.47f, Screen.width * 0.1f, Screen.height * 0.035f), "" + moneyEarnedThisSession, after_round_9);
						//GUI.Box(new Rect(Screen.width *x, Screen.height*y, Screen.width *w, Screen.height*h),":"+ moneyEarnedThisSession,after_round_9);
						GUI.Label (new Rect (Screen.width * .25f, Screen.height * .52f, Screen.width * .2f, Screen.height * .035f), "Previous Savings :", after_round_9);
						GUI.Box (new Rect (Screen.width * 0.63f, Screen.height * 0.52f, Screen.width * 0.1f, Screen.height * 0.035f), "" + Play.moneyEarned, after_round_9);			
						//GUI.Label(new Rect (Screen.width/10,Screen.height/2.5f,Screen.width/3,Screen.height/24), "Money Earned       "+moneyEarnedThisSession +" Rupees");
						//GUI.Label(new Rect (Screen.width/2,Screen.height/2.0f,Screen.width/3,Screen.height/24), "Home Loan Deduction                  ");
						//	GUI.Label(new Rect (Screen.width/2,Screen.height/2.0f,Screen.width/3,Screen.height/24), "Accident to family memebers                  ");
						GUI.Box (new Rect (200, Screen.height / 1.9f, Screen.width - 400, Screen.height / 9), "", after_round_7);	
						//GUI.Label (new Rect (Screen.width * .34f, Screen.height * .67f, Screen.width * .2f, Screen.height * .035f), "Home Assets", after_round_9);
						//GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.67f, Screen.width * 0.1f, Screen.height * 0.035f), ":0", after_round_9);
						//GUI.Label (new Rect (Screen.width * .34f, Screen.height * .718f, Screen.width * .2f, Screen.height * .035f), "Misc. Assets", after_round_9);
						//GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.718f, Screen.width * 0.1f, Screen.height * 0.035f), ":0", after_round_9);
						//	GUI.Label(new Rect (Screen.width/2,Screen.height/1.75f,Screen.width/3,Screen.height/24),"Total Assets       "+(Play.moneyEarned + moneyEarnedThisSession)  +" Rupees");
						//GUI.Box(new Rect(200,Screen.height/1.4f,Screen.width-400,Screen.height/10),"");
						GUI.Box (new Rect (200, Screen.height / 1.45f, Screen.width - 400, Screen.height / 9), "", after_round_8);	
						GUI.Label (new Rect (Screen.width * 0.63f, Screen.height * 0.8f, Screen.width * 0.15f, Screen.height * 0.035f), "" + (Play.moneyEarned + moneyEarnedThisSession) + " INR", after_round_9);
						//PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money")+ moneyEarnedThisSession);
			GUI.Box (new Rect (200, Screen.height / 2.9f, Screen.width - 400, Screen.height / 7), "", after_round_6);
			GUI.Box (new Rect (Screen.width * 0.4f, Screen.height * .29f, Screen.width * .3f, Screen.height * .07f), "", the_bar);
			GUI.Box (new Rect (Screen.width * .4f, Screen.height * .29f, (Screen.width * 0.3f * (Play.customersSatisfied / CustomersGeneration.customersInWave)), Screen.height * .07f), "", the_bar2);
			GUI.Box (new Rect (Screen.width * 0.6f, Screen.height * 0.3f, Screen.width * 0.1f, Screen.height * 0.1f), "" + Play.customersSatisfied + "/" + (int)CustomersGeneration.customersInWave + "", blank);
			GUI.Box (new Rect (Screen.width * 0.7f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.1f), "" + (int)((float)(Play.customersSatisfied / CustomersGeneration.customersInWave) * 100) + "% Success", blank);

			//GUI.Label (new Rect (0, Screen.height / 8, Screen.width, Screen.height / 5), "Customers satisfied : " + Play.customersSatisfied + "", after_round_1);
			//	GUI.Label (new Rect (500, 150, Screen.width / 7f, Screen.height / 8f), "" + Play.customersSatisfied + "", after_round_1);		
			if (Play.customersSatisfied < CustomersGeneration.customersInWave / 4) {
				GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.35f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_2);
				//GUI.Box (new Rect (Screen.width / 1.8f, Screen.height / 3f, Screen.width / 40, Screen.height / 15), "", after_round_3);
				//GUI.Box (new Rect (Screen.width / 1.6f, Screen.height / 3f, Screen.width / 40, Screen.height / 15), "", after_round_3);
			}
			if (Play.customersSatisfied >= CustomersGeneration.customersInWave / 4 && Play.customersSatisfied < CustomersGeneration.customersInWave / 2) {
				GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.35f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_3);
				x1 = 1;
			}
			if (Play.customersSatisfied >= CustomersGeneration.customersInWave / 2 && x1 != 1 && Play.customersSatisfied < (3 * (CustomersGeneration.customersInWave / 4))) {
				GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.35f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_4);
				x2 = 1;
			}
			if (Play.customersSatisfied >= (3 * (CustomersGeneration.customersInWave / 4)) && x1 != 1 && x2 != 1) {
				GUI.Box (new Rect (Screen.width * 0.5f, Screen.height * 0.35f, Screen.width * 0.17f, Screen.height * 0.1f), "", after_round_5);
				
			}
			if ((GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2f, Screen.width * 0.12f, Screen.height * 0.08f), "", ans_button_retry2))) {
				PlayerPrefs.SetInt ("LevelCleared", --Play.levelCleared);
				//Play.levelCleared--;
				ResetVariables ();
				Application.LoadLevel ("Profile");
			}
			if (GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2.4f, Screen.width * 0.12f, Screen.height * 0.08f), "", ans_button_retry)) {
				bQuestionScreen = true;
				win1=true;
				bGameOverScreen = false;
				Play.moneyEarned += moneyEarnedThisSession;
				PlayerPrefs.SetInt ("Money", Play.moneyEarned);
				summaryscreen = false;
			}
			if (bAccidentOccured) {
				if (PlayerPrefs.GetInt ("Level1", 0) == 0)
					GUI.Box (new Rect (Screen.width / 2, Screen.height / 1.2f, Screen.width / 3, Screen.height / 24), "You have met an accident during the course. As u have not taken the health insurance 5000 rupees has been deducted from your account");
				else
					GUI.Box (new Rect (Screen.width / 2, Screen.height / 1.2f, Screen.width / 3, Screen.height / 24), "You have met an accident during the course. As u have taken the health insurance, the expenses has been covered in it or is minimized. Amout Deducted  :)" + accidentDeduction);
				
			}
		}
		else if (bQuestionScreen) {
			summaryscreen=false;
			bGameOverScreen=false;
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);
			if(Play.levelCleared==1)
			{
				if(win1)
				{
					summaryscreen=false;
					bGameOverScreen=false;
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen1);	
			
			if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=false;
						win7=true;
			}
			
			if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=false;
						win2=true;
			}
				}
				if(win2)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen2);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=true;
						win2=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win3=true;
						win2=false;
				}
					if (GUI.Button (new Rect (Screen.width / 1.7f, Screen.height / 1.38f, Screen.width * 0.12f, Screen.height * 0.08f), "",invest_button))
					{
						bQuestionScreen=false;
						bGameOverScreen=false;
						summaryscreen=false;
						bpolicyDetails=true;
					//	GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);
					//	GUI.Box (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", ans_box3);
					//	GUI.Label (new Rect (Screen.width * .25f, Screen.height * .47f, Screen.width * .2f, Screen.height * .035f), "Salary Earned in this level :"  /*+ "Rupees"*/, after_round_9);
					/*	GUI.Box (new Rect (Screen.width * 0.63f, Screen.height * 0.47f, Screen.width * 0.1f, Screen.height * 0.035f), "" + moneyEarnedThisSession, after_round_9);
						GUI.Label (new Rect (Screen.width * .25f, Screen.height * .52f, Screen.width * .2f, Screen.height * .035f), "Previous Savings :", after_round_9);
						GUI.Box (new Rect (Screen.width * 0.63f, Screen.height * 0.52f, Screen.width * 0.1f, Screen.height * 0.035f), "" + Play.moneyEarned, after_round_9);			
						GUI.Box (new Rect (200, Screen.height / 1.45f, Screen.width - 400, Screen.height / 9), "", after_round_8);	
						GUI.Label (new Rect (Screen.width * 0.66f, Screen.height * 0.818f, Screen.width * 0.15f, Screen.height * 0.035f), "" + (Play.moneyEarned + moneyEarnedThisSession) + " Rupees", after_round_9);
						if(Play.levelCleared>=1)
						{
							int i = 0;
							float sum = 0;
							float height = Screen.height * .57f;
							if (Play.levelCleared >= 1) {
								GUI.Label (new Rect (Screen.width * .34f, Screen.height * .57f, Screen.width * .2f, Screen.height * .035f), policiesAccordingToLevel (1),after_round_9);
								GUI.Label(new Rect(Screen.width * 0.616f, Screen.height * 0.57f, Screen.width * 0.007f, Screen.height * 0.035f), ":",after_round_9);
								GUI.Label(new Rect(Screen.width * 0.63f, Screen.height * 0.57f, Screen.width * 0.1f, Screen.height * 0.035f), "-"+ PlayerPrefs.GetInt ("Level" + Play.levelCleared, 0),after_round_13);
								sum += policiesReturns (1);
								height +=  Screen.height * .044f;
							}
							if (Play.levelCleared ==2) {
								GUI.Label (new Rect (Screen.width * .34f, height, Screen.width * .2f, Screen.height * .035f), policiesAccordingToLevel (2),after_round_9  );
								GUI.Label(new Rect(Screen.width * 0.616f, Screen.height * 0.57f, Screen.width * 0.007f, Screen.height * 0.035f), ":",after_round_9);
								GUI.Label(new Rect(Screen.width * 0.63f, height, Screen.width * 0.1f, Screen.height * 0.035f)," : " +PlayerPrefs.GetInt ("Level" + Play.levelCleared, 0),after_round_13);
								sum += policiesReturns (2);
								height += Screen.height * .044f;
							}
							if (Play.levelCleared > 3) {
								GUI.Label (new Rect (Screen.width / 3.2f, height, Screen.width / 3, Screen.height / 24), policiesAccordingToLevel (3) + " : " + policiesReturns (3));
								sum += policiesReturns (3);
								height += Screen.height / 25f;
							}
							if (Play.levelCleared > 4) {
								GUI.Label (new Rect (Screen.width / 3.2f, height, Screen.width / 3, Screen.height / 24), policiesAccordingToLevel (4) + " : " + policiesReturns (4));
								sum += policiesReturns (4);
								height += Screen.height / 25f;
							}
							if (Play.levelCleared > 5) {
								GUI.Label (new Rect (Screen.width / 3.2f, height, Screen.width / 3, Screen.height / 24), policiesAccordingToLevel (5) + " : " + policiesReturns (5));
								sum += policiesReturns (5);
								height += Screen.height / 25f;
							}
					}*/
				}
				}
					if(win3)
					{
						GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen3);	
						
						if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
							win2=true;
						win3=false;
						}
						
						if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
							win4=true;
						win3=false;
						}
					if (GUI.Button (new Rect (Screen.width / 1.7f, Screen.height / 1.38f, Screen.width * 0.12f, Screen.height * 0.08f), "",invest_button))
					{
						bQuestionScreen=false;
						bGameOverScreen=false;
						summaryscreen=false;
						bpolicyDetails=true;
					}
					}
						if(win4)
						{
							GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen4);	
							
							if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
								win3=true;
						win4=false;
							}
							
							if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
								win5=true;
						win4=false;
							}
						}
							if(win5)
							{
								GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen5);	
								
								if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
									win4=true;
						win5=false;
								}
								
								if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
									win6=true;
						win5=false;
								}
							}
								if(win6)
								{
									GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen6);	
									
									if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
										win5=true;
						win6=false;
									}
									
									if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
										win7=true;
						win6=false;
									}
								}
									if(win7)
									{
										GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen7);	
										
										if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
											win6=true;
										win7=false;
											}										
										if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
											win1=true;
											win7=false;
										}
			}
								}
			if(Play.levelCleared==2)
			{
				if(win1)
				{
					summaryscreen=false;
					bGameOverScreen=false;
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen8);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=false;
						win7=true;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=false;
						win2=true;
					}
				}
				if(win2)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen9);	
					

					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=true;
						win2=false;
				
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win3=true;
						win2=false;
					}
					if (GUI.Button (new Rect (Screen.width / 1.7f, Screen.height / 1.38f, Screen.width * 0.12f, Screen.height * 0.08f), "",invest_button))
					{
						bQuestionScreen=false;
						bGameOverScreen=false;
						summaryscreen=false;
						bpolicyDetails=true;
					}

				}
				if(win3)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen10);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win2=true;
						win3=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win4=true;
						win3=false;
					}
					if (GUI.Button (new Rect (Screen.width / 1.7f, Screen.height / 1.38f, Screen.width * 0.12f, Screen.height * 0.08f), "",invest_button))
					{
						bQuestionScreen=false;
						bGameOverScreen=false;
						summaryscreen=false;
						bpolicyDetails=true;
					}
				}
				if(win4)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen11);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win3=true;
						win4=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win5=true;
						win4=false;
					}
					if (GUI.Button (new Rect (Screen.width / 1.7f, Screen.height / 1.38f, Screen.width * 0.12f, Screen.height * 0.08f), "",invest_button))
					{
						bQuestionScreen=false;
						bGameOverScreen=false;
						summaryscreen=false;
						bpolicyDetails=true;
					}
				}
				if(win5)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen12);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win4=true;
						win5=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win6=true;
						win5=false;
					}
					if (GUI.Button (new Rect (Screen.width / 1.7f, Screen.height / 1.38f, Screen.width * 0.12f, Screen.height * 0.08f), "",invest_button))
					{
						bQuestionScreen=false;
						bGameOverScreen=false;
						summaryscreen=false;
						bpolicyDetails=true;
					}
				}
				if(win6)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen13);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win5=true;
						win6=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win7=true;
						win6=false;
					}
				}
				if(win7)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen14);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win6=true;
						win7=false;
					}										
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=true;
						win7=false;
					}
				}
			}
			if(Play.levelCleared==3)
			{
				if(win1)
				{
					summaryscreen=false;
					bGameOverScreen=false;
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen15);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=false;
						win7=true;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=false;
						win2=true;
					}
				}
				if(win2)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen16);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=true;
						win2=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win3=true;
						win2=false;
					}
				}
				if(win3)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen17);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win2=true;
						win3=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win4=true;
						win3=false;
					}
				}
				if(win4)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen18);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win3=true;
						win4=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win5=true;
						win4=false;
					}
				}
				if(win5)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen19);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win4=true;
						win5=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win6=true;
						win5=false;
					}
				}
				if(win6)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen20);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win5=true;
						win6=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win7=true;
						win6=false;
					}
				}
				if(win7)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen21);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win6=true;
						win7=false;
					}										
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=true;
						win7=false;
					}
				}
			}
			if(Play.levelCleared==4)
			{
				if(win1)
				{
					summaryscreen=false;
					bGameOverScreen=false;
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen22);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=false;
						win7=true;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=false;
						win2=true;
					}
				}
				if(win2)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen23);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=true;
						win2=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win3=true;
						win2=false;
					}
				}
				if(win3)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen24);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win2=true;
						win3=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win4=true;
						win3=false;
					}
				}
				if(win4)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen25);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win3=true;
						win4=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win5=true;
						win4=false;
					}
				}
				if(win5)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen26);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win4=true;
						win5=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win6=true;
						win5=false;
					}
				}
				if(win6)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen27);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win5=true;
						win6=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win7=true;
						win6=false;
					}
				}
				if(win7)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen28);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win6=true;
						win7=false;
					}										
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=true;
						win7=false;
					}
				}
			}
			if(Play.levelCleared==5)
			{
				if(win1)
				{
					summaryscreen=false;
					bGameOverScreen=false;
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen29);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=false;
						win7=true;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=false;
						win2=true;
					}
				}
				if(win2)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen30);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win1=true;
						win2=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win3=true;
						win2=false;
					}
				}
				if(win3)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen31);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win2=true;
						win3=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win4=true;
						win3=false;
					}
				}
				if(win4)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen32);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win3=true;
						win4=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win5=true;
						win4=false;
					}
				}
				if(win5)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen33);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win4=true;
						win5=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win6=true;
						win5=false;
					}
				}
				if(win6)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen34);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win5=true;
						win6=false;
					}
					
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win7=true;
						win6=false;
					}
				}
				if(win7)
				{
					GUI.Box(new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", investment_screen35);	
					
					if(GUI.Button (new Rect (Screen.width / 9.6f, Screen.height / 2.6f, 75, 150), "", PreviousStyle)){
						win6=true;
						win7=false;
					}										
					if(GUI.Button (new Rect (Screen.width / 1.23f, Screen.height / 2.6f, 75, 150), "", NextStyle)){
						win1=true;
						win7=false;
					}
				}
			}
		/*	if (Play.levelCleared != 5) {
				GUI.skin.box.alignment = TextAnchor.MiddleLeft;
								GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);
								//GUI.Label (new Rect (Screen.width / 10, Screen.height / 1.54f, Screen.width / 3.5f, Screen.height / 15), "Do you want to have " + questionAccordingToLevel (Play.levelCleared) + " ?", ques);
								//	GUI.Label (new Rect (Screen.width / 2, Screen.height / 7, Screen.width / 2.5f, Screen.height / 1.5f), "Mutual Funds improves your financial life...", info);
								GUI.Label (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", info2);	
								//GUI.Box(new Rect(Screen.width/1.75f,Screen.height/12,Screen.width/8,Screen.height/8),"",ans_box);
								GUI.Box (new Rect (190, 305, 300, 230), "<b>Fixed Deposit:</b> A fixed deposit provides\n investors with a higher rate of interest \nthan a regular savings account, until \n the given maturity date.\n\n Put your idle money in a fixed deposit\n and earn attractive returns.", blank);
								if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.65f, Screen.width / 10.0f, Screen.height / 14.0f), "", ans_button_y)) {
										bAnswerScreen = true;
										bPolicyTaken = true;
										bQuestionScreen = false;
										ar_2 = true;

								}
								if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.40f, Screen.width / 10.0f, Screen.height / 14.0f), "", ans_button_n)) {
										
										//bAnswerScreen = false;
										//bPolicyTaken = false;
										//bQuestionScreen = false;
										//ar_2=false;
										bscreen_new = true;
										ResetVariables ();
								}
						} else {
								bAnswerScreen = true;
								bPolicyTaken = false;
								bQuestionScreen = false;
								bscreen_new = true;
								ar_2 = true;
						}

						if (!ar_2) {
								ResetVariables ();
						}
				}*/
															/*else if (bAnswerScreen) {
						if (bPolicyTaken) {
								GUI.skin.box.alignment = TextAnchor.MiddleLeft;
								if (priceAccToLevel (Play.levelCleared) < Play.moneyEarned) {
										ar_2 = true;
										GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);

										GUI.skin.box.alignment = TextAnchor.MiddleCenter;
										//		GUI.Label (new Rect (Screen.width / 2, Screen.height / 7, Screen.width / 2.5f, Screen.height / 1.5f), "Mutual Funds improves your financial life...", info);
										GUI.Label (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", info3);	
										//GUI.Box (new Rect (Screen.width/5, Screen.height/2.2f, Screen.width/2, Screen.height/1.5f), questionAskingPrice (),screen2_new);
										GUI.Box (new Rect (210, 205, 350, 280), "-	Minimum Fixed Deposit amount to be\n invested at ICICI Bank is Rs 10,000\n\n-	Flexibility of tenure is 7 to 10 years\n\n-	Overdraft upto 90% of FD amount possible", blank);			
										if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.78f, Screen.width / 10.0f, Screen.height / 15.0f), priceAccToLevel (Play.levelCleared) + "", amount_button)) {
												bpolicyDetails = true;
												bPolicyTaken = false;
												PlayerPrefs.SetInt ("Level" + Play.levelCleared, priceAccToLevel (Play.levelCleared));
												//ResetVariables();			
										}
										if ((priceAccToLevel (Play.levelCleared) + 3000) < Play.moneyEarned) {
												if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.5f, Screen.width / 10.0f, Screen.height / 15.0f), (priceAccToLevel (Play.levelCleared) + 3000) + "", amount_button)) {
														bpolicyDetails = true;
														bPolicyTaken = false;
														PlayerPrefs.SetInt ("Level" + Play.levelCleared, priceAccToLevel (Play.levelCleared) + 3000);
														//ResetVariables();
												}
										} else {
												GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.5f, Screen.width / 10.0f, Screen.height / 15.0f), (priceAccToLevel (Play.levelCleared) + 3000) + "", amount_button);
										}
										if ((priceAccToLevel (Play.levelCleared) + 6000) < Play.moneyEarned) {
												if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.3f, Screen.width / 10.0f, Screen.height / 15.0f), (priceAccToLevel (Play.levelCleared) + 6000) + "", amount_button)) {
														bpolicyDetails = true;
														bPolicyTaken = false;
														Play.moneyEarned -= priceAccToLevel (Play.levelCleared) + 6000;
														PlayerPrefs.SetInt ("Level" + Play.levelCleared, priceAccToLevel (Play.levelCleared) + 6000);
														//ResetVariables();
												}
										} else {
												GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.3f, Screen.width / 10.0f, Screen.height / 15.0f), (priceAccToLevel (Play.levelCleared) + 6000) + "", amount_button);
										}
								}*/ 
								//else {
								if(Play.moneyEarned<Play.levelCleared)	
									
			{
										//GUI.Label (new Rect (Screen.width / 2, Screen.height / 7, Screen.width / 2.5f, Screen.height / 1.5f), "Mutual Funds improves your financial life...", info);
										//GUI.Label (new Rect (150, Screen.height /8, Screen.width /3, Screen.height / 2), "", info2);	
										GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);
										GUI.Box (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", ans_funds);

																GUI.Label (new Rect (Screen.width * .34f, Screen.height * .47f, Screen.width * .2f, Screen.height * .035f), "Salary Earned in this level"  /*+ "Rupees"*/, after_round_9);
										GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.47f, Screen.width * 0.1f, Screen.height * 0.035f), ":" + moneyEarnedThisSession, after_round_9);
									GUI.Label (new Rect (Screen.width * .34f, Screen.height * .52f, Screen.width * .2f, Screen.height * .035f), "Previous Savings", after_round_9);
									GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.52f, Screen.width * 0.1f, Screen.height * 0.035f), ":" + Play.moneyEarned, after_round_9);			
									GUI.Label (new Rect (Screen.width * .34f, Screen.height * .67f, Screen.width * .2f, Screen.height * .035f), "Home Assets", after_round_9);
										GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.67f, Screen.width * 0.1f, Screen.height * 0.035f), ":0", after_round_9);
									GUI.Label (new Rect (Screen.width * .34f, Screen.height * .718f, Screen.width * .2f, Screen.height * .035f), "Misc. Assets", after_round_9);
									GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.718f, Screen.width * 0.1f, Screen.height * 0.035f), ":0", after_round_9);					
					//GUI.Box (new Rect (150, 200, 100, 100), "Sorry! You dont have sufficient funds to buy the policy .", test);

										if (GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2.4f, Screen.width * 0.12f, Screen.height * 0.08f), "", ans_button_continue)) {
												bscreen_new = true;
												ResetVariables ();
						Application.LoadLevel("Profile");
												//		ar_2=true;
												//	else{ResetVariables();}
										}
								}



						} else if (bpolicyDetails) {
								GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", ans_box);
								GUI.Box (new Rect (120, 30, Screen.width - 240, Screen.height - 60), "", ans_box3);
								//GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "You have bought yourself a " + questionAccordingToLevel (Play.levelCleared) + ". These are the details of your policy.", ans_box3);
								//if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2.5f, Screen.width / 4, Screen.height / 24), "Total Assets  :     " + Play.moneyEarned + " Rupees", ans_button1))
								//		;
								//if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2.0f, Screen.width / 4, Screen.height / 24), "Policy Bought :   " + PlayerPrefs.GetInt ("Level" + Play.levelCleared, 0) + " Rupees", ans_button1))
								//		;
								//if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 1.75f, Screen.width / 4, Screen.height / 24), "Remaining Assets :     " + (Play.moneyEarned - PlayerPrefs.GetInt ("Level" + Play.levelCleared, 0)) + " Rupees", ans_button1))
								//		;
								//PlayerPrefs.SetInt("Money", Play.moneyEarned-PlayerPrefs.GetInt("Level"+Play.levelCleared,0));
								GUI.Box (new Rect (200, Screen.height / 2.9f, Screen.width - 400, Screen.height / 7), "", after_round_6);
								GUI.Label (new Rect (Screen.width * .25f, Screen.height * .47f, Screen.width * .2f, Screen.height * .035f), "Salary Earned in this level :", after_round_9);
								GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.47f, Screen.width * 0.1f, Screen.height * 0.035f), "" + moneyEarnedThisSession, after_round_9);
								GUI.Label (new Rect (Screen.width * .25f, Screen.height * .52f, Screen.width * .2f, Screen.height * .035f), "Previous Savings :", after_round_9);
								GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.52f, Screen.width * 0.1f, Screen.height * 0.035f), "" + Play.moneyEarned, after_round_9);			
								GUI.Box (new Rect (200, Screen.height / 1.9f, Screen.width - 400, Screen.height / 9), "", after_round_7);	
								//GUI.Label (new Rect (Screen.width * .34f, Screen.height * .67f, Screen.width * .2f, Screen.height * .035f), "Home Assets", after_round_9);
								//GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.67f, Screen.width * 0.1f, Screen.height * 0.035f), ": 0", after_round_9);
								//GUI.Label (new Rect (Screen.width * .34f, Screen.height * .718f, Screen.width * .2f, Screen.height * .035f), "Misc. Assets", after_round_9);
							//	GUI.Box (new Rect (Screen.width * 0.62f, Screen.height * 0.718f, Screen.width * 0.1f, Screen.height * 0.035f), ": 0", after_round_9);
								GUI.Box (new Rect (200, Screen.height / 1.45f, Screen.width - 400, Screen.height / 9), "", after_round_8);	
								GUI.Label (new Rect (Screen.width * 0.62f, Screen.height * 0.8f, Screen.width * 0.15f, Screen.height * 0.035f), "" + (Play.moneyEarned + moneyEarnedThisSession) + " INR", after_round_9);
								
				if(Play.levelCleared>=1)
								{
					int i = 0;
					float sum = 0;
					float height = Screen.height * .57f;
					if (Play.levelCleared == 1) {
						GUI.Label (new Rect (Screen.width * .25f, Screen.height * .57f, Screen.width * .2f, Screen.height * .035f), policiesAccordingToLevel (1)+" :",after_round_9);
						//GUI.Label(new Rect(Screen.width * 0.616f, Screen.height * 0.57f, Screen.width * 0.007f, Screen.height * 0.035f), ":",after_round_9);
						GUI.Label(new Rect(Screen.width * 0.62f, Screen.height * 0.57f, Screen.width * 0.1f, Screen.height * 0.035f), "-"+ (moneyEarnedThisSession/2),after_round_13);
					//Play.moneyEarned-=(moneyEarnedThisSession/2);
					//PlayerPrefs.SetInt("Money",PlayerPrefs.GetInt("Money")-(moneyEarnedThisSession/2));
					//Play.moneyEarned=PlayerPrefs.GetInt("Money");
					sum += policiesReturns (1);
						height +=  Screen.height * .044f;
					//bpolicyDetails=false;
					//ResetVariables();
					}
					if (Play.levelCleared ==2) {
						GUI.Label (new Rect (Screen.width * .25f, height, Screen.width * .2f, Screen.height * .035f), policiesAccordingToLevel (2)+" :",after_round_9  );
						//GUI.Label(new Rect(Screen.width * 0.616f, Screen.height * 0.57f, Screen.width * 0.007f, Screen.height * 0.035f), ":",after_round_9);
					//GUI.Label(new Rect(Screen.width * 0.62f, Screen.height * 0.57f, Screen.width * 0.1f, Screen.height * 0.035f), "+"+ (moneyEarnedThisSession/2),after_round_13);
					GUI.Label(new Rect(Screen.width * 0.62f, height, Screen.width * 0.1f, Screen.height * 0.035f),"" +(moneyEarnedThisSession/2),after_round_13);
						sum += policiesReturns (2);
						height += Screen.height * .044f;
					}
					if (Play.levelCleared == 3) {
						GUI.Label (new Rect (Screen.width / 3.2f, height, Screen.width / 3, Screen.height / 24), policiesAccordingToLevel (3) + " : " + policiesReturns (3));
						sum += policiesReturns (3);
						height += Screen.height / 25f;
					}
					if (Play.levelCleared == 4) {
						GUI.Label (new Rect (Screen.width / 3.2f, height, Screen.width / 3, Screen.height / 24), policiesAccordingToLevel (4) + " : " + policiesReturns (4));
						sum += policiesReturns (4);
						height += Screen.height / 25f;
					}
					if (Play.levelCleared == 5) {
						GUI.Label (new Rect (Screen.width / 3.2f, height, Screen.width / 3, Screen.height / 24), policiesAccordingToLevel (5) + " : " + policiesReturns (5));
						sum += policiesReturns (5);
						height += Screen.height / 25f;
					}
					/*if (Play.levelCleared > 6) {
						GUI.Label (new Rect (Screen.width / 3.2f, height, Screen.width / 3, Screen.height / 24), policiesAccordingToLevel (6) + " : " + policiesReturns (6));
						sum += policiesReturns (6);
						height += Screen.height / 25f;
					}*/
								}
								//	GUI.Box (new Rect(),"",test);
								//if((GUI.Button (new Rect (Screen.width / 4f, Screen.height / 1.23f, Screen.width*0.037f, Screen.height *0.034f), "", ans_button_retry2))){}
							
										if (GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2.4f, Screen.width * 0.12f, Screen.height * 0.08f), "", ans_button_retry)) {
												//if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.6f, Screen.width / 4.0f, Screen.height / 4.0f), "", ans_button_next)) {
												PlayerPrefs.SetInt ("Money", Play.moneyEarned - PlayerPrefs.GetInt ("Level" + Play.levelCleared, 0));
												//PlayerPrefs.SetInt("Leve;"+Play.levelCleared
												if(Play.levelCleared==1)
												{		
													ResetVariables ();
													bscreen_new = true;
													Application.LoadLevel("Profile");
												}
												else
												{
													bpolicyDetails=false;
													scenario_screen=true;
												}
										}
					
							
									
		/*	if(Play.levelCleared==1)
			{
		//		GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",ans_box);
		//		GUI.Box(new Rect(120,30, Screen.width-240, Screen.height-60),"",scenario);
		//		if (GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2.4f, Screen.width*0.12f, Screen.height *0.08f), "", ans_button_retry)) {
					//if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.6f, Screen.width / 4.0f, Screen.height / 4.0f), "", ans_button_next)) {
					PlayerPrefs.SetInt ("Money", Play.moneyEarned - PlayerPrefs.GetInt ("Level" + Play.levelCleared, 0));
					//PlayerPrefs.SetInt("Leve;"+Play.levelCleared
					ResetVariables();
					bscreen_new = true;
					
					
		//		}
				
			}*/
			}
			else if(scenario_screen)
		{
				GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",ans_box);
				GUI.Box(new Rect(120,30, Screen.width-240, Screen.height-60),"",scenario);
				if (GUI.Button (new Rect (Screen.width / 1.18f, Screen.height / 2.4f, Screen.width*0.12f, Screen.height *0.08f), "", ans_button_retry)) 
				{
					ResetVariables();
					bscreen_new = true;
					Application.LoadLevel("Profile");
				}

			//else {
							if (Play.levelCleared != 5) {
							}
					/*{
						GUI.Box(new Rect (0,0,Screen.width,Screen.height), continueQuestion()+"",ans_box);
						
					}*/
					else {
										//Play.moneyEarned += PlayerPrefs.GetInt ("Level2", 0) + PlayerPrefs.GetInt ("Level5", 0);
										GUI.Box (new Rect (0, 0, Screen.width, Screen.height / 4), "You have completed the game :). You want to restart the game all over again? Total Money you earned during life was " + Play.moneyEarned);
								}
								if (GUI.Button (new Rect (Screen.width / 12, Screen.height / 3.5f, Screen.width / 8.0f, Screen.height / 24.0f), "Yes")) {

										ResetVariables ();	
										if (Play.levelCleared == 5) {
												PlayerPrefs.SetInt ("LevelCleared", 0);
												PlayerPrefs.SetInt ("Money", 0);
												for (int i =1; i<=6; i++)
														PlayerPrefs.SetInt ("Level" + i, 0);
												Play.levelCleared = 0;
										}

								}
								if (GUI.Button (new Rect (Screen.width / 12, Screen.height / 3.0f, Screen.width / 8.0f, Screen.height / 24.0f), "No")) {
										Application.Quit ();
								}
			}
				/*if (bscreen_new)
				{
					GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",screen_new);
					GUI.Box(new Rect(Screen.width/15,Screen.height/4,Screen.width/2,Screen.height/2),"Hope you have taken the policy otherwise you will lose this game^&%$",screen_new1);
					if(GUI.Button(new Rect(Screen.width/1.7f,Screen.height/1.7f,Screen.height/5,Screen.height/5),"",screen_new2))
					{
						ResetVariables();			
					}
					
				}*/

						
			

						//PlayerPrefs.SetInt("Money",Play.moneyEarned);
				

				

			/*}
		else if(windowID==1)
		{
			Play.bIsPaused=true;
			Debug.Log (windowID);

		}
		else if(windowID==2)
		{
			Play.bIsPaused=true;
			Debug.Log (windowID);
		}*/
		
	
}

	void ResetVariables() // Function used to reset all the flags 
	{

		Play.bIsGameOver=false;
		Play.bIsPaused=false;
		Play.bIsPlaying=true;
		Play.customersSatisfied=0;
		Play.customersReturnedAngry=0;
		Play.score=0;
		Play.multiplier=1;
		Play.timeLeft=Play.timeToPlay;
		Play.moveQueue1=false;
		Play.moveQueue2=false;
		Play.moveQueue3=false;
		Play.moveQueue4=false;
		Play.moveQueue5=false;
		Play.moveQueue6=false;
		Play.bInfraUpgradesValid=false;
		Play.bTechUpgradesValid=false;
		bGameOverScreen=true;
		bQuestionScreen=false;
		bAnswerScreen=false;
		bPolicyTaken=false;
		bAccidentOccured=false;
		Play.bchangeBackGround=true;
		scenario_screen = false;
		summaryscreen=false;
	win1=false;
	win2=false;
	win3=false;
	win4=false;
	win5=false;
	win6=false;
	win7=false;
}
	void sideBar()
	{

		//GUI.Box(new Rect (Screen.width/4+Screen.width/15,Screen.height/7.4f,Screen.width/19f,Screen.height-Screen.height/1.05f), "");
		GUI.Label(new Rect (Screen.width/4+Screen.width/15,Screen.height/3.5f,Screen.width/19f,Screen.height-Screen.height/1.05f), "");
		GUI.Label(new Rect (Screen.width/4+Screen.width/15,Screen.height/2.4f,Screen.width/19f,Screen.height-Screen.height/1.05f), "");
		GUI.Label(new Rect (Screen.width/4+Screen.width/15,Screen.height/1.85f,Screen.width/19f,Screen.height-Screen.height/1.05f), "");
		GUI.Label(new Rect (Screen.width/4+Screen.width/15,Screen.height/1.47f,Screen.width/19f,Screen.height-Screen.height/1.05f), "");


	}
	void infraUpgradre()
	{
		int money=PlayerPrefs.GetInt("Money",0);
		if(money>5000)
		{
			GUI.Box(new Rect (Screen.width/8,Screen.height/3,Screen.width-Screen.width/4,Screen.height-Screen.height/1.3f),"It will increase the frequency of the customers. It costs Rs.5000.Do u want to upgrade?");
			if (GUI.Button(new Rect (Screen.width/2.4f,Screen.height/2.5f,Screen.width-Screen.width/1.2f,Screen.height/12.0f), "Yes"))
			{
				Play.bInfraUpgradesValid=true;
				Play.bIsPaused=false;
				bInfraUpgradeWindow=false;
				PlayerPrefs.SetInt("Money",money-5000);
			}
			if (GUI.Button(new Rect (Screen.width/2.4f,Screen.height/2f,Screen.width-Screen.width/1.2f,Screen.height/24.0f), "No"))
			{
				bInfraUpgradeWindow=false;
				Play.bIsPaused=false;
			}
		}
		else {
			GUI.Box(new Rect (Screen.width/8,Screen.height/3,Screen.width-Screen.width/4,Screen.height-Screen.height/1.3f),"Sorry! Insufficient Funds. You need Rs.5000 for the upgrade.");
			if (GUI.Button(new Rect (Screen.width/2.4f,Screen.height/2f,Screen.width-Screen.width/1.2f,Screen.height/24.0f), "Continue"))
			{
				bInfraUpgradeWindow=false;
				Play.bIsPaused=false;
			}
		}
	}
	void techUpgrade()
	{
				int money = PlayerPrefs.GetInt ("Money", 0);
				if (money > 5000) {
						GUI.Box (new Rect (Screen.width / 8, Screen.height / 3, Screen.width - Screen.width / 4, Screen.height - Screen.height / 1.3f), "It will imporve the swrvicing time for the customers frequency. It costs 5000 coins. Do u want to upgrade?");
						if (GUI.Button (new Rect (Screen.width / 2.4f, Screen.height / 2.5f, Screen.width - Screen.width / 1.2f, Screen.height / 12.0f), "Yes")) {
								Play.bTechUpgradesValid = true;
								Play.bIsPaused = false;
								bTechUpgradeWindow = false;
								PlayerPrefs.SetInt ("Money", money - 5000);
						}
						if (GUI.Button (new Rect (Screen.width / 2.4f, Screen.height / 2f, Screen.width - Screen.width / 1.2f, Screen.height / 24.0f), "No")) {
								Play.bIsPaused = false;
								bTechUpgradeWindow = false;
						}
				} else {
						GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "Sorry! Insufficient Funds. You need Rs.5000 for the upgrade.");
						if (GUI.Button (new Rect (Screen.width / 2.4f, Screen.height / 2f, Screen.width - Screen.width / 1.2f, Screen.height / 24.0f), "Continue")) {
								bTechUpgradeWindow = false;
								Play.bIsPaused = false;
						}
				}
		}
	void bottomBar()
	{
	
		GUI.Box (new Rect (80, 30, 130, 40), "Service Level", test);
		if (Play.customersSatisfied < CustomersGeneration.customersInWave / 4) {

			GUI.Box (new Rect (Screen.width * 0.22f, Screen.height * 0.04f, Screen.width * 0.12f, Screen.height * 0.07f), "", star3);
		}
		if (Play.customersSatisfied >= CustomersGeneration.customersInWave / 4 && Play.customersSatisfied < CustomersGeneration.customersInWave / 2) {

			GUI.Box (new Rect (Screen.width * 0.22f, Screen.height * 0.04f, Screen.width * 0.12f, Screen.height * 0.07f), "", star2);
			y1 = 1;
		}
		if (Play.customersSatisfied >= CustomersGeneration.customersInWave / 2 && x1 != 1 && Play.customersSatisfied < (3 * (CustomersGeneration.customersInWave / 4))) {
			GUI.Box (new Rect (Screen.width * 0.22f, Screen.height * 0.04f, Screen.width * 0.12f, Screen.height * 0.07f), "", star1);
			y2 = 1;
		}
		if (Play.customersSatisfied >= (3 * (CustomersGeneration.customersInWave / 4)) && y1 != 1 && y2 != 1) {
			GUI.Box (new Rect (Screen.width * 0.22f, Screen.height * 0.04f, Screen.width * 0.12f, Screen.height * 0.07f), "", star);
			
		}

		

		GUI.Box (new Rect (Screen.width / 7,Screen.height- (Screen.height / 14.8f), (Screen.width/2.8f), Screen.height / 14), ""); // Box for displaying the no of satisfied customers	
		GUI.Box (new Rect (Screen.width / 6, Screen.height - (Screen.height / 14.8f), Screen.width /10, Screen.height / 14), "Satisfied Customers :" + Play.customersSatisfied);
		GUI.Box (new Rect (Screen.width / 3 + Screen.width / 9, Screen.height - (Screen.height / 14.8f), Screen.width / 20, Screen.height / 14), "Time Left :");
		if (Play.timeLeft>2)
			GUI.Button (new Rect (Screen.width / 3 + Screen.width / 6, Screen.height -( Screen.height / 14.8f), (Screen.width / 2.4f) * ((Play.timeLeft) / Play.timeToPlay), Screen.height / 14), "");
		else
			GUI.Button (new Rect (Screen.width / 3 + Screen.width / 6, Screen.height - (Screen.height / 14.8f), (Screen.width / 2.4f) * ((Play.timeLeft) / Play.timeToPlay), Screen.height / 14), "",timedanger);
		GUI.Box (new Rect (Screen.width / 3 + Screen.width / 9, Screen.height - (Screen.height / 14.8f), Screen.width / 20, Screen.height / 14), "Time Left :");

		/*

		GUI.Box(new Rect (Screen.width/32,Screen.height-Screen.height/20f,Screen.width-Screen.width/16.0f,Screen.height/20), ""); // Box for displaying the no of satisfied customers	
		if(GUI.Button (new Rect(Screen.width/2-Screen.width/2.2f,Screen.height-Screen.height/20f,Screen.width/6.0f,Screen.height/20),"Infra Upgrades"))
		{
			Debug.Log ("Infra Upgrades Wanted");
			Play.bIsPaused=true;
			bInfraUpgradeWindow=true;

			//Window(1);
		}
		if(GUI.Button (new Rect(Screen.width/2-Screen.width/2.2f +Screen.width/6f,Screen.height-Screen.height/20f,Screen.width/6.0f,Screen.height/20),"Tech Upgrades" ))
		{
			Debug.Log ("Tech Upgrades Wanted");
			Play.bIsPaused=true;
			bTechUpgradeWindow=true;
			//Window(2);
			/*if(Play.bTechUpgrades2Valid)
			{
				Play.bTechUpgrades1Valid=false;
				Play.bTechUpgrades3Valid=true;
				Play.bTechUpgrades2Valid=false;
			}
			else if( Play.bTechUpgrades1Valid)
			{
				Play.bTechUpgrades1Valid=false;
				Play.bTechUpgrades3Valid=false;
				Play.bTechUpgrades2Valid=true;
			}
			else
			{
				Play.bTechUpgrades1Valid=true;
			}
		}

		GUI.Box (new Rect(Screen.width/2-Screen.width/2.2f +Screen.width/3 ,Screen.height-Screen.height/20f,Screen.width/5.0f,Screen.height/20),"Satisfied Customers :" + Play.customersSatisfied );
		//BoxStyle.normal.background=BoxColor;
		
		GUI.Box (new Rect(Screen.width/2-Screen.width/2.2f +Screen.width/3+ Screen.width/5,Screen.height-Screen.height/20f,Screen.width/2.55f,Screen.height/20),"Time Left");
		if(Play.timeLeft>=0)
			GUI.Box (new Rect(Screen.width/2-Screen.width/2.2f +Screen.width/3+ Screen.width/5,Screen.height-Screen.height/20f,(Screen.width/2.55f)*((Play.timeLeft)/Play.timeToPlay),Screen.height/20),"" );
		GUI.Box (new Rect(Screen.width/2-Screen.width/2.2f +Screen.width/3+ Screen.width/5,Screen.height-Screen.height/20f,Screen.width/2.55f,Screen.height/20),"Time Left");

*/

	}

	void DestroyGameObjects()   // Function used to destroy all the customers in the scene to restart again.
	{	//GameobjectsGameObject.FindGameObjectWithTag("Customer")
		GameObject[] gos;     // Array of gameobjects.
		gos = GameObject.FindGameObjectsWithTag("Customer"); // Find all the gameobjects in the scene and store it in the array.
		for (int  i =0; i<gos.Length ;i++)
		{
			Destroy(gos[i]);								// Destroy the gameobject at i th position
		}

	}
	void pauseFunctionality()
	{

		if(!Play.bIsPaused)	// If the game is not paused
		{
			if(GUI.Button(new Rect(Screen.width/1.35f,10,Screen.width/10,Screen.width/10),"",pause_button) ) // Button to set the flag for pause
			{
				Play.bIsPaused=true;
			}


		}
		else  // if the game is paused
		{
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", PauseBoxStyle);
			if(Play.levelCleared==0)
			{
			GUI.Box(new Rect(120, 30, Screen.width - 240, Screen.height - 60), "", Pausepopup);
			}
			if(Play.levelCleared==1)
			{
				GUI.Box(new Rect(120, 30, Screen.width - 240, Screen.height - 60), "", Pausepopup1);
			}
			if(Play.levelCleared==2)
			{
				GUI.Box(new Rect(120, 30, Screen.width - 240, Screen.height - 60), "", Pausepopup2);
			}
			if(Play.levelCleared==3)
			{
				GUI.Box(new Rect(120, 30, Screen.width - 240, Screen.height - 60), "", Pausepopup3);
			}
			if(Play.levelCleared==4)
			{
				GUI.Box(new Rect(120, 30, Screen.width - 240, Screen.height - 60), "", Pausepopup4);
			}

			if ((GUI.Button (new Rect (650, Screen.height / 2.5f, Screen.width * 0.12f, Screen.height * 0.08f), "", ans_button_retry2))) {
				//Play.levelCleared--;
				
				ResetVariables ();
				Application.LoadLevel("Profile");
			}
			if(GUI.Button(new Rect(650, Screen.height / 2f, Screen.width * 0.12f, Screen.height * 0.08f),"",resumeButton)) // Button to reset the flag for pause
			{	
				Play.bIsPaused=false;
				//GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", PauseBoxStyle);
			}
			if(GUI.Button(new Rect(650, Screen.height / 1.66f, Screen.width * 0.12f, Screen.height * 0.08f),"",exit_button)) // Button to reset the flag for pause
			{	
				//Play.bIsPaused=false;
				//GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", PauseBoxStyle);
				Application.Quit();
			}
		}
	}
	string continueQuestion()
	{
		return "Are you ready to move to the next level.Hope you continue your good work the next years ";
	}
	string questionAskingPrice()
	{
		return "How much would you like to deposit? ";
	}

	string questionAccordingToLevel(int levelCleared)
	{
		switch(levelCleared)
		{
		case 1: return "Fixed Deposit";
		case 2: return "Recurring Deposit";
		case 3: return "iWish";
		case 4: return "Mutual Funds";
		case 5: return "Child Education Fund";
		case 6: return "Pure Gold";
		default : return "End of Game";
				break;
		}

	}
	string policiesAccordingToLevel(int levelCleared)
	{
		switch(levelCleared)
		{
		case 1: return "Fixed Deposit";
		case 2: return "Recurring Deposit";
		case 3: return "iWish";
		case 4: return "Mutual Funds";
		case 5: return "Child Education Fund";
		case 6: return "Pure Gold";
		default : return "End of Game";
			break;
		}
		
	}
	int  priceAccToLevel(int levelCleared)
	{
		switch(levelCleared)
		{
		case 1: return 2000;
		case 2: return 3000;
		case 3: return 4000;
		case 4: return 5000;
		case 5: return 6000;
		case 6: return 7000;
		default : return 0;
			break;
		}
		
	}
	float policiesReturns(int levelCleared)
	{
		float returns=0;
		if(levelCleared==1)
		{
			returns= 0.95f*moneyEarnedThisSession;
		}
		else if(levelCleared==2)
		{
			returns= -.02f * PlayerPrefs.GetInt("Level"+levelCleared,0);
		}
		else if (levelCleared==3)
		{
			returns= .020f * PlayerPrefs.GetInt("Level"+levelCleared,0);
		}
		else if (levelCleared==4)
		{
			returns =0.030f * PlayerPrefs.GetInt("Level"+levelCleared,0);
		}
		else if (levelCleared==5)
		{
			returns= 0.05f * PlayerPrefs.GetInt("Level"+levelCleared,0);
		}
		else if (levelCleared==6)
		{
			returns= -0.03f * PlayerPrefs.GetInt("Level"+levelCleared,0);

		}
		return returns;
	}
	void accidentOccured()
	{	int policyMoney=PlayerPrefs.GetInt("Money",0);
		int i =Random.Range(0,100);
		if(i<5)
		{

			bAccidentOccured=true;
			if(policyMoney==0)
			{

				accidentDeduction=5000;
			}
			else if( policyMoney==5000)
			{

				accidentDeduction=Mathf.FloorToInt(0.25f * policyMoney);
			}
			else if( policyMoney==8000)
			{

				accidentDeduction=Mathf.FloorToInt(0.10f * policyMoney);
			}
			else
			{

				accidentDeduction=0;
			}

		}
		else if( i <10)
		{
			bAccidentOccured=true;	
			if(policyMoney==0)
			{

				accidentDeduction=7000;
			}
			else if( policyMoney==5000)
			{

				accidentDeduction=Mathf.FloorToInt(0.25f * policyMoney);
			}
			else 
			{

				accidentDeduction=0;
			}

		}
		else if (i<15)
		{
			bAccidentOccured=true;
			bAccidentOccured=true;	
			if(policyMoney==0)
			{

				accidentDeduction=5000;
			}
			else 
			{

				accidentDeduction=0;
			}
		}
		else
		{
			bAccidentOccured=false;
		}
		moneyEarnedThisSession-=accidentDeduction;
		if(moneyEarnedThisSession<0)
			moneyEarnedThisSession=0;





	}
}


