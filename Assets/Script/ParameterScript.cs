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
	int highScore;
	private bool highFinish = false;

	private PlayerScript ps;

	private GameObject highScoreText;

	private AudioScript audioS;

	private bool isStartScene = true;
	//public Text lightButtonText, midButtonText, powButtonText;

	void Awake(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
		

	void OnSceneLoaded(Scene s, LoadSceneMode ls){
		//酔いとスコアリセット
		if (SceneManager.GetActiveScene ().name == "GameStart") {
			yoi = 0;
			score = 0;
			isStartScene = true;
			highFinish = false;
		} else {
			Text scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
			Slider slider = GameObject.Find ("Slider").GetComponent<Slider>();
			slider.maxValue = 200;
			scoreText.text = score.ToString();
			slider.value = yoi;
			ps = GameObject.Find ("GameController").GetComponent<PlayerScript> ();
			highScoreText = GameObject.Find ("HighScoreText");

			isStartScene = false;

		}
	}

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("highScoreKey", 0);
		audioS = GetComponent<AudioScript> ();
	}
		
	void Update(){
		if (!isStartScene) {
			if ((GetComponentInChildren<Clock> ().gameClear || ps.gameOver) && !highFinish) {
				if (highScore < score) {
					PlayerPrefs.SetInt ("highScoreKey", score);
					highScoreText.GetComponent<Text> ().text =
					"ハイスコア\n" + PlayerPrefs.GetInt ("highScoreKey");
					GameObject.Find ("ClearText").GetComponent<Text> ().text = "";
				}
				highFinish = true;
			}
		}
	}
		
	public void ScoreUp(){
		Text scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		Slider slider = GameObject.Find ("Slider").GetComponent<Slider>();
		JugScript js = GameObject.Find ("GameController").GetComponent<JugScript> ();

		slider.maxValue = 200;
		yoi += js.param;
		if (yoi <= 0) {
			yoi = 0;
		}
		if (js.param >= 0) {
			score += js.param;
		}
		if (score <= 0) {
			score = 0;
		}
		scoreText.text = score.ToString ();

		slider.GetComponent<SliderScript> ().change = js.param;
	}

	//背景を居酒屋にチェンジ
	public void ChangeSakaya(){
		if (isBar) {
			audioS.called3 = false;
		}
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
		if (!isBar) {
			audioS.called3 = false;
		}
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
