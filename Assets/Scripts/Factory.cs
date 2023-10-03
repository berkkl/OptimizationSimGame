using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Factory : MonoBehaviour
{
	public Item productionItem; // Assign the specific item to produce in the Inspector
	public float productionTimer;
	private float _productionTimerHolder;
	private bool _isProducing;
	public Inventory inventory;

	private void Start()
	{
		productionTimer = 5f;
		_productionTimerHolder = productionTimer;
		_isProducing = false;
	}
	private void Update()
	{
		if (_isProducing) { StartProduction(); }
	}

	public void StartProduction()
	{
		if(productionItem == inventory.timberItem)
		{
			//timber production
			if (inventory.woodCount > 0)
			{
				if (!_isProducing)
				{
					//if I have only 1 wood, then it doesn't remove?
					inventory.RemoveItem(inventory.woodItem);
				}
				_isProducing = true;
				productionTimer -= Time.deltaTime;
				if (productionTimer <= 0)
				{
					productionTimer = _productionTimerHolder;
					ProduceItem(productionItem);
				}
			}
			//add else if for other productions with prerequisite items
			else
			{
				Debug.Log("yeterli odun yok");
			}

		}
		else
		{
			_isProducing = true;
			productionTimer -= Time.deltaTime;
			if (productionTimer <= 0)
			{
				productionTimer = _productionTimerHolder;
				ProduceItem(productionItem);
			}
		}
	}

	public void StopProduction()
	{
		_isProducing = false;
	}

	void ProduceItem(Item itemToProduce)
	{
		inventory.AddItem(itemToProduce);
	}
}
