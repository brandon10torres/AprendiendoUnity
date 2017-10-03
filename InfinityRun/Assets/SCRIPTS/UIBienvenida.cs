using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIBienvenida : MonoBehaviour {

	public Text mensajeBienvenida;




	// Use this for initialization
	void Start () 
	{
		mensajeBienvenida.text = "Bienvenido " + estaticasApp.usuario + "!";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void exitApp()
	{
		Application.Quit();
	}

	public void playGame()
	{
		SceneManager.LoadScene ("Juego");
	}
}
