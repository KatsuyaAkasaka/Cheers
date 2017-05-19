using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyScript : MonoBehaviour {

	private static bool created =false;
	public GameObject clock;
	// Use this for initialization

	void Awake(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene s, LoadSceneMode ls){
		if (SceneManager.GetActiveScene ().name == "GameStart") {
			clock.SetActive(false);
		} else {
			clock.SetActive (true);
		}
	}


	void Start () {
		if (!created) {
			DontDestroyOnLoad (this);
			created = true;
		} else {
			Destroy (this.gameObject);
		}
	}
}
