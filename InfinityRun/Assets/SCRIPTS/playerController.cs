using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	public Animator animPlayer;
	public float fuerzaImpulso = 300;
	public float velocidadAdelante = 3;
	public bool tocarSuelo = false;
	public GameObject sueloCheck;
	public LayerMask sueloObjLayer;
	public int corazon = 10;
	public int bomba = -20;
	public weaponShoot myWeapon;
	public ctrlDobleClick dobleclick;
	public UIControl myUI;
	public GameObject panelRestart;
	public DBControl myBD;
	public Text txtPosicion;


	private float _vida = 100;
	public float vida
	{
		get
		{
			return _vida;
		}
		set
		{ 
			_vida = value;
			if(_vida <= 0)
			{
				_vida = 0;
				Die ();
			}
			if(_vida > 100)
			{
				_vida = 100;
			}
			myUI.contadorvida_UI.text = _vida.ToString ();
			animPlayer.SetFloat ("Vida", _vida);
		}
	}

	[SerializeField]
	private int _coins = 0;
	public int coins
	{
		get
		{ 
			return _coins;
		}
		set
		{ 
			_coins = value;
			myUI.contadormonedas_UI.text = _coins.ToString ();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			StartCoroutine(myBD.ConnectBD (DBControl.tipoAccionBD.checkUsuario));

		}
	}

	void FixedUpdate()
	{
		bool impulsarPlayer = Input.GetMouseButton (0);

		if(impulsarPlayer)
		{
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, fuerzaImpulso));
		}

		Vector2 nuevaVelocidad = GetComponent<Rigidbody2D>().velocity;
		nuevaVelocidad.x = velocidadAdelante;
		GetComponent<Rigidbody2D>().velocity = nuevaVelocidad;

		UpdateTocarSueloStatus ();

		ctrlMyShoot ();
	}

	void UpdateTocarSueloStatus()
	{
		tocarSuelo = Physics2D.OverlapCircle (sueloCheck.transform.position, 0.1f, sueloObjLayer);
		animPlayer.SetBool ("TocarSuelo", tocarSuelo);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag ("PowerUpCoin")) 
		{
			soundEffect.Instance.makeCoinSound ();
			collider.gameObject.SetActive (false);
			coins++;
			print (coins);
		} 
		else if (collider.gameObject.CompareTag ("PowerUpHearth"))
		{
			soundEffect.Instance.makeCorazonSound ();
			collider.gameObject.SetActive (false);
			vida += corazon;
		}
		else if (collider.gameObject.CompareTag ("PowerDownBomb"))
		{
			soundEffect.Instance.makeExplosionSound ();
			specialEffect.Instance.MakeExplosion (collider.gameObject.transform.position);
			collider.gameObject.SetActive (false);
			vida += bomba;
		}
	}

	void ctrlMyShoot()
	{
		if (dobleclick.dobleClick) 
		{
			dobleclick.dobleClick = false;

			if (myUI.vengoDelPause) 
			{
				myUI.vengoDelPause = false;
				return;
			}

			myWeapon.Attack ();
			soundEffect.Instance.makeDisparoSound ();
		}

	}


	void Die()
	{
		panelRestart.SetActive (true);
		Time.timeScale = 0;

		int puntuacionMax = PlayerPrefs.GetInt ("maxScore", 0);
		if(puntuacionMax <= _coins)
		{
			StartCoroutine (myBD.ConnectBD(DBControl.tipoAccionBD.insertPuntos, estaticasApp.usuario, _coins));
			PlayerPrefs.SetInt ("maxScore", _coins);
		}
		//StartCoroutine (myBD.ConnectBD (DBControl.tipoAccionBD.getRanking));
	}

	void respuestaBDR(string mensaje)
	{
		string[] bestPlayers = mensaje.Split ('#');
		int miPosicion = 100;
		for(int i = 0; i < bestPlayers.Length; i++)
		{
			if(bestPlayers[i] == estaticasApp.usuario)
			{
				miPosicion = i + 1;
			}
		}
		txtPosicion.text = "Tu posición es: " + miPosicion.ToString ();
	}


}
