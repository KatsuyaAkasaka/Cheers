using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParameterScript : MonoBehaviour {

	public static int score = 0, yoi = 0;
	public bool isBar = false;
	public GameObject sakayaBack, barBack;
	private int movingTime = 60;

	//public Text lightButtonText, midButtonText, powButtonText;

	void Awake(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene s, LoadSceneMode ls){
		//酔いとスコアリセット
		if (SceneManager.GetActiveScene ().name == "GameStart") {
			yoi = 0;
			score = 0;
		} else {
			Text scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
			Slider slider = GameObject.Find ("Slider").GetComponent<Slider>();
			slider.maxValue = 300;
			scoreText.text = score.ToString();
			slider.value = yoi;
			Debug.Log (yoi);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public void ScoreUp(){
		Text scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		Slider slider = GameObject.Find ("Slider").GetComponent<Slider>();
		JugScript js = GameObject.Find ("GameController").GetComponent<JugScript> ();

		slider.maxValue = 300;
		yoi += js.param;
		score += js.param;
		scoreText.text = score.ToString();
		slider.GetComponent<SliderScript> ().change = js.param;
	}

	//背景を居酒屋にチェンジ
	public void ChangeSakaya(){
		isBar = false;

		GameObject.Find ("clock").SendMessage ("PassTime", movingTime);
		//背景変更
		sakayaBack.SetActive (true);
		barBack.SetActive (false);
		//slider減少
		Slider slider = GameObject.Find ("Slider").GetComponent<Slider> ();
		yoi -= 25;
		slider.GetComponent<SliderScript> ().change = -25;
		if (slider.GetComponent<SliderScript> ().finish) {
			SceneManager.LoadScene ("main");
		}
	}

	//背景をバーにチェンジ
	public void ChangeBar(){
		isBar = true;

		GameObject.Find ("clock").SendMessage ("PassTime", movingTime);
		//背景変更
		sakayaBack.SetActive (false);
		barBack.SetActive (true);
		//sliderを減少
		Slider slider = GameObject.Find ("Slider").GetComponent<Slider> ();
		yoi -= 25;
		slider.GetComponent<SliderScript> ().change = -25;
		if (slider.GetComponent<SliderScript> ().finish) {
			SceneManager.LoadScene ("main");
		}

	}
}
