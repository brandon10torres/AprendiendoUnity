using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectsGenerator : MonoBehaviour {

	public Transform player;

	public GameObject[] availableObjects;

	public int numMaxObjectsInScene = 10;

	public float distMinAparicionObjetos = 13;

	private List<GameObject> objects = new List<GameObject> ();

	private float screenWidthInPoints = 0.0f;
	private float screenHeightInPoints = 0.0f;



	// Use this for initialization
	void Start () 
	{
		screenHeightInPoints = Camera.main.orthographicSize * 2.0f;
		screenWidthInPoints = Camera.main.aspect * screenHeightInPoints;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GenerateObjectsIfRequired ();
	}

	void GenerateObjectsIfRequired()
	{
		float playerX = player.position.x;

		float removeObjectX = playerX - screenWidthInPoints * 0.75f;

		float farthestObjectX = distMinAparicionObjetos;

		List<GameObject> objectsToRemove = new List<GameObject> ();

		foreach(GameObject obj in objects)
		{
			float objX = obj.transform.position.x;
			float objWidth = obj.transform.Find ("Contorno").lossyScale.x;

			farthestObjectX = Mathf.Max (farthestObjectX, objX + objWidth * 0.5f);

			if(objX < removeObjectX)
			{
				objectsToRemove.Add (obj);
			}
		}

		foreach (GameObject obj in objectsToRemove) 
		{
			objects.Remove (obj);
			Destroy (obj);
		}

		int numItemsActuales = objects.Count;
		if(numItemsActuales < numMaxObjectsInScene)
		{
			AddObject (farthestObjectX);
		}
	}

	void AddObject(float lastObjectX)
	{
		int randomIndex = Random.Range (0, availableObjects.Length);

		GameObject obj = Instantiate (availableObjects[randomIndex]);

		float objWidth = obj.transform.Find ("Contorno").lossyScale.x;
		float objHeight = obj.transform.Find ("Contorno").lossyScale.y;

		float objectPositionX = lastObjectX + Random.Range (3 * objWidth, 4 * objWidth);
		float objectPositionY = Random.Range (0 - screenHeightInPoints * 0.5f + objHeight, 0 + screenHeightInPoints * 0.5f - objHeight);

		obj.transform.position = new Vector3 (objectPositionX, objectPositionY, 0.0f);

		objects.Add (obj);
	}
}
