using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField]
	public Dictionary<Item, int> itemDictionary = new Dictionary<Item, int>();

	private UI _ui;

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

		_ui.woodCount = GetItemCount(item);
	}

	public void RemoveItem(Item item, int quantity = 1)
	{
		if (itemDictionary.ContainsKey(item))
		{
			itemDictionary[item] -= quantity;
			if (itemDictionary[item] <= 0)
			{
				itemDictionary.Remove(item);
			}
		}
	}

	public int GetItemCount(Item item)
	{
		return itemDictionary.ContainsKey(item) ? itemDictionary[item] : 0;
	}
}
