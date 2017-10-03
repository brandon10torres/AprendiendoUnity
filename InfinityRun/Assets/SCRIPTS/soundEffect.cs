using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffect : MonoBehaviour {

	public static soundEffect Instance;

	public AudioClip disparo;
	public AudioClip explosion;
	public AudioClip coin;
	public AudioClip corazon;

	void Awake()
	{
		if(Instance != null)
		{
			DestroyImmediate (this);
		}
		Instance = this;
	}

	public void makeDisparoSound()
	{
		MakeSound (disparo);
	}

	public void makeExplosionSound()
	{
		MakeSound (explosion);
	}

	public void makeCoinSound()
	{
		MakeSound (coin);
	}

	public void makeCorazonSound()
	{
		MakeSound (corazon);
	}

	private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint (originalClip, Camera.main.transform.position);
	}

}
