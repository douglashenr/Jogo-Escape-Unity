using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaAlarme : MonoBehaviour {
	public GameObject objCoifa;
	public GameObject objAllarm;
	public GameObject objFogao;
	float tempo =60;
	public Slider slider;
	public bool ativa = false;
	bool update = true;
	public GameObject portaPrincipal;
	public AudioSource aSource;
	public AudioClip som;

	// Use this for initialization
	void Start () {
		if (slider != null) {
			slider.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (update == true){
			verificaAtivacao ();
			if (ativa == true) {
				tempo -= Time.deltaTime;
				if (tempo >= 0.0f) {
					tempo-=1;
					slider.value = tempo;
				}
				if (tempo <= 1) {
					portaPrincipal.GetComponent<PortaPrincipal> ().abrirPorta ();
					update = false;
				}
			}
		}
	}

	void verificaAtivacao(){
		if (ativa == false) {
			if (objCoifa.GetComponent<DesativarCoifa> ().getActive () == false) {
				//Debug.Log ("objCoifa Desativada");
				if (objAllarm.GetComponent<AtivarAlarmes> ().getActive () == true) {
					//Debug.Log ("Alarme Ativado");
					if (objFogao.GetComponent<ControlaFogao> ().getActive () == true) {
						//Debug.Log ("Fogão Ativado");
						//aSource.loop = true;
						if (aSource != null) {
							aSource.pitch = 2;
							aSource.clip = som;
							aSource.PlayOneShot (som);
						}
						slider.enabled = true;
						ativa = true;
					}
				}
			}
		}
	}
}
