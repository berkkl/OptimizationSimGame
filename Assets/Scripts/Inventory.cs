using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializedDictionary("Item Name", "Count")]
	public SerializedDictionary<Item, int> itemDictionary = new SerializedDictionary<Item, int>();
	
	[SerializeField] public Item woodItem;
	[SerializeField] public Item stoneItem;
	[SerializeField] public Item concreteItem;
	[SerializeField] public Item timberItem;

	public int woodCount;
	public int stoneCount;
	public int concreteCount;
	public int timberCount;

	[SerializeField] private UI _ui; // Reference to the UI object

	public UI UIComponent
	{
		get { return _ui; }
		set { _ui = value; }
	}

	private void Start()
	{
		//initialize items in the inventory
		itemDictionary.Add(woodItem, 0);
		itemDictionary.Add(stoneItem, 0);
		itemDictionary.Add(concreteItem, 0);
		itemDictionary.Add(timberItem, 0);

		if (_ui != null)
		{
			GetItemCounts();
		}
		else
		{
			Debug.LogWarning("UI reference is not set in the Inventory.");
		}

		GetItemCounts();

	}

	public void AddItem(Item item, int quantity = 1)
	{
		if (itemDictionary.ContainsKey(item))
		{
			itemDictionary[item] += quantity;
		}
		else
		{
			itemDictionary[item] = quantity;
		}

		GetItemCounts();
	}

	public void RemoveItem(Item item, int quantity = 1)
	{
		if (itemDictionary.ContainsKey(item))
		{
			if (itemDictionary[item] > 0) itemDictionary[item] -= quantity;
		}
		GetItemCounts();
	}

	private void GetItemCounts()
	{
		woodCount = GetItemCount(woodItem);
		stoneCount = GetItemCount(stoneItem);
		concreteCount = GetItemCount(concreteItem);
		timberCount = GetItemCount(timberItem);
	}

	public int GetItemCount(Item item)
	{
		return itemDictionary.ContainsKey(item) ? itemDictionary[item] : 0;
	}
}
