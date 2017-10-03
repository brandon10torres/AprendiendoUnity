using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomGenerator : MonoBehaviour {

	public Transform player;
	public GameObject[] availableRooms;

	private List<GameObject> currentRooms = new List<GameObject> ();

	private float screenWidthInPoints = 0.0f;

	// Use this for initialization
	void Start () 
	{
		float heightScreen = Camera.main.orthographicSize * 2.0f;
		screenWidthInPoints = Camera.main.aspect * heightScreen;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GenerateRoomIfRequired ();
	}

	void GenerateRoomIfRequired()
	{
		List<GameObject> roomsToRemove = new List<GameObject> ();

		bool addRooms = true;

		float playerPosX = player.position.x;

		float removeRooomX = playerPosX - screenWidthInPoints;
		float addRoomX = playerPosX + screenWidthInPoints;

		float farthestRoomEndX = -availableRooms[0].transform.Find("Techo").lossyScale.x;

		foreach(GameObject room in currentRooms)
		{
			float roomWidth = room.transform.Find ("Techo").lossyScale.x;
			float roomStartX = room.transform.position.x - roomWidth * 0.5f;
			float roomEndX = room.transform.position.x + roomWidth * 0.5f;

			if(roomStartX > addRoomX)
			{
				addRooms = false;
			}
			if(roomEndX < removeRooomX)
			{
				roomsToRemove.Add (room);
			}
			farthestRoomEndX = Mathf.Max (farthestRoomEndX, roomEndX);
		}

		foreach(GameObject roomToRemove in roomsToRemove)
		{
			currentRooms.Remove (roomToRemove);
			Destroy (roomToRemove);
		}

		if(addRooms)
		{
			AddRoom (farthestRoomEndX);
		}			
	}
	void AddRoom(float farthestRoomEndX)
	{
		int randomRoomIndex = Random.Range(0, availableRooms.Length);

		GameObject room = Instantiate(availableRooms[randomRoomIndex]);

		float roomWidth = room.transform.Find ("Techo").lossyScale.x;
		float roomCenter = farthestRoomEndX + roomWidth * 0.5f;
		room.transform.position = new Vector3 (roomCenter, 0, 0);

		currentRooms.Add (room);
	}
}
