using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	private CheersScript cs;
	private PlayerScript ps;
	public Text timerText;
	public Text cleartext;
	private float time = 6f;
	public bool gameFinish = false;
	private GameObject jug;
	private int drinkingTime = 30;

	// Use this for initialization
	void Start () {
		ps = GameObject.Find("GameController").GetComponent<PlayerScript> ();
		cs = GameObject.Find("GameController").GetComponent<CheersScript> ();
		jug = GameObject.Find ("Jug");

	}
	
	// Update is called once per frame
	void Update () {
		if (cs.finish && !gameFinish && !ps.gameOver) {
			time -= Time.deltaTime;
			timerText.text = time.ToString("f2");
			if (time <= 0) {
				cleartext.text = "clear!";
				gameFinish = true;
				GameObject.Find ("DontDestroy").SendMessage ("ScoreUp");
				GameObject.Find ("clock").SendMessage ("PassTime", drinkingTime);
			}
		} else {
			if (jug.transform.rotation.z > 0) {
				jug.transform.Rotate (0f, 0f, -15f * Time.deltaTime);
			} else {
				jug.transform.Rotate (0f, 0f, 15f * Time.deltaTime);
			}
		}

	}
}
