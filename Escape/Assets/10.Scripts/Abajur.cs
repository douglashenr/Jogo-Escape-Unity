using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Abajur : MonoBehaviour {
	GameObject Jogador;
	public GameObject capsule;
	public GameObject PontoDeProximidade;
	public int distanciaAbajur = 3;
	public Light _luzes;
	public static bool lightAb1isActive = false;
	public Text TextoAbajur;

	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag ("Player");
		_luzes.enabled = false;
		if (TextoAbajur != null) {
			TextoAbajur.enabled = false;
		}
	}

	void OnMouseDown(){
		Vector3 localDeChecagem;

		if (PontoDeProximidade != null) {
			localDeChecagem = PontoDeProximidade.transform.position;
		} else {
			localDeChecagem = transform.position;
		}
		if (Vector3.Distance (Jogador.transform.position, localDeChecagem) < distanciaAbajur+2) {
			if ((TextoAbajur != null)) {
				TextoAbajur.enabled = true;
			}
				_luzes.enabled = !lightAb1isActive;
				lightAb1isActive = !lightAb1isActive;
				if (_luzes.enabled == true) {
					capsule.GetComponent<DicaEmergencia> ().increment += 1;
				} else {
					capsule.GetComponent<DicaEmergencia> ().increment -= 1;
				}
		} else {
			if ((TextoAbajur != null)) {
				TextoAbajur.enabled = false;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		/*
		Vector3 localDeChecagem;

		if (PontoDeProximidade != null) {
			localDeChecagem = PontoDeProximidade.transform.position;
		} else {
			localDeChecagem = transform.position;
		}
		if (Vector3.Distance (Jogador.transform.position, localDeChecagem) < distanciaAbajur) {
			if ((TextoAbajur != null)) {
				TextoAbajur.enabled = true;
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				_luzes.enabled = !lightAb1isActive;
				lightAb1isActive = !lightAb1isActive;
				if (_luzes.enabled == true) {
					capsule.GetComponent<DicaEmergencia> ().increment += 1;
				} else {
					capsule.GetComponent<DicaEmergencia> ().increment -= 1;
				}
			}
		} else {
			if ((TextoAbajur != null)) {
				TextoAbajur.enabled = false;
			}
		}
		*/
	}
}
