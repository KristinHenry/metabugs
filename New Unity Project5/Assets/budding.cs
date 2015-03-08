using UnityEngine;
using System.Collections;


public class budding : MonoBehaviour {

	private Vector3 collisionPoint;

	float pause; 
	float maxSize; 
	float minSize = 0.1f;
	float growthRate;
	float shrinkRate = 0.1f;
	float scale = 0.0f;
	float life = 0.0f;
	float lifeSpan;

	public Color[] colors = new Color[15];
	int colorIndex;

	int hits = 0;
	int hitMax = 4;
	
	int bugIndex;
	public string bugType;

	//string GlobalVar = GlobalVars.GlobalVariable ;

	// ******************************
	string treatment = "case1"; //"normal";
	//************************************



	// Use this for initialization
	void Start () {

		//treatment = "normal";

		pause = Random.Range(1.0f, 20.0f);
		maxSize = Random.Range(1.0f, 1.4f);
		lifeSpan = Random.Range(30.0f, 200.0f);
		growthRate = Random.Range (0.01f, 0.8f);

		Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
		gameObject.transform.position = position;

		transform.localScale = Vector3.one * scale;

		colorIndex =  Mathf.FloorToInt(   Random.Range (0.0f, 10.0f) );

		setBugType ();  // now dependant on colorIndex
	
	}
	
	// Update is called once per frame
	void Update () {
		treatment = GlobalVars.GlobalVariable;
		gameObject.GetComponent<MeshRenderer> ().material.color = colors [colorIndex];

		if (pause >= 0.0f) {
			pause -= 0.1f;
		} else {

			life = life + 0.1f;

			if (life < lifeSpan) {
				Grow();
			} else {
				Shrink ();
			}
		}

		/*
		if (Input.GetKeyDown (KeyCode.G)) {
			// move a little bit
			int i = Mathf.FloorToInt(Random.Range (0.0f, 2.0f));
			if(i == 0){
				treatment = "normal";
			} else if(i == 1){
				treatment = "case1";
			} else if(i == 2){
				treatment = "case2";
			} else if(i == 3){
				treatment = "case3";
			} else if(i == 4){
				treatment = "case4";
			} 

			print ("*******************");
			print (treatment);
		}*/

	}


	void setBugType(){
		bugIndex = colorIndex;//Mathf.FloorToInt (Random.Range (0.0f, 4.0f));
		//bugType = bugTypes[bugTypeIndex];
		if (bugIndex == 0) {
			bugType = "bug1";
		} else if (bugIndex == 1) {
			bugType = "bug2";
		} else if (bugIndex == 2) {
			bugType = "bug3";
		} else if (bugIndex == 3){
			bugType = "bug4";	
		} 
		else if (bugIndex == 4){
			bugType = "bug5";	
		}
		else if (bugIndex == 5){
			bugType = "bug6";	
		}else {
			bugType = "other";
		}
	}

	void Grow(){
		if (scale < maxSize) {
			transform.localScale = Vector3.one * scale;
			scale += growthRate * Time.deltaTime;
		}
	}
	
	void Shrink(){
		if (scale > minSize) {
			transform.localScale = Vector3.one * scale;
			scale -= shrinkRate * Time.deltaTime;
		} else {
			Destroy (gameObject);
		}
	}
		
		
	void OnCollisionEnter(Collision collision) {
		print (collision.gameObject.name);

		budding buddingComponent;
		buddingComponent = collision.gameObject.GetComponent<budding> ();
		string otherType = buddingComponent.bugType;
		string thisType = bugType;

		hits += 1;
		if(hits > hitMax){
			lifeSpan = life;
		} 

		if (treatment == "normal") {
			if (otherType == thisType) {
				lifeSpan = life;
			}
		} else if (treatment == "case1") {
			if(otherType == "bug1"){
				hits = 0;
				lifeSpan += 100;
				colorIndex = buddingComponent.colorIndex;
				bugType = otherType;
			}
		} else if (treatment == "case2") {
			if(otherType == "bug2"){
				hits = 0;
				lifeSpan += 100;
				colorIndex = buddingComponent.colorIndex;
				bugType = otherType;
			}
		} else if (treatment == "case3") {
			if(otherType == "bug3"){
				hits = 0;
				lifeSpan += 100;
				colorIndex = buddingComponent.colorIndex;
				bugType = otherType;
			}
		} 

		
	}


}

