using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjects : MonoBehaviour {

	public Vector2 speed = new Vector2 (5, 5);
	public Vector2 direction = new Vector2 (1, 0);

	private Vector2 movement;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
