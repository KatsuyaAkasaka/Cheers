using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	private JugScript js;
	private TimerScript ts;
	private PlayerScript ps;
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


	// Use this for initialization
	void Start () {
		js = GetComponent<JugScript>();
		ts = GameObject.Find ("TimerText").GetComponent<TimerScript> ();
		ps = GetComponent<PlayerScript> ();
		isBar = GameObject.Find ("DontDestroy").GetComponent<ParameterScript> ().isBar;
		backToStartButton.SetActive (false);


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
		if (ps.gameOver && !calledOnce4) {
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

		if (!called) {
			if (!isBar) {
				js.state = 0;
			} else {
				js.state = 3;
			}
			called = true;
		}
	}

	public void OnClickMid(){
		if (!called) {
			if (!isBar) {
				js.state = 1;
			} else {
				js.state = 4;
			}
			called = true;
		}
	}

	public void OnClickPow(){
		if (!called) {
			if (!isBar) {
				js.state = 2;
			} else {
				js.state = 5;
			}
			called = true;
		}
	}

	public void OnClickWater(){
		if (!called) {
			js.state = 6;
		}	
	}

	public void OnClickNextBeer(){
		SceneManager.LoadScene ("main");
	}

	public void OnClickNextStore(){
		StoreButton (true);
		DrinkButton (false);
		NextButton (false);
	}

	public void OnClickReturn(){
		NextButton (true);
		DrinkButton (false);
		StoreButton (false);
	}

	public void OnClickSakaya(){
		GameObject.Find ("DontDestroy").SendMessage ("ChangeSakaya");
	}

	public void OnClickBar(){
		GameObject.Find("DontDestroy").SendMessage ("ChangeBar");
	}

	public void OnClickBack(){
		SceneManager.LoadScene ("GameStart");
	}
}
