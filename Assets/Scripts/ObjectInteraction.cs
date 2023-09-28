using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.CompareTag("Interactable"))
				{
					//TODO: Interaction
					Interact(hit.collider.gameObject);
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			float interactRange = 3f;
			Collider[] collidersInRange = Physics.OverlapSphere(transform.position, interactRange);
			foreach (Collider collider in collidersInRange)
			{
				if(collider.gameObject.layer == 8)
				{
					Debug.Log(collider.gameObject.name);
				}
			}
		}	
	}

	public void Interact(GameObject interactionObject)
	{
		Debug.Log("Interacted");
	}

}


