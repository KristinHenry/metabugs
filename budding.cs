using UnityEngine;
using System.Collections;

public class budding : MonoBehaviour {

	private Vector3 collisionPoint;

	float pause; // = Random.Range(1.0f, 20.0f);
	float maxSize; // = Random.Range(1.0f, 1.4f);
	float minSize = 0.1f;
	float growthRate;// = Random.Range (0.01f, 0.8f);
	float shrinkRate = 0.1f;
	float scale = 0.0f;
	float life = 0.0f;
	float lifeSpan;// = Random.Range(30.0f, 200.0f);

	public Color[] colors = new Color[15];
	int colorIndex;
	int hits = 0;
	int hitMax = 4;

	public string bugType = "bug1";




	// Use this for initialization
	void Start () {

		pause = Random.Range(1.0f, 20.0f);
		maxSize = Random.Range(1.0f, 1.4f);
		lifeSpan = Random.Range(30.0f, 200.0f);
		growthRate = Random.Range (0.01f, 0.8f);

		Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
		gameObject.transform.position = position;

		transform.localScale = Vector3.one * scale;

		//gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
		colorIndex =  Mathf.FloorToInt(   Random.Range (0.0f, 10.0f) );
	
	}
	
	// Update is called once per frame
	void Update () {

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


		if (Input.GetKeyDown (KeyCode.G)) {
			// move a little bit
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
		//print (collision.gameObject.bugType);
		budding buddingComponent;
		buddingComponent = collision.gameObject.GetComponent<budding> ();
		print (buddingComponent.bugType);

		foreach (ContactPoint contact in collision.contacts) {
			print(contact.point);
			hits += 1;
			if(hits > hitMax){
				Destroy (gameObject);
			}
		}

	}

}

