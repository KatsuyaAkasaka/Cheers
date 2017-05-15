using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {


	public GameObject jug;
	CheersScript cs;
	public int score = 0;
	public Text gameOverText;
	private float moving;
	Rigidbody2D rigid;
	public float speed = 2f;
	public float turningSpeed = 30f;
	TimerScript ts;
	public bool gameOver = false;


	// Use this for initialization
	void Start () {
		cs = GetComponent<CheersScript> ();
		ts = GameObject.Find("TimerText").GetComponent<TimerScript> ();
		rigid = GameObject.Find("Jug").GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//操作可能になったら(ゲームが終わってなかったら)
		if (cs.finish && !ts.gameFinish && !gameOver) {
			moving = Input.GetAxis ("Horizontal");
			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
				rigid.position += new Vector2 (moving * speed * Time.deltaTime, 0);
				if (Mathf.Abs (jug.transform.localRotation.z) < 10f) {
					jug.transform.Rotate (0f, 0f, moving * turningSpeed * Time.deltaTime);	
				}
			} else {
		
				if (jug.transform.rotation.z > 0) {
					jug.transform.Rotate (0f, 0f, -turningSpeed * Time.deltaTime);
				} else {
					jug.transform.Rotate (0f, 0f, turningSpeed * Time.deltaTime);
				}
			}
		}
			
		if (score > 1 && !ts.gameFinish) {
			gameOverText.text = "GameOver...";
			gameOver = true;

		}
	}
}
