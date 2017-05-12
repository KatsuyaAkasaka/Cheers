using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceScript : MonoBehaviour {

	CheersScript cs;
	private int angle;
	Rigidbody2D rigid;

	bool finish = false;
	Vector2 vec;

	// Use this for initialization
	void Start () {
		cs = GameObject.Find ("GameController").GetComponent<CheersScript>();
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (cs.finish && !finish) {
			angle = Random.Range (0,120);
			if (angle > 60) {
				angle += 120;
			}
			angle -= 30;
			vec.y = 0;
			vec.x = Mathf.Cos (angle / 180f * Mathf.PI);
			rigid.AddForce (vec * 1000f, ForceMode2D.Impulse);
			finish = true;
		}
	}
}
