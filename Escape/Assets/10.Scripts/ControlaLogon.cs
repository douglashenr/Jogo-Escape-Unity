using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaLogon : MonoBehaviour {
	public Text Texto;
	public KeyCode TeclaPegar = KeyCode.Q;
	GameObject Jogador;

	public Text lbl;
	public Text textLogin;
	public Text textSenha;
	string login = "magnavox";
	string senha = "1917";
	public GameObject portaPrincipal;
	public Canvas cLogon;
	KeyCode TeclaLogar = KeyCode.L;
	public InputField inpLogin;
	public InputField inpSenha;
	public Button btnValida;

	// Use this for initialization
	void Start () {
		Jogador = GameObject.FindWithTag ("Player");
		if (Texto != null) {
			Texto.enabled = false;
		}
		if (cLogon != null) {
			cLogon.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int ret =0;
		float distancia = Vector3.Distance (Jogador.transform.position, transform.position);
		if (distancia < 2) {
			if (Texto != null) {
				Texto.enabled = true;
			}
			if (Input.GetKeyDown (KeyCode.Q)){
				Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().travarAnd ();
				Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().travarCamera ();

				Texto.enabled = false;
				cLogon.enabled = true;
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				cLogon.enabled = false;
				Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().voltarCamera ();
				Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().voltarAnd ();
			}
		} else {
			Texto.enabled = false;
			cLogon.enabled = false;
			Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().voltarAnd();
			Jogador.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().voltarCamera ();
		}
	}
		

	public void valida(){
		//if (cLogon.enabled == true) {
			Debug.Log ("Foi");
			if (textLogin.text.Equals (login)) {
				if (textSenha.text.Equals (senha)) {
					Debug.Log ("É tetraaa!");
					lbl.text = "Login aceito!";
					cLogon.enabled = false;
					portaPrincipal.GetComponent<PortaPrincipal> ().abrirPorta ();
				} else {
					Debug.Log ("Erooou");
					lbl.text = "Senha Invalida!";
				}
			} else {
				Debug.Log ("Erooou");
				lbl.text = "Login Invalido";
			}
		}
	//}
}
