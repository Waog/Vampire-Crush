using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LabyrinthController : MonoBehaviour {

	public List<List<GameObject>> rows;

	// Use this for initialization
	void Start () {
		rows = new List<List<GameObject>> ();
			
		foreach (GameObject rowGO in GetChildrenByTag (gameObject, "row"))
		{
			List<GameObject> rooms = GetChildrenByTag (rowGO, "room");
			rows.Add (rooms);
		}

		Debug.Log (rows.Count);
		Debug.Log (rows[0].Count);
		Debug.Log (rows[3].Count);
		Debug.Log (rows[4][0]);
	}

	void Update () {
	
	}

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
