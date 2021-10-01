using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicaEmergencia : MonoBehaviour {
	public GameObject capsule;
	public int increment =0;
	public bool foi = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Vector3 localDeChecagem;

		if (capsule != null) {
			localDeChecagem = capsule.transform.position;
		} else {
			localDeChecagem = transform.position;
		}

		if ((increment >= 2)) {
			if (foi == false) {
				capsule.transform.localPosition = new Vector3 (-0.30f, 24.2f, 37.1f);
				foi = true;
			}
		} else if (increment == 1) {
			capsule.transform.localPosition = new Vector3 (-0.65f, 24.2f, 37.1f);
			foi = false;
		}
		else {
			capsule.transform.localPosition = new Vector3 (-0.8f, 24.2f, 37.1f);
			foi = false;
		}
	}

	public void setIncrement(){
		increment += 1;
	}

	public void retireIncrement(){
		increment-= 1;
	}
}
