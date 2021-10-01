using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour {
	public bool podeLer = false;
	public Text Texto;
	public KeyCode TeclaPegar = KeyCode.L;
	GameObject Jogador;
	public Image imgCarta;
	public Image imgStatus;

	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag ("Player");
		if (Texto != null) {
			Texto.enabled = false;
		}
		if (imgCarta != null) {
			imgCarta.enabled = false;		
		}
		if (imgStatus != null) {
			imgStatus.enabled = false;		
		}
	}

	// Update is called once per frame
	void Update () {
		if (podeLer == true) {
			if (Jogador != null) {
				float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
				if (distancia < 3) {
					if (Texto != null) {
						Texto.enabled = true;
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						Texto.enabled = false;
						if (imgCarta != null) {
							Texto.enabled = false;
							if (imgStatus != null) {
								imgStatus.enabled = true;		
							}
							StartCoroutine ("MensagemLeitura");	
						}
					}
				} else {
					if (Texto != null) {
						Texto.enabled = false;
					}
				}
			}
		}
	}

	public void lerActive(){
		podeLer = true;
	}

	public void lerDesactive(){
		podeLer = false;
		if (Texto != null) {
			Texto.enabled = false;
		}
	}

	IEnumerator MensagemLeitura(){
		Texto.enabled = false;
		imgCarta.enabled = true;		
		yield return new WaitForSeconds (1);
		imgCarta.enabled = false;		
	}
}
