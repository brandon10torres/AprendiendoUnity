using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponShoot : MonoBehaviour {

	public GameObject shootPrefab;
	public float shootingRate = 1.0f;

	private float shootCD = 0.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(shootCD > 0)
		{
			shootCD -= Time.deltaTime;
		}	
	}

	public void Attack()
	{
		if (canAttack) 
		{
			shootCD = shootingRate;

			GameObject shootInstantiate = Instantiate (shootPrefab);
			shootInstantiate.transform.position = transform.position;
		}
	}

	public bool canAttack
	{
		get
		{ 
			return shootCD <= 0.0f;
		}
	}

}
