using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrameterScript : MonoBehaviour {

	public static int score = 0;


	// Use this for initialization
	void Start () {

		Text scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		Slider slider = GameObject.Find ("Slider").GetComponent<Slider>();

		slider.maxValue = 50;
		scoreText.text = "score: " + score;
		slider.value = score;


	}

	public void OnClickChangeButton(){
		Slider slider = GameObject.Find ("Slider").GetComponent<Slider>();
		slider.value -= 25;
	}

	public void ScoreUp(){

		Text scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		Slider slider = GameObject.Find ("Slider").GetComponent<Slider>();
		JugScript js = GameObject.Find ("GameController").GetComponent<JugScript> ();
		slider.maxValue = 50;

		slider.value += js.param;
		score += js.param;
		scoreText.text = "score: " + score;
	}
}
