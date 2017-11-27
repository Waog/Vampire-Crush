using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	public enum RoomState {Hidden, Icon, Discovered};

	public RoomState state = RoomState.Hidden;

	private LabyrinthController labyrinth;

	// Use this for initialization
	void Start () {
		labyrinth = transform.GetComponentInParent<LabyrinthController>();
		Debug.Assert (labyrinth != null);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		switch (state) {
		case RoomState.Hidden:
			GetComponent<SpriteRenderer> ().color = Color.black;
			GetChildrenByTag (gameObject, "RoomIcon") [0].SetActive (false);
			break;
		case RoomState.Icon:
			GetComponent<SpriteRenderer> ().color = Color.black;
			GetChildrenByTag (gameObject, "RoomIcon") [0].SetActive (true);
			break;
		case RoomState.Discovered:
			GetComponent<SpriteRenderer> ().color = Color.white;
			GetChildrenByTag (gameObject, "RoomIcon") [0].SetActive (false);
			break;
		}
	}

	public void raiseRoomState(RoomState newState) {
		if (newState > state) {
			state = newState;
		}
	}

	public void hideIcon() {
		if (state == RoomState.Icon) {
			state = RoomState.Hidden;
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

	public void OnMouseUpAsButton() {
		Debug.Log("OnMouseUpAsButton on Room: " + gameObject);
		labyrinth.OnRoomClicked (gameObject);
	}


}
