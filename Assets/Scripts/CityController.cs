using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
	private Dictionary<Item, int> reqiredItems = new Dictionary<Item, int>();
	[SerializeField] private Inventory _playerInventory;
	[SerializeField] private CityManager _cityController;
	//[SerializeField] private CityController _city1;
	
	private List<Item> _items;
	private List<int> _itemsCount = new List<int>();
	public Item wood;
	public Item stone;
	public Item timber;
	public Item concrete;
	public int requiredWood;
	public int reqiredStone;
	public int requiredTimber;
	public int reqiredConcrete;
	


	private void Start()
	{
		wood = _playerInventory.woodItem;
		stone = _playerInventory.stoneItem;
		timber = _playerInventory.timberItem;
		concrete = _playerInventory.concreteItem;
		requiredWood = 4;
		reqiredStone = 5;
		requiredTimber = 0;
		reqiredConcrete = 0;

		_cityController.cities[this].Add(wood, requiredWood);
		_cityController.cities[this].Add(stone, reqiredStone);
		_cityController.cities[this].Add(timber, requiredTimber);
		_cityController.cities[this].Add(concrete, reqiredConcrete);
	}

	// attach to a button


	public int GetCityItemCount(Item item)
	{
		return reqiredItems.ContainsKey(item) ? reqiredItems[item] : 0;
	}
}
