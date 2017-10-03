using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	//Capas que se tienen
	public Renderer[] capas;
	//Velocidad de movimeinto de las capas
	public float[] speed;

	public bool scrollActivado = true;

	private float offset = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (scrollActivado) 
		{
			for (int i = 0; i < capas.Length; i++) 
			{
				if (speed[i] != 0) 
				{
					offset = Time.time;
					float offsetElement = offset * speed [i];
					capas [i].material.mainTextureOffset = new Vector2 (offsetElement, 0);
				}
			}
		}

	}
}
