using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform target; // The target to follow (your character).
	public float smoothSpeed = 5f; // The speed at which the camera follows the target.
	public Vector3 offset = new Vector3(0f, 10f, -10f); // The offset from the target.

	private void LateUpdate()
	{
		if (target == null)
			return;

		// Calculate the desired camera position.
		Vector3 desiredPosition = target.position + offset;

		// Smoothly move the camera towards the desired position.
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = target.position + offset;

		// Look at the target (your character).
		transform.LookAt(target);
	}
}
