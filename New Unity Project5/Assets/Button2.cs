using UnityEngine;
using System.Collections;
using Meta; 

public class Button2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerClick() {
		GlobalVars.GlobalVariable = "case1";
		Debug.Log (GlobalVars.GlobalVariable);
	}
}
