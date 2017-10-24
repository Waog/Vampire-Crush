using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Collider2D cameraFocus;

	public void LateUpdate ()
	{
		transform.position = new Vector3 (cameraFocus.bounds.center.x, cameraFocus.bounds.center.y, transform.position.z);
		updateCameraSizeToFitFocusArea ();
	}

	private void updateCameraSizeToFitFocusArea() {
		if (getScreenAspectRatio () < getCameraFocusAspectRatio ()) {
			setCameraWidth (cameraFocus.bounds.size.x);
		} else {
			setCameraHeight (cameraFocus.bounds.size.x);
		}
	}

	private void setCameraWidth (float widthInUnits) {
		setCameraHeight (widthInUnits / getScreenAspectRatio ());
	}

	private void setCameraHeight (float heightInUnits) {
		GetComponent<Camera> ().orthographicSize = heightInUnits / 2f;
	}

	private float getCameraFocusAspectRatio() {
		return cameraFocus.bounds.size.x / cameraFocus.bounds.size.y;
	}

	private float getScreenAspectRatio() {
		return ((float)Screen.width / Screen.height);
	}

	private float getCameraAspectRatio() {
		return getCameraHeight () / getCameraWidth ();
	}

	private float getCameraHeight() {
		return 2 * GetComponent<Camera> ().orthographicSize * ((float)Screen.width / Screen.height);
	}

	private float getCameraWidth() {
		return 2 * GetComponent<Camera> ().orthographicSize * ((float)Screen.width / Screen.height);
	}
}
