using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlDobleClick : MonoBehaviour {

	public bool dobleClick = false;

	public float timeToDobleClick = 0.5f;

	private int numClicks = 0;




	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (numClicks == 0) {
				Invoke ("DesactivarDobleclick", timeToDobleClick);
				numClicks++;
			}
			else 
			{
				dobleClick = true;
				numClicks = 0;
				CancelInvoke ("DesactivarDobleclick");
			}
		}
	}

	void DesactivarDobleclick()
	{
		numClicks = 0;
	}
}
