using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	ParameterScript ps;
	// Use this for initialization
	void Start () {
		ps = GameObject.Find ("DontDestroy").GetComponent<ParameterScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("main");
		}
	}
}
