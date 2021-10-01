using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AtivarAlarmes : MonoBehaviour {
	public bool podePegar = false;
	public Text Texto;
	public KeyCode TeclaPegar = KeyCode.P;
	GameObject Jogador;
	public Light spotLight;
	public Light light_1;
	public Light light_2;
	public Light light_3;
	public Light light_4;
	bool alarmeAtivado = false;


	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag ("Player");
		if (Texto != null) {
			Texto.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (alarmeAtivado == false) {
			if (podePegar == true) {
				if (Jogador != null) {
					float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
					if (distancia < 3) {
						if (Texto != null) {
							Texto.enabled = true;
						}
						if (Input.GetKeyDown (TeclaPegar)) {
							spotLight.color = Color.green;
							light_1.color = Color.green;
							light_2.color = Color.green;
							light_3.color = Color.green;
							light_4.color = Color.green;

							alarmeAtivado = true;
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
		return alarmeAtivado;
	}
}
