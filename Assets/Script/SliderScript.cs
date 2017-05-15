using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

	public float change = 0f;
	public Slider slider;
	private float diff = 30f;
	public bool finish = false;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
	}

	// Update is called once per frame

	void Update () {
		if (change > 0.2f) {
			slider.value += diff * Time.deltaTime;
			change -= diff * Time.deltaTime;
		} else if (change < -0.2f) {
			slider.value -= diff * Time.deltaTime;
			change += diff * Time.deltaTime;
		} else {
			finish = true;
		}
	}
}
