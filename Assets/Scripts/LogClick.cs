using UnityEngine;
using System.Collections;

public class LogClick : MonoBehaviour {
	public void OnMouseUpAsButton() {
		Debug.Log("OnMouseUpAsButton on: " + gameObject);
	}

	public void OnHover() {
		Debug.Log("OnHover on: " + gameObject);
	}


	public void OnMouseUp() {
		Debug.Log("OnMouseUp on:" + gameObject);
	}
}
