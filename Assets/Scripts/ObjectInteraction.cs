using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
	
	[SerializeField] public UI uiController;
	private Factory _selectedFactory;
    // Start is called before the first frame update

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
					_selectedFactory = hit.collider.gameObject.GetComponent<Factory>();
					//TODO: Interaction
					FactoryInteraction();
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
					_selectedFactory = collider.gameObject.GetComponent<Factory>();
					FactoryInteraction();
					Debug.Log(collider.gameObject.name);
				}
			}
		}	

		void FactoryInteraction()
		{
			uiController.OpenFactoryPanel(_selectedFactory);
			_selectedFactory.StartProduction();
		}

	}
}


