using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night_cycle : MonoBehaviour {
	public float smooth = 5.0f;
	public GameObject gObject;
	public static bool solIsMoving = false;

	// Use this for initialization
	void Start () {
		transform.Rotate(Vector3.right * (Time.deltaTime* -1500.0f));
		transform.Rotate(Vector3.down * (Time.deltaTime* 500.0f));
	}
	
	// Update is called once per frame
	void Update () {
		// rotaciona em direção de acordo com a rotação.
		if (solIsMoving) {
			transform.Rotate (Vector3.right * (Time.deltaTime * smooth));
		}
	}
}
