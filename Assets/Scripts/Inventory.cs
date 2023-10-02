using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField]
	public Dictionary<Item, int> itemDictionary = new Dictionary<Item, int>();

	[SerializeField] private Item woodItem;
	[SerializeField] private Item stoneItem;

	[SerializeField] private UI _ui; // Reference to the UI object

	public UI UIComponent
	{
		get { return _ui; }
		set { _ui = value; }
	}

	private void Start()
	{
		itemDictionary.Add(woodItem, 0);
		itemDictionary.Add(stoneItem, 0);

		if (_ui != null)
		{
			_ui.woodCount = GetItemCount(woodItem);
			_ui.stoneCount = GetItemCount(stoneItem);
		}
		else
		{
			Debug.LogWarning("UI reference is not set in the Inventory.");
		}

		_ui.woodCount = GetItemCount(woodItem);
		_ui.stoneCount = GetItemCount(stoneItem);

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

		_ui.woodCount = GetItemCount(woodItem);
		_ui.stoneCount = GetItemCount(stoneItem);
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
