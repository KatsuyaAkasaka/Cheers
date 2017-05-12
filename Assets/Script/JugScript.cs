using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugScript : MonoBehaviour {

	public int state = 0;
	private int finishState = 0;
	public GameObject jug;
	public GameObject spawner;
	private float respawnTime = 0;
	public bool finished = false;
	public int param;


	//ビール
	public GameObject fluid_yellow, fluid_white;
	private int yellowNum = 150, whiteNum = 60;

	//カシオレ
	public GameObject fluid_orange;
	private int orangeNum = 100;

	//ワイン
	public GameObject fluid_purple;
	private int purpleNum = 66;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find ("Spawner");
	}

	// Update is called once per frame
	void Update () {
		if (!finished) {
			respawnTime += Time.deltaTime;

			//1の時はビール2の時はカシオレ3の時はワイン
			if (state == 1) {
				if (jug.activeSelf == false) {
					finishState = 0;
					jug.SetActive (true);
				}
				//yellow注いだ後にwhiteを注ぐ
				if (finishState == 0 && respawnTime > 0.05f) {
					Pour (fluid_yellow, yellowNum);
					yellowNum--;
					respawnTime = 0;
				}
				if (finishState == 1 && respawnTime > 0.05f) {
					Pour (fluid_white, whiteNum);
					whiteNum--;
					respawnTime = 0;
				}
				if (finishState == 2) {
					finished = true;
				}

				param = 5;


			} else if (state == 2) {
				if (jug.activeSelf == false) {
					finishState = 0;
					jug.SetActive (true);
				}
				if (finishState == 0 && respawnTime > 0.05f) {
					Pour (fluid_orange, orangeNum);
					orangeNum--;
					respawnTime = 0;
				}
				if (finishState == 1) {
					finished = true;
				}

				param = 7;


			} else if (state == 3) {
				if (jug.activeSelf == false) {
					finishState = 0;
					jug.SetActive (true);
				}
				if (finishState == 0 && respawnTime > 0.05f) {
					Pour (fluid_purple, purpleNum);
					purpleNum--;
					respawnTime = 0;
				}
				if (finishState == 1) {
					finished = true;
				}

				param = 9;
			}
		}
	}

	//fluidをtime回注ぐ関数
	public void Pour(GameObject fluid, int times){
		GameObject nowFluid = 
			Instantiate (fluid, spawner.transform.position, Quaternion.identity)
			as GameObject;
		nowFluid.GetComponent<Rigidbody2D> ().AddForce (transform.up * -50f);
		if (times <= 0) {
			finishState++;
		}
	}


}
