using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour {

	public int yoi = 0;
	private JugScript js;
	private PlayerScript ps;
	private AddForceScript af;
	private Slider slider;
	private bool calledOnce;
	private Rigidbody2D rigid2d, rigid2d2;
	public PhysicsMaterial2D pm;

	// Use this for initialization
	void Start () {
		js = GetComponent<JugScript> ();
		ps = GetComponent<PlayerScript> ();
		af = GetComponentInChildren<AddForceScript> ();
		slider = GameObject.Find ("Slider").GetComponent<Slider> ();		
	}
	
	// Update is called once per frame
	void Update () {
		if (js.finished && !calledOnce) {
			yoi = (int)(slider.value);
			Difficulty ();
			calledOnce = true;
		}
	}

	void Difficulty(){
		//難しさのパラメータ
		//見えない壁のバウンドネス
		//操縦の速さ
		//乾杯の衝撃

		//粒子の重さ
		if (js.state != 0) {
			rigid2d = js.fluids [js.state - 1].GetComponent<Rigidbody2D> ();
			rigid2d.mass = ((1.0f - (float)yoi/200) > 0.2f) ?
				(1.0f - (float)yoi/200) : 0.2f;
			//ビール
		} else {
			rigid2d = js.fluid_yellow.GetComponent<Rigidbody2D> ();
			rigid2d2 = js.fluid_white.GetComponent<Rigidbody2D> ();
			rigid2d.mass = ((1.0f - (float)yoi/200) > 0.2f) ?
				(1.0f - (float)yoi/200) : 0.2f;
			rigid2d2.mass = ((1.0f - (float)yoi/200) > 0.2f) ?
				(1.0f - (float)yoi/200) : 0.2f;
		}

		//バウンド
		pm.bounciness = 
			(yoi / 200 > 1) ? 
			1 : yoi / 200;

		//ジョッキスピード
	//	ps.speed = Mathf.Sqrt(yoi) / 3.5f + 1.0f;

		//乾杯の衝撃
		af.power = (yoi * 20f + 500f > 800f) ? 
			800f : yoi * 20f + 500f;
	}
}
