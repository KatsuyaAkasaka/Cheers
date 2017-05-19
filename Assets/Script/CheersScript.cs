using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheersScript : MonoBehaviour {

	JugScript js;
	public Text cheersText;
	private float timer = 0;
	public bool finish = false;	//これがtrueになると操作可能に
	// Use this for initialization
	void Start () {
		js = GetComponent<JugScript> ();
	}
	
	// Update is called once per frame
	void Update () {

		//注ぎ終わったら乾杯
		if (js.finished && timer < 2.3f) {
			cheersText.text = "cheers!!";
			timer += Time.deltaTime;
		}
		//2.3秒で消失
		if (timer >= 2.3f && !finish) {
			cheersText.text = "";
			finish = true;
		}
	}
}
