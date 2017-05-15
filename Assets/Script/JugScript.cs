using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugScript : MonoBehaviour {

	public int state = -1;
	private int finishState = 0;
	public GameObject jug;
	public GameObject spawner;
	private float respawnTime = 0;
	public bool finished = false;
	public int param;

	public GameObject fluid_yellow, fluid_white;
	private int yellowNum = 40, whiteNum = 15;
	private int num = 50;


	public GameObject[] fluids = new GameObject[6];	//順に

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find ("Spawner");
	}

	// Update is called once per frame
	void Update () {
		if (!finished && state >= 0) {
			respawnTime += Time.deltaTime;

			//0は軽く2は重い(居酒屋)
			//3は軽く5は重い(バー)
			//居酒屋	ビール,ハイボール,焼酎		8,15,25
			//バー	ワイン,ウイスキー,テキーラ	12,35,40
		
			//ビール
			if (state == 0) {
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
					param = 8;
					finished = true;
				}

				//それ以外
			} else {
				if (finishState == 0 && respawnTime > 0.05f) {
					Pour (fluids[state-1], num);		//stateに応じた液体を注ぐ
					num--;
					respawnTime = 0;
				}
				if (finishState == 1) {
					switch(state){
					case 1:
						param = 15;		//ハイボール
						break;
					case 2:
						param = 25;		//焼酎
						break;
					case 3:
						param = 12;		//ワイン
						break;
					case 4:
						param = 35;		//ウイスキー
						break;
					case 5:
						param = 40;		//テキーラ
						break;
					case 6:
						param = -15;
						break;
					}
					finished = true;
				}
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
