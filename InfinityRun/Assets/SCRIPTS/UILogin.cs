using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogin : MonoBehaviour {

	public Text usuarioIngresado;
	public Text mensajeUsuario;

	public float tiempoMensajes = 3.0f;
	public DBControl myDB;

	private string[] mensajes = 
	{
		"El usuuario debe contener 5 o más caracteres",
		"El usuario ya existe, intenta con otro"
	};


	private string usuInsertado = "";

	void Awake()
	{
		//PlayerPrefs.SetString ("usuarioInfinityRun", "");
		string posibleusuario = PlayerPrefs.GetString ("usuarioInfinityRun", "");
		if (posibleusuario != "") 
		{
			estaticasApp.usuario = posibleusuario;
			SceneManager.LoadScene ("EscenaBienvenida");
		} 
	}



	// Use this for initialization
	void Start () 
	{
		if (estaticasApp.usuario != "") 
		{
			SceneManager.LoadScene ("EscenaBienvenida");
			Time.timeScale = 1;
		}
		mensajeUsuario.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void respuestaBD(string mensaje)
	{
		if(mensaje == "YaExiste")
		{
			MostrarMensajeUsuario (1);
		}
		else
		{
			estaticasApp.usuario = usuInsertado;
			PlayerPrefs.SetString ("usuarioInfinityRun", usuInsertado);
			SceneManager.LoadScene("EscenaBienvenida");
		}
	}

	public void exitApp()
	{
		Application.Quit ();
	}

	public void checkLogin()
	{
		if (usuarioIngresado.text.Length < 5) {
			MostrarMensajeUsuario (0);
		} 
		else 
		{
			usuInsertado = usuarioIngresado.text;
			StartCoroutine (myDB.ConnectBD(DBControl.tipoAccionBD.checkUsuario, usuInsertado));

		}
	}

	private void MostrarMensajeUsuario(int indexMensaje)
	{
		mensajeUsuario.text = mensajes [indexMensaje];
		Invoke ("limpiarMensajesUsuario", tiempoMensajes);
	}

	void limpiarMensajesUsuario()
	{
		mensajeUsuario.text = "";
	}


}
