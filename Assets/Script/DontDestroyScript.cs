using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour {

	private static bool created =false;
	// Use this for initialization
	void Start () {
		if (!created) {
			DontDestroyOnLoad (this);
			created = true;
		} else {
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
