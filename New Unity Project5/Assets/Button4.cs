using UnityEngine;
using System.Collections;
using Meta; 

public class Button4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerClick() {
		GlobalVars.GlobalVariable = "case3";
		Debug.Log (GlobalVars.GlobalVariable);
	}
}
