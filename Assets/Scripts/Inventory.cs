using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField]
	public Dictionary<Item, int> itemDictionary = new Dictionary<Item, int>();

	[SerializeField] public Item woodItem;
	[SerializeField] public Item stoneItem;
	[SerializeField] public Item timberItem;

	public int woodCount;
	public int stoneCount;
	public int timberCount;

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
		itemDictionary.Add(timberItem, 0);

		if (_ui != null)
		{
			woodCount = GetItemCount(woodItem);
			stoneCount = GetItemCount(stoneItem);
			timberCount = GetItemCount(timberItem);
		}
		else
		{
			Debug.LogWarning("UI reference is not set in the Inventory.");
		}

		woodCount = GetItemCount(woodItem);
		stoneCount = GetItemCount(stoneItem);
		timberCount = GetItemCount(timberItem);

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

		woodCount = GetItemCount(woodItem);
		stoneCount = GetItemCount(stoneItem);
		timberCount = GetItemCount(timberItem);
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
		woodCount = GetItemCount(woodItem);
		stoneCount = GetItemCount(stoneItem);
		timberCount = GetItemCount(timberItem);
	}

	public int GetItemCount(Item item)
	{
		return itemDictionary.ContainsKey(item) ? itemDictionary[item] : 0;
	}
}
