using UnityEngine;
using System.Collections;

public class initBugs : MonoBehaviour {

	public GameObject bugPrefab;
	//GameObject cube;
	int maxbugs = 200;

	// Use this for initialization
	void Start () {
		//cube = GameObject.Find("Cube");	
	}
	
	// Update is called once per frame
	void Update () {

		Instantiate (bugPrefab);

		/*
		if (Input.GetKeyDown (KeyCode.B)) {
			//cube.GetComponent<MeshRenderer>().material.color = Color.blue;
			for(int i=0; i<maxbugs; i++){
				Instantiate(bugPrefab);
			}

		}
		*/
	
	}


	
	
}
