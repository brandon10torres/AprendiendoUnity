using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBControl : MonoBehaviour {

	private string URL = "http://localhost/infinityRun/index.php";
	public enum tipoAccionBD
	{
		checkUsuario, 
		insertPuntos,
		getRanking
	};
	public tipoAccionBD queAccionRelizarBD = tipoAccionBD.checkUsuario;



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public IEnumerator ConnectBD(tipoAccionBD tipoConexionBD)
	{
		WWWForm form = new WWWForm ();

		switch (tipoConexionBD) 
		{
			case tipoAccionBD.checkUsuario:
			{
				form.AddField ("usuarioCheck", "usuario");
				break;
			}
			case tipoAccionBD.insertPuntos:
			{
				form.AddField ("puntuacionUsuario", 100);
				break;
			}
			case tipoAccionBD.getRanking:
			{
				break;
			}
			default:
			{
				break;
			}
		}

		WWW llamadaBD = new WWW (URL, form);
		yield return llamadaBD;

		if(!string.IsNullOrEmpty(llamadaBD.error))
		{
			print ("ERROR " + llamadaBD.error);
		}

		if(llamadaBD.text != "")
		{
			print ("Respuesta de BD: " + llamadaBD.text);
		}

	}



}
