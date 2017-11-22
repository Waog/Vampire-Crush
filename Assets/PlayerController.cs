using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int posX = 1;
	public int posY = 6;

	public LabyrinthController labyrinth;

	void Update () {
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			posX++;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			posX--;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			posY++;
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			posY--;
		}

		if (posY < 0) {
			posY = 0;
		}

		if (posY > labyrinth.rows.Count - 1) {
			posY = labyrinth.rows.Count - 1;
		}

		if (posX < 0) {
			posX = 0;
		}
		if (posX > labyrinth.rows [posY].Count - 1) {
			posX = labyrinth.rows [posY].Count - 1;
		}
	}

	void LateUpdate() {
		transform.position = labyrinth.rows [posY] [posX].transform.position;
	}
}
