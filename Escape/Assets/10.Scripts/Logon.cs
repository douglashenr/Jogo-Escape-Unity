using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logon : MonoBehaviour {
	public Text textLogin;
	public Text textSenha;
	string login = "magnavox";
	string senha = "1917";
	public GameObject portaPrincipal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void valida(){
		if (textLogin.Equals (login)) {
			if (textSenha.Equals (senha)) {
				Debug.Log ("É tetraaa!");
				portaPrincipal.GetComponent<PortaPrincipal> ().abrirPorta ();
			}
		}
	}
}
