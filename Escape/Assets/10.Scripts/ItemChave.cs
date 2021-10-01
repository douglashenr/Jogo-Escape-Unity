using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class ItemChave : MonoBehaviour {

	public int IDDestaChave = 0;
	[Range(0.1f,10.0f)] public float distanciaDaChave = 3;
	public KeyCode TeclaPegar = KeyCode.E;
	public AudioClip somPegarChave;
	AudioSource emissorDeSom;
	GameObject Jogador;
	Chaves _listaDeChaves;
	bool jaPegou;
	public Text Texto;
	public bool podePegar = false;
	public Image imageActive;

	void Start(){
		jaPegou = false;
		Jogador = GameObject.FindWithTag ("Player");
		if (Jogador != null) {
			_listaDeChaves = Jogador.GetComponent<Chaves> ();
		}
		if (Texto != null) {
			Texto.enabled = false;
		}
		if (imageActive != false) {
			imageActive.enabled = false;
		}
		emissorDeSom = GetComponent<AudioSource> ();
		emissorDeSom.playOnAwake = false;
		emissorDeSom.loop = false;
	}

	void OnMouseDown(){
		if (podePegar == true) {
			if (Jogador != null && _listaDeChaves != null) {
				if (jaPegou == false) {
					float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
					if (distancia < distanciaDaChave) {
						if (Texto != null) {
							Texto.enabled = true;
						}
						_listaDeChaves.ChavesDoJogador.Add (IDDestaChave);
						jaPegou = true;
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
			if (Jogador != null && _listaDeChaves != null) {
				if (jaPegou == false) {
					float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
					if (distancia < distanciaDaChave) {
						if (Texto != null) {
							Texto.enabled = true;
						}
						if (Input.GetKeyDown (TeclaPegar)) {
							_listaDeChaves.ChavesDoJogador.Add (IDDestaChave);
							jaPegou = true;
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
		if (somPegarChave != null) {
			emissorDeSom.clip = somPegarChave;
			emissorDeSom.PlayOneShot (emissorDeSom.clip);
		}
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
		if (Texto != null) {
			Texto.enabled = false;
		}
		if (imageActive != false) {
			imageActive.enabled = true;
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
