using UnityEngine;

public class Interactable : MonoBehaviour
{
	public void Interact()
	{
		// This function is called when the object is interacted with.
		Debug.Log("Interacted with " + gameObject.name);
		// Add your custom interaction logic here.
	}
}
