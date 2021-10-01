using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUpdate : MonoBehaviour {
	public Light spotLight;
	public static bool lightAllarm = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lightAllarm == false) {
			//spotLight.color = Color.white;
			//spotLight.intensity = 10.0f;
		} else {
			spotLight.color = Color.green;
			spotLight.intensity = 12;
		}
	}
}
