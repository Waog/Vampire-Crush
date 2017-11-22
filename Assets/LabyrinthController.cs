using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LabyrinthController : MonoBehaviour {

	public List<List<GameObject>> rows;

	public PlayerController player;

	// Use this for initialization
	void Start () {
		rows = new List<List<GameObject>> ();
			
		foreach (GameObject rowGO in GetChildrenByTag (gameObject, "Row"))
		{
			List<GameObject> rooms = GetChildrenByTag (rowGO, "Room");
			rows.Add (rooms);
		}

		Debug.Log (rows.Count);
		Debug.Log (rows[0].Count);
		Debug.Log (rows[3].Count);
		Debug.Log (rows[4][0]);
	}

	void Update () {

		rows [player.posY] [player.posX].GetComponent<Room> ().raiseRoomState (Room.RoomState.Discovered);

		foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
		{
			room.GetComponent<Room> ().hideIcon ();
		}

		if (player.posY > 0) {
			rows [player.posY - 1] [player.posX].GetComponent<Room> ().raiseRoomState (Room.RoomState.Icon);
		}

		if (player.posY < rows.Count - 1) {
			rows [player.posY + 1] [player.posX].GetComponent<Room> ().raiseRoomState (Room.RoomState.Icon);
		}

		if (player.posX > 0) {
			rows [player.posY] [player.posX - 1].GetComponent<Room> ().raiseRoomState (Room.RoomState.Icon);
		}

		if (player.posX < rows [player.posY].Count - 1) {
			rows [player.posY] [player.posX + 1].GetComponent<Room> ().raiseRoomState (Room.RoomState.Icon);
		}
	}

	// TODO: move duplicated code
	List<GameObject> GetChildrenByTag(GameObject parent, string tag) {
		List<GameObject> result = new List<GameObject> ();

		for (int i = 0; i < parent.transform.childCount; i++) {
			GameObject child = parent.transform.GetChild (i).gameObject;
			if (child.CompareTag(tag)) {
				result.Add(child);
			}
		}
		return result;
	}
}
