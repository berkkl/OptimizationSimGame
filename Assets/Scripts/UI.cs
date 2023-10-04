using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
	public static UI Instance;

	//[SerializeField] private GameObject _selectedFactory;
	[SerializeField] public GameObject factoryPanel; //future we can make this a list, for each panel we can arrange an offset, and can open different panels
	[SerializeField] public GameObject cityPanel;

	private Factory _selectedFactory;
	public CityController _selectedCity;
	private CityManager _cityManager;
	[SerializeField] private Inventory _playerInventory;

	[SerializeField] public TMP_Text factoryNameText;
	[SerializeField] public TMP_Text factoryProductionMaterialText;
	[SerializeField] public TMP_Text factoryProductionSpeedText;
	[SerializeField] public TMP_Text woodCountText;
	[SerializeField] public TMP_Text stoneCountText;
	[SerializeField] public TMP_Text concreteCountText;
	[SerializeField] public TMP_Text timberCountText;

	[SerializeField] public TMP_Text cityNameText;
	[SerializeField] public TMP_Text cityRequiredItem1;
	[SerializeField] public TMP_Text cityRequiredItem2;
	[SerializeField] public TMP_Text cityRequiredItem3;
	[SerializeField] public TMP_Text cityRequiredItem4;

	const float updateTimeHolder = 0.05f;
	private float updateTimer;

	private void Awake()
	{
		Instance = this;
	}

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

	public void OpenCityPanel(CityManager cityManager,CityController selectedCity)
	{
		_selectedCity = selectedCity;
		_cityManager = cityManager;
		if(selectedCity != null && cityPanel != null && !cityPanel.activeSelf)
		{
			cityPanel.SetActive(true);
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

			woodCountText.text = $"Wood: {_playerInventory.woodCount}";
			stoneCountText.text = $"Stone: {_playerInventory.stoneCount}";
			concreteCountText.text = $"Concrete: {_playerInventory.concreteCount}";
			timberCountText.text = $"Timber: {_playerInventory.timberCount}";

			if(_selectedCity != null && cityPanel.activeSelf)
			{
				cityNameText.text = _selectedCity.name;

				#region wood ui update
				if (_cityManager.cities[_selectedCity][_playerInventory.woodItem] > 0)
				{
					cityRequiredItem1.text = $"{_playerInventory.woodItem.name}: {_cityManager.cities[_selectedCity][_playerInventory.woodItem]}";
				}
				else
				{
					cityRequiredItem1.enabled = false;
				}
				#endregion wood ui update
				#region stone ui update
				if (_cityManager.cities[_selectedCity][_playerInventory.stoneItem] > 0)
				{
					cityRequiredItem2.text = $"{_playerInventory.stoneItem.name}: {_cityManager.cities[_selectedCity][_playerInventory.stoneItem]}";
				}
				else
				{
					cityRequiredItem2.enabled = false;
				}
				#endregion stone ui update
				#region  timber ui update
				if (_cityManager.cities[_selectedCity][_playerInventory.timberItem] > 0)
				{
					cityRequiredItem3.text = $"{_playerInventory.woodItem.name}: {_cityManager.cities[_selectedCity][_playerInventory.timberItem]}";
				}
				else
				{
					cityRequiredItem3.enabled = false;
				}
				#endregion timber ui update
				#region concrete ui update
				if (_cityManager.cities[_selectedCity][_playerInventory.concreteItem] > 0)
				{
					cityRequiredItem4.text = $"{_playerInventory.woodItem.name}: {_cityManager.cities[_selectedCity][_playerInventory.concreteItem]}";
				}
				else
				{
					cityRequiredItem4.enabled = false;
				}
				#endregion concrete ui update
			}
			updateTimer = updateTimeHolder;
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

	public void CloseCityPanel()
	{
		if (cityPanel != null && _selectedCity != null)
		{
			Debug.Log($"is factory selected? {_selectedCity.name}");
			cityPanel.SetActive(false);
		}
	}
}
