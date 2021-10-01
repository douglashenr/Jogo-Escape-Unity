using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlaTempo : MonoBehaviour {
	public Slider slider;
	bool esgotou = false;
	float tempo =60;
	int min=24;
	public Image imgGOver;
	public Text UIText;
	public Text UIMinText;

	// Use this for initialization
	void Start () {
		if (imgGOver != null) {
			imgGOver.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine ("waitIng");
		tempo -= Time.deltaTime;
		UIText.text = tempo.ToString("f0");
		//Debug.Log (tempo);
		if (tempo <= 0.0f) {
			tempo = 59;
			min--;
			UIMinText.text = min.ToString("f0");
			slider.value = min;
		}
		if (min <= 0) {
			imgGOver.enabled = true;
		}
	}
}
