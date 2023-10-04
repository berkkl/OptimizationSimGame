using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
	
	[SerializeField] public UI uiController;
	private Factory _selectedFactory;
	private CityController _selectedCity;
	private CityManager _cityManager;
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
				if (hit.collider.CompareTag("Factory"))
				{
					_selectedFactory = hit.collider.gameObject.GetComponent<Factory>();
					//TODO: Interaction
					FactoryInteraction();
				}
				else if (hit.collider.CompareTag("City"))
				{
					_selectedCity = hit.collider.gameObject.GetComponent<CityController>();
					_cityManager = _selectedCity.GetComponentInParent<CityManager>();
					CityInteraction();
					Debug.Log($"City Interaction via clicking: {hit.collider.gameObject.name}");
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			float interactRange = 3f;
			Collider[] collidersInRange = Physics.OverlapSphere(transform.position, interactRange);
			foreach (Collider collider in collidersInRange)
			{
				// layer 8 => Factory
				if(collider.gameObject.layer == 8)
				{
					_selectedFactory = collider.gameObject.GetComponent<Factory>();
					FactoryInteraction();
				}
				// layer 9 => City
				else if(collider.gameObject.layer == 9)
				{
					_selectedCity = collider.gameObject.GetComponent<CityController>();
					_cityManager = _selectedCity.GetComponentInParent<CityManager>();
					Debug.Log($"City Interaction via pressing E: {collider.gameObject.name}");
					CityInteraction();

				}
			}
		}	

		void FactoryInteraction()
		{
			uiController.OpenFactoryPanel(_selectedFactory);
			_selectedFactory.StartProduction();
		}

		void CityInteraction()
		{
			uiController.OpenCityPanel(_cityManager, _selectedCity); // or give selected city? or maybe both?
		}

	}
}


