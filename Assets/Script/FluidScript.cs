using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidScript : MonoBehaviour {

	private float x;
	private float y;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5f) {
			GameObject.Find ("GameController").GetComponent<PlayerScript> ().score++;
			Destroy (this.gameObject);
		}
	}
		
}
