using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaFogao : MonoBehaviour {
	public GameObject fogo1;
	public GameObject fogo2;
	public GameObject fogo3;
	public GameObject fogo4;
	public GameObject fogo5;
	bool ativo = false;
	GameObject Jogador;
	public Text Texto;
	public KeyCode TeclaAtivar = KeyCode.P;
	bool fogoAtivo = false;
	public GameObject PontoDeProximidade;
	public Image imgApagar;

	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag ("Player");
		if (fogo1 != null) {
			fogo1.SetActive (false);
		}
		if (fogo2 != null) {
			fogo2.SetActive (false);
		}
		if (fogo3 != null) {
			fogo3.SetActive (false);
		}
		if (fogo4 != null) {
			fogo4.SetActive (false);
		}
		if (fogo5 != null) {
			fogo5.SetActive (false);
		}
		if (Texto != null) {
			Texto.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 localDeChecagem;
		if (fogoAtivo == false) {
			if (ativo == true) {
				if (PontoDeProximidade != null) {
					localDeChecagem = PontoDeProximidade.transform.position;
				} else {
					localDeChecagem = transform.position;
				}
				if (Vector3.Distance (Jogador.transform.position, localDeChecagem) < 3) {
					if (Texto != null) {
						Texto.enabled = true;
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						fogo1.SetActive (true);
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						fogo2.SetActive (true);
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						fogo3.SetActive (true);
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						fogo4.SetActive (true);
					}
					if (Input.GetKeyDown (KeyCode.E)) {
						fogo5.SetActive (true);
						Texto.enabled = false;			
						fogoAtivo = true;
						imgApagar.enabled = false;
					}
				} else {
					Texto.enabled = false;			
				}
			}
		}
	}

	public void ativar(){
		ativo = true;
	}

	public bool getActive(){
		return fogoAtivo;
	}
}
