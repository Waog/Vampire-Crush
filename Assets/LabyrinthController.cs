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

	}

	void Update () {

		rows [player.posY] [player.posX].GetComponent<Room> ().raiseRoomState (Room.RoomState.Discovered);

		foreach (GameObject room in GameObject.FindGameObjectsWithTag("Room"))
		{
			Room roomScript = room.GetComponent<Room> ();
			roomScript.hideIcon ();
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

	void getRoomCoordinates(GameObject room, out int x, out int y) {
		for (int curY = 0; curY < rows.Count; curY++) {
			for (int curX = 0; curX < rows[curY].Count; curX++) {
				if (room == rows [curY] [curX]) {
					x = curX;
					y = curY;
					return;
				}
			}
		}
		throw new KeyNotFoundException ("The desired room was not in the labyrinth");
	}

	bool CoordinatesAreNeighbors(int pos1X, int pos1Y, int pos2X, int pos2Y) {
		return (Mathf.Abs (pos1X - pos2X) + Mathf.Abs (pos1Y - pos2Y)) == 1;
	}

	public void OnRoomClicked(GameObject room) {

		int roomX;
		int roomY;
		getRoomCoordinates(room, out roomX, out roomY);

		if (CoordinatesAreNeighbors(player.posX, player.posY, roomX, roomY)) {
			player.posX = roomX;
			player.posY = roomY;
		}
	}
}
