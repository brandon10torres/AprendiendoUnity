using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comportamientoProyectil : MonoBehaviour {

	public float timeDestruccion = 5;

	public bool efectoImpacto = true;


	// Use this for initialization
	void Start () 
	{
		Destroy (this.gameObject, timeDestruccion);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag ("PowerDownBomb")) 
		{
			collider.gameObject.SetActive (false);

			if (efectoImpacto) 
			{
				specialEffect.Instance.MakeExplosion (collider.gameObject.transform.position);
				soundEffect.Instance.makeExplosionSound();
			}

			Destroy (gameObject);
		}
	}
}
