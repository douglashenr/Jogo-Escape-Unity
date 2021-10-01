using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CadeiraMover : MonoBehaviour {
	GameObject Jogador;
	public GameObject PontoDeProximidade;
	public Text Texto;
	public int distanciaObj = 2;
	public bool isMoving = true;
	public int portPos = 0;
	public float x = -274.8f;
	public float y = 268.215f;
	public float z = -213f;
	public float yNPos = 301.4f;
	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag ("Player");
		if (Texto != null) {
			Texto.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		controlarCadeira ();
	}
		

	void controlarCadeira(){
		Vector3 localDeChecagem;

		if (PontoDeProximidade != null) {
			localDeChecagem = PontoDeProximidade.transform.position;
		} else {
			localDeChecagem = transform.position;
		}
		if (isMoving == true) {
			if (Vector3.Distance (Jogador.transform.position, localDeChecagem) < distanciaObj) {
				if (Texto != null) {
					Texto.enabled = true;
				}
				if (Input.GetKeyDown (KeyCode.E)) {
					//StartCoroutine ("movObjeto");
					moverObjeto ();
					Texto.enabled = false;
				}
			} else {
				if (Texto != null) {
					Texto.enabled = false;
				}
			}
		}
	}

	void moverObjeto(){
		while (y < (yNPos)){
			y=y+0.001f;
			transform.localPosition = new Vector3 (x, y, z);
		}
		isMoving = false;
	}

	IEnumerator movObjeto(){
		while (y < (yNPos)){
			y+=20;
			transform.localPosition = new Vector3 (x, y, z);
			yield return new WaitForSeconds (1);
		}
		isMoving = false;
	}
}
