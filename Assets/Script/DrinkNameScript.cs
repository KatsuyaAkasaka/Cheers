using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkNameScript : MonoBehaviour {

	private GameObject DontDestroy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroy = GameObject.Find ("DontDestroy");
		if (DontDestroy.GetComponent<ParameterScript> ().isBar) {
			if (name == "LightButton") {
				GetComponentInChildren<Text> ().text = "ワイン";
			} else if (name == "MidButton") {
				GetComponentInChildren<Text> ().text = "ウイスキー";

			} else {
				GetComponentInChildren<Text> ().text = "テキーラ";

			}
		} else {
			if (name == "LightButton") {
				GetComponentInChildren<Text> ().text = "ビール";

			} else if (name == "MidButton") {
				GetComponentInChildren<Text> ().text = "ハイボール";
			} else {
				GetComponentInChildren<Text> ().text = "焼酎";
			}
		}

	}
}
