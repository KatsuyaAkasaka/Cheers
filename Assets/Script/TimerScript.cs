using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	private CheersScript cs;
	private PlayerScript ps;
	private Clock clock;
	public Text timerText;
	public Text cleartext;
	public GameObject gameClearText;
	private float time = 6f;
	public bool gameFinish = false;
	private GameObject jug;
	private int drinkingTime = 30;
	private bool flag = false;

	// Use this for initialization
	void Start () {
		ps = GameObject.Find("GameController").GetComponent<PlayerScript> ();
		cs = GameObject.Find("GameController").GetComponent<CheersScript> ();
		jug = GameObject.Find ("Jug");

	}
	
	// Update is called once per frame
	void Update () {
		if (!flag) {
			clock = GameObject.Find ("DontDestroy").GetComponentInChildren<Clock> ();
			flag = true;
		}

		if (cs.finish && !gameFinish && !ps.gameOver) {
			time -= Time.deltaTime;
			timerText.text = time.ToString("f2");
			if (time <= 0) {
				if (!clock.gameClear) {
					cleartext.text = "clear!";
				}
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

		if (clock.gameClear) {
			gameClearText.SetActive (true);
		}

	}
}
