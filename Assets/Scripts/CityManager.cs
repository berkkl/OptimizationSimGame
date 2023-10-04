using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
	private float updateTimer;
	[SerializeField] private float updateTimerHolder = 0.1f;
	[SerializeField] private Inventory _playerInventory;
	public Dictionary<CityController, Dictionary<Item, int>> cities = new Dictionary<CityController, Dictionary<Item, int>>();
	private CityController _selectedCity;

	
	private void Start()
	{
		updateTimer = updateTimerHolder;
		Transform myTransform = transform;
		int childCount = myTransform.childCount;
		for(int i = 0; i < childCount; i++)
		{
			CityController curCity = myTransform.GetChild(i).GetComponent<CityController>();
			if (!cities.ContainsKey(curCity))
			{
				cities[curCity] = new Dictionary<Item, int>();
			}

		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			Debug.Log("do nothing");
		}
		updateTimer-=Time.deltaTime;
		if (updateTimer < 0)
		{
			updateTimer = updateTimerHolder;
		}
	}

	public void DropItem(Item item)
	{
		_selectedCity = UI.Instance._selectedCity;
		if (cities[_selectedCity].ContainsKey(item) && cities[_selectedCity][item] > 0 && _playerInventory.itemDictionary[item] > 0){
			cities[_selectedCity][item]--;
			_playerInventory.RemoveItem(item, 1);
		}
	}
}
