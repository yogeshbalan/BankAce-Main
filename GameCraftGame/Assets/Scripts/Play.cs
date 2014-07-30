using UnityEngine;
using System.Collections;

// This script is not applied anywhere . It just holds the static flags to control the flow in the game.

public class Play : MonoBehaviour {


	public static bool bIsGameOver=false;
	public static bool bIsPaused=false;
	public static bool bIsPlaying=false;
	public static int customersSatisfied=0;
	public static int customersReturnedAngry=0;
	public static float score=0;
	public static int multiplier=1;
	public static int timeToPlay=40;
	public static float timeLeft=timeToPlay;
	public static int g_int_MoneyLeft=Mathf.FloorToInt(timeLeft * 5000.0f/60.0f);
	public static bool moveQueue1=false;
	public static bool moveQueue2=false;
	public static bool moveQueue3=false;
	public static bool moveQueue4=false;
	public static bool moveQueue5=false;
	public static bool moveQueue6=false;
	public static int moneyEarned=500000;//PlayerPrefs.GetInt("Money",0);
	public static int levelCleared=0;//PlayerPrefs.GetInt("LevelCleared",0);
	public static bool bTechUpgrades1Valid=false;
	public static bool bTechUpgrades2Valid=false;
	public static bool bTechUpgrades3Valid=false;
	public static bool bInfraUpgradesValid=false;
	public static bool bTechUpgradesValid=false;
	public static bool bchangeBackGround=true;
	public static bool bEmployeeChange=false;

	// Use this for initialization
	void Start () {
		bIsGameOver=false;
		bIsPaused=false;
		score=0;
		customersSatisfied=0;
		customersReturnedAngry=0;
		score=0;
		multiplier=1;
	}

	public void retrylevel()
	{
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}