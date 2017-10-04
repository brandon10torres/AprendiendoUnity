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
	public GameObject gameObjectRespuesta;




	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public IEnumerator ConnectBD(tipoAccionBD tipoConexionBD, string usuarioCheck = "", int puntosUsurio = 0)
	{
		WWWForm form = new WWWForm ();






		switch (tipoConexionBD) 
		{
			case tipoAccionBD.checkUsuario:
			{
				form.AddField ("tipoLlamadaBD", "checkUsuario");
				form.AddField ("usuarioCheck", usuarioCheck);
				WWW llamadaBD = new WWW (URL, form);
				yield return llamadaBD;

				if(!string.IsNullOrEmpty(llamadaBD.error))
				{
					print ("ERROR " + llamadaBD.error);
				}
				gameObjectRespuesta.SendMessage ("respuestaBD", llamadaBD.text);
				break;
			}
			case tipoAccionBD.insertPuntos:
			{
				form.AddField ("tipoLlamadaBD", "insertPuntos");
				form.AddField ("usuarioCheck", usuarioCheck);
				form.AddField ("puntuacionUsuario", puntosUsurio);
				WWW llamadaBD2 = new WWW (URL, form);
				yield return llamadaBD2;

				if(!string.IsNullOrEmpty(llamadaBD2.error))
				{
					print ("ERROR " + llamadaBD2.error);
				}
				break;
			}
			case tipoAccionBD.getRanking:
			{
				/*form.AddField ("tipoLlamadaBD", "getRanking");
				WWW llamadaBD3 = new WWW (URL, form);
				yield return llamadaBD3;

				if(!string.IsNullOrEmpty(llamadaBD3.error))
				{
					print ("ERROR " + llamadaBD3.error);
				}
				gameObjectRespuesta.SendMessage ("respuestaBDR", llamadaBD3.text);*/
				break;
			}
			default:
			{
				break;
			}
		}



		/*if(llamadaBD.text != "")
		{
			print ("Respuesta de BD: " + llamadaBD.text);
		}*/


		//gameObjectRespuesta.SendMessage ("respuestaBD", llamadaBD.text);

	}



}
