using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

	public Text contadormonedas_UI;
	public Text contadorvida_UI;

	public GameObject panelPause;
	public bool vengoDelPause = false;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void pauseGame()
	{
		panelPause.SetActive (true);
		Time.timeScale = 0;
	}

	public void exitGameSi()
	{
		//Application.Quit ();
		SceneManager.LoadScene("EscenaInicial");
		Time.timeScale = 1;
	}

	public void resumeGame()
	{
		vengoDelPause = true;
		panelPause.SetActive (false);
		Time.timeScale = 1;
	}

	public void restartGame()
	{
		SceneManager.LoadScene("Juego");
		Time.timeScale = 1;
	}

}
