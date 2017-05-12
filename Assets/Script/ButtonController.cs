using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	private JugScript js;
	private TimerScript ts;
	private bool called = false;

	public GameObject lightButton;
	public GameObject midButton;
	public GameObject powButton;

	public GameObject nextStoreButton;
	public GameObject nextBeerButton;

	public GameObject izakayaButton;
	public GameObject barButton;


	// Use this for initialization
	void Start () {
		js = GetComponent<JugScript>();
		ts = GameObject.Find ("TimerText").GetComponent<TimerScript> ();
	}
	
	// Update is called once per frame
	void Update () {

		//ドリンク選択中は
		if (!js.finished) {
			NextButton (false);
			StoreButton (false);
			DrinkButton (true);
		} else {
			//選択が終わったら
			NextButton(false);
			DrinkButton (false);
			StoreButton (false);
		}

		//もしゲームが終了したら
		if (ts.gameFinish) {
			NextButton (true);
			DrinkButton (false);
			StoreButton (false);
		}
			
	}

	public void DrinkButton(bool b){
		lightButton.SetActive (b);
		midButton.SetActive (b);
		powButton.SetActive (b);
	}
	public void NextButton(bool b){
		nextBeerButton.SetActive (b);
		nextStoreButton.SetActive (b);
	}

	public void StoreButton(bool b){
		izakayaButton.SetActive (b);
		barButton.SetActive (b);
	}



	public void OnClickBeer(){
		if (!called) {
			js.state = 1;
			called = true;
		}
	}

	public void OnClickOrange(){
		if (!called) {
			js.state = 2;
			called = true;
		}
	}

	public void OnClickWine(){
		if (!called) {
			js.state = 3;
			called = true;
		}
	}

	public void onClickNextBeer(){
		SceneManager.LoadScene ("main");
	}

	public void onClickNextStore(){
		StoreButton (true);
	}
}
