using UnityEngine;
using System.Collections;
using Meta; 

public class Button3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerClick() {
		GlobalVars.GlobalVariable = "case2";
		Debug.Log (GlobalVars.GlobalVariable);
	}
}
