using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialEffect : MonoBehaviour {

	public static specialEffect Instance;

	public GameObject explosionEffect;



	void Awake()
	{
		if (Instance != null) 
		{
			Destroy (this);
		}
		Instance = this;
	}

	public void MakeExplosion(Vector3 position)
	{
		instantiate (explosionEffect, position);
	}

	private GameObject instantiate (GameObject prefabSpecialEffect, Vector3 position)
	{
		GameObject nuevaParticula = Instantiate (prefabSpecialEffect, position, Quaternion.identity);

		Destroy (nuevaParticula.gameObject, 1.5f);
		return nuevaParticula;
	}


}
