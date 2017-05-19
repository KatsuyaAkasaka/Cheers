using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	private JugScript js;
	private TimerScript ts;
	private PlayerScript ps;
	private Clock clock;
	private bool called = false;

	public bool isBar = false;

	private bool calledOnce1 = false;
	private bool calledOnce2 = false;
	private bool calledOnce3 = false;
	private bool calledOnce4 = false;

	public GameObject lightButton;
	public GameObject midButton;
	public GameObject powButton;

	public GameObject waterButton;

	public GameObject nextStoreButton;
	public GameObject nextBeerButton;

	public GameObject izakayaButton;
	public GameObject barButton;
	public GameObject returnButton;

	public GameObject backToStartButton;

	private AudioScript audioScript;


	// Use this for initialization
	void Start () {
		js = GetComponent<JugScript>();
		ts = GameObject.Find ("TimerText").GetComponent<TimerScript> ();
		ps = GetComponent<PlayerScript> ();
		isBar = GameObject.Find ("DontDestroy").GetComponent<ParameterScript> ().isBar;
		backToStartButton.SetActive (false);

		clock = GameObject.Find ("DontDestroy").GetComponentInChildren<Clock> ();

		audioScript = GameObject.Find("DontDestroy").GetComponent<AudioScript>();
	}
	
	// Update is called once per frame
	void Update () {

		//ドリンク選択中は
		if (!js.finished && !calledOnce1) {
			NextButton (false);
			StoreButton (false);
			DrinkButton (true);
			calledOnce1 = true;
		}

		//選択が終わったら
		if(js.finished && !calledOnce2) {
			NextButton(false);
			DrinkButton (false);
			StoreButton (false);
			calledOnce2 = true;
		}

		//もしゲームが終了したら
		if (ts.gameFinish && !calledOnce3) {
			NextButton (true);
			DrinkButton (false);
			StoreButton (false);
			calledOnce3 = true;
		}
		if ((ps.gameOver && !calledOnce4) || (clock.gameClear && !calledOnce4)) {
			backToStartButton.SetActive (true);
			NextButton (false);
			DrinkButton (false);
			StoreButton (false);
			calledOnce4 = true;
		}
			
	}

	public void DrinkButton(bool b){
		lightButton.SetActive (b);
		midButton.SetActive (b);
		powButton.SetActive (b);
		waterButton.SetActive (b);
	}
	public void NextButton(bool b){
		nextBeerButton.SetActive (b);
		nextStoreButton.SetActive (b);
	}

	public void StoreButton(bool b){
		izakayaButton.SetActive (b);
		barButton.SetActive (b);
		returnButton.SetActive (b);
	}



	public void OnClickLight(){

		//居酒屋	ビール,ハイボール,にほんしゅ		8,15,25
		//バー	ワイン,ウイスキー,テキーラ	12,35,40

		if (!called && !clock.gameClear) {
			if (!isBar) {
				js.state = 0;
			} else {
				js.state = 3;
			}
			audioScript.SendMessage ("clickAudio");
			called = true;
		}
	}

	public void OnClickMid(){
		if (!called && !clock.gameClear) {
			if (!isBar) {
				js.state = 1;
			} else {
				js.state = 4;
			}
			audioScript.SendMessage ("clickAudio");

			called = true;
		}
	}

	public void OnClickPow(){
		if (!called && !clock.gameClear) {
			if (!isBar) {
				js.state = 2;
			} else {
				js.state = 5;
			}
			audioScript.SendMessage ("clickAudio");

			called = true;
		}
	}

	public void OnClickWater(){
		if (!called && !clock.gameClear) {
			js.state = 6;
			audioScript.SendMessage ("clickAudio");
			called = true;
		}	
	}

	public void OnClickNextBeer(){
		if(!clock.gameClear){
			SceneManager.LoadScene ("main");
		}
	}

	public void OnClickNextStore(){
		if (!clock.gameClear) {
			StoreButton (true);
			DrinkButton (false);
			NextButton (false);
			audioScript.SendMessage ("clickAudio");

		}
	}

	public void OnClickReturn(){
		if (!clock.gameClear) {
			NextButton (true);
			DrinkButton (false);
			StoreButton (false);
			audioScript.SendMessage ("clickAudio");

		}
	}

	public void OnClickSakaya(){
		if (!clock.gameClear) {
			audioScript.SendMessage ("clickAudio");

			GameObject.Find ("DontDestroy").SendMessage ("ChangeSakaya");

		}
	}

	public void OnClickBar(){
		if (!clock.gameClear) {
			audioScript.SendMessage ("clickAudio");

			GameObject.Find ("DontDestroy").SendMessage ("ChangeBar");

		}
	}

	public void OnClickBack(){
		audioScript.SendMessage ("clickAudio");
		clock.SendMessage ("OnClickReturn");
		SceneManager.LoadScene ("GameStart");
	}
}
