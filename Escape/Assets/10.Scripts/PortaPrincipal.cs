using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class PortaPrincipal : MonoBehaviour {
	public int IDPorta = 0;
	public enum EstadoInic {Aberta90, Fechada00, Trancada};
	public EstadoInic EstadoInicial = EstadoInic.Fechada00;
	public enum TipoDeRotacao {RodarEmX, RodarEmY, RodarEmZ};
	public TipoDeRotacao Rotacao = TipoDeRotacao.RodarEmY;
	public KeyCode TeclaAbrir = KeyCode.E;
	[Range(0.0f,150.0f)] public float grausDeGiro = 90.0f;
	[Range(0.1f,10.0f)] public float velocidadeDeGiro = 5, distanciaDaPorta = 2;
	public bool inverterGiro = false;
	public Text TextoTrancado;
	public Text TextoProximidade;
	[Range(0.1f,4.0f)]public float tempoTexto = 1;
	//
	[Header("Ponto de proximidade opcional")][Space(15)]
	public GameObject PontoDeProximidade;
	//
	Vector3 rotacaoInicial;
	float giroAtual, giroAlvo;
	GameObject Jogador;
	bool estaFechada, estaTrancada;
	Chaves listaDeChaves;
	bool update = true;
	public Image imgWin;

	void Start () {
		rotacaoInicial = transform.eulerAngles;
		Jogador = GameObject.FindWithTag ("Player");
		if (Jogador != null) {
			listaDeChaves = Jogador.GetComponent<Chaves> ();
		}
		if (TextoTrancado != null) {
			TextoTrancado.enabled = false;
		}
		if (TextoProximidade != null) {
			TextoProximidade.enabled = false;
		}
		if (imgWin != null) {
			imgWin.enabled = false;
		}
		switch (EstadoInicial) {
		case EstadoInic.Fechada00:
			estaFechada = true;
			estaTrancada = false;
			giroAlvo = 0.0f;
			giroAtual = 0.0f;
			break;
		case EstadoInic.Aberta90:
			estaFechada = false;
			estaTrancada = false;
			if (inverterGiro == true) {
				giroAtual = grausDeGiro;
				giroAlvo = grausDeGiro;
			} else {
				giroAtual = -grausDeGiro;
				giroAlvo = -grausDeGiro;
			}
			break;
		case EstadoInic.Trancada:
			estaFechada = true;
			estaTrancada = true;
			giroAlvo = 0.0f;
			giroAtual = 0.0f;
			break;
		}
	}

	void Update () {
		if (Jogador != null && listaDeChaves != null && update == true) {
			ControlarPorta ();
			GirarObjeto ();
		}
	}
		

	void ControlarPorta(){
		Vector3 localDeChecagem;
			//=====================================================================================================
			/*if (Input.GetKeyDown (TeclaAbrir) && estaTrancada == false) {
				estaFechada = !estaFechada;
				//
				if (estaFechada == false) {
					if (inverterGiro == true) {
						giroAlvo = grausDeGiro;
					} else {
						giroAlvo = -grausDeGiro;
					}
				} else {
					if (inverterGiro == true) {
						giroAlvo = 0.0f;
					} else {
						giroAlvo = 0.0f;
					}
				}
			}*/
		if (PontoDeProximidade != null) {
			localDeChecagem = PontoDeProximidade.transform.position;
		} else {
			localDeChecagem = transform.position;
		}
		if (Vector3.Distance (Jogador.transform.position, localDeChecagem) < distanciaDaPorta) {
			giroAlvo = grausDeGiro;
		} else {
			
		}

		if (giroAlvo != 00) {
			if (giroAtual <= 80) {
				Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().pausarAnd ();
				Day_Night_cycle.solIsMoving = true;
			} else {
				Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().voltarAnd ();
				Day_Night_cycle.solIsMoving = false;
			
			}
		}

		giroAtual = Mathf.Lerp (giroAtual, giroAlvo, Time.deltaTime * velocidadeDeGiro);

	}

	void GirarObjeto(){
		switch (Rotacao) {
		case TipoDeRotacao.RodarEmX:
			transform.eulerAngles = new Vector3 (rotacaoInicial.x + giroAtual, rotacaoInicial.y, rotacaoInicial.z);
			break;
		case TipoDeRotacao.RodarEmY:
			transform.eulerAngles = new Vector3 (rotacaoInicial.x, rotacaoInicial.y + giroAtual, rotacaoInicial.z);
			break;
		case TipoDeRotacao.RodarEmZ:
			transform.eulerAngles = new Vector3 (rotacaoInicial.x, rotacaoInicial.y, rotacaoInicial.z + giroAtual);
			break;
		}
	}

	IEnumerator MensagemNaTela(){
		if ((TextoTrancado != null) && (TextoTrancado.enabled == false)) {
			TextoProximidade.enabled = false;
			TextoTrancado.enabled = true;
			yield return new WaitForSeconds (tempoTexto);
			TextoTrancado.enabled = false;
		}
	}

	IEnumerator MensagemProximidade(){
		if ((TextoProximidade != null) && (TextoProximidade.enabled == false) && (TextoTrancado.enabled == false)) {
			TextoProximidade.enabled = true;
			yield return new WaitForSeconds (tempoTexto);
			TextoProximidade.enabled = false;
		}
	}

	public void abrirPorta(){
		if (imgWin != null) {
			imgWin.enabled = true;
		}
		Debug.Log ("Abrrrrrrrrrrrrrrrrrrrrir");
		//giroAlvo = -grausDeGiro;
		transform.Rotate(0, 0, -179f);
		update = false;
		//giroAtual = Mathf.Lerp (giroAtual, giroAlvo, Time.deltaTime * velocidadeDeGiro);
	}
}
