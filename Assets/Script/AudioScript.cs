using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour {

	public AudioClip click, izakaya, bar, countDown, clear, pour;

	public AudioSource[] audioSource = new AudioSource[2];
	private ParameterScript ps;
	private JugScript js;
	private TimerScript ts;

	private bool isStartScene = false;

	private bool called0 = false, called1 = false, called2 = false;
	public bool called3 = false;


	void Awake(){
		SceneManager.sceneLoaded += OnSceneLoaded;

	}

	public void OnSceneLoaded(Scene s, LoadSceneMode ls){
		if (s.name == "GameStart") {
			isStartScene = true;
		}
		else {
			js = GameObject.Find ("GameController").GetComponent<JugScript> ();
			isStartScene = false;
			ts = GameObject.Find ("TimerText").GetComponent<TimerScript> ();
		}
		called0 = false;
		called1 = false;
		called2 = false;

	}


	//audioSource[0]	BGM
	//			[1]		効果音


	// Use this for initialization
	void Start () {
		ps = GetComponent<ParameterScript> ();
		start (0, izakaya);

		audioSource[0].loop = true;
		audioSource [1].loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isStartScene && js.finished && !called0) {
			start (1, countDown);
			called0 = true;
		} else if (!isStartScene && ts.gameFinish && !called2) {
			start (1, clear);
			called2 = true;
		} 
		if (!isStartScene && ps.isBar && !called3) {
			start (0, bar);
			called3 = true;
		} else if(!isStartScene && !ps.isBar && !called3){
			start (0, izakaya);
			called3 = true;	
		}

	}

	public void start(int i, AudioClip ac){
		audioSource [i].clip = ac;
		audioSource [i].Play ();
	}

	public void clickAudio(){
		start (1, click);
	}

	public void pourAudio(){
		start (1, pour);
	}
}
