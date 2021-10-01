using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DesativarCoifa : MonoBehaviour {
	public bool podePegar = false;
	public Text Texto;
	public KeyCode TeclaPegar = KeyCode.P;
	GameObject Jogador;
	public Light spotLight_circle;
	public Light spotLight;
	bool coifa_ativada = true;


	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag ("Player");
		if (Texto != null) {
			Texto.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (coifa_ativada == true) {
			if (podePegar == true) {
				if (Jogador != null) {
					float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
					if (distancia < 3) {
						if (Texto != null) {
							Texto.enabled = true;
						}
						if (Input.GetKeyDown (TeclaPegar)) {
							spotLight_circle.enabled = false;
							spotLight.enabled = false;
							coifa_ativada = false;
							Texto.enabled = false;
						}
					} else {
						if (Texto != null) {
							Texto.enabled = false;
						}
					}
				}
			}
		}
	}

	public void pegarActive(){
		podePegar = true;
	}

	public void pegarDesactive(){
		podePegar = false;
		if (Texto != null) {
			Texto.enabled = false;
		}
	}

	public bool getActive(){
		return coifa_ativada;
	}
}
