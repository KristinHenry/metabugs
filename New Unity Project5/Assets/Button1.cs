using UnityEngine;
using System.Collections;
using Meta; 

public class Button1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerClick() {
		GlobalVars.GlobalVariable = "normal";
		Debug.Log (GlobalVars.GlobalVariable);
	}
}
