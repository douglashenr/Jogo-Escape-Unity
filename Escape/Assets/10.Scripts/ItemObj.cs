using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class ItemObj : MonoBehaviour {

	[Range(0.1f,10.0f)] public float distanciaObj = 3;
	public KeyCode TeclaPegar = KeyCode.P;
	public AudioClip somPegar;
	AudioSource emissorDeSom;
	GameObject Jogador;
	public bool jaPegou;
	public Text Texto;
	public Image ImageItem;
	public bool podePegar = false;
	public GameObject objetoLiberar;

	void Start(){
		jaPegou = false;
		Jogador = GameObject.FindWithTag ("Player");
		if (Texto != null) {
			Texto.enabled = false;
		}
		if (ImageItem != null) {
			ImageItem.enabled = false;
		}
		emissorDeSom = GetComponent<AudioSource> ();
		emissorDeSom.playOnAwake = false;
		emissorDeSom.loop = false;
	}

	void OnMouseDown(){
		if (podePegar == true) {
			if (Jogador != null) {
				if (jaPegou == false) {
					float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
					if (distancia < distanciaObj) {
						if (Texto != null) {
							Texto.enabled = true;
						}
						jaPegou = true;
						if (objetoLiberar != null) {
							objetoLiberar.GetComponent<ControlaFogao> ().ativar ();					
						}
						StartCoroutine ("DestruirObjeto");
					} else {
						if (Texto != null) {
							Texto.enabled = false;
						}
					}
				}
			}
		}
	}

	void Update(){
		/*if (podePegar == true) {
			if (Jogador != null) {
				if (jaPegou == false) {
					float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
					if (distancia < distanciaObj) {
						if (Texto != null) {
							Texto.enabled = true;
						}
						if (Input.GetKeyDown (TeclaPegar)) {
							jaPegou = true;
							if (objetoLiberar != null) {
								objetoLiberar.GetComponent<ControlaFogao> ().ativar ();					
							}
							StartCoroutine ("DestruirObjeto");
						}
					} else {
						if (Texto != null) {
							Texto.enabled = false;
						}
					}
				}
			}
		}*/
	}

	IEnumerator DestruirObjeto(){
		MeshRenderer renderer = GetComponentInChildren <MeshRenderer> ();
		if (renderer != null) {
			renderer.enabled = false;
		}
		if (somPegar != null) {
			emissorDeSom.clip = somPegar;
			emissorDeSom.PlayOneShot (emissorDeSom.clip);
		}
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
		if (Texto != null) {
			Texto.enabled = false;
		}
		if (ImageItem != null) {
			ImageItem.enabled = true;
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
}
