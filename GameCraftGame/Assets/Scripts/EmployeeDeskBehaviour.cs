using UnityEngine;
using System.Collections;

public class EmployeeDeskBehaviour : MonoBehaviour {

	public GameObject oNormalEmployee;
	// Use this for initialization
	void Start () {
		Instantiate(oNormalEmployee,transform.position,Quaternion.Euler(0,-90,0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
