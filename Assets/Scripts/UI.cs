using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
	//[SerializeField] private GameObject _selectedFactory;
	[SerializeField] public GameObject factoryPanel; //future we can make this a list, for each panel we can arrange an offset, and can open different panels

	private Factory _selectedFactory;
	private Inventory _inventory;

	[SerializeField] public TMP_Text factoryNameText;
	[SerializeField] public TMP_Text factoryProductionMaterialText;
	[SerializeField] public TMP_Text factoryProductionSpeedText;

	public int woodCount;
	[SerializeField] public TMP_Text woodCountText;

	const float updateTimeHolder = 0.05f;
	private float updateTimer;

	private void Start()
	{
		_selectedFactory = null;
	}

	public void OpenFactoryPanel(Factory selectedFactory)
	{
		_selectedFactory = selectedFactory;
		if (selectedFactory != null && factoryPanel != null && !factoryPanel.activeSelf)
		{
			factoryPanel.SetActive(true);

			factoryNameText.text = selectedFactory.name;
			factoryProductionMaterialText.text = _selectedFactory.productionItem.name;
			factoryProductionSpeedText.text = _selectedFactory.productionTimer.ToString("F2");
		}
	}

	private void Update()
	{
		updateTimer -= Time.deltaTime;
		if (updateTimer < 0)
		{
			if(factoryPanel.activeSelf)
			{
				factoryProductionSpeedText.text = _selectedFactory.productionTimer.ToString("F2");
			}

			else 
			{
				woodCountText.text = $"Wood: {woodCount}";
			}
		}
	}

	public void CloseFactoryPanel()
	{
		if(factoryPanel != null && _selectedFactory != null)
		{
			Debug.Log($"is factory selected? {_selectedFactory.name}");
			_selectedFactory.StopProduction();
			factoryPanel.SetActive(false);
		}
	}
}
