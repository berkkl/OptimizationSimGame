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
	private bool _hasEnoughFuel;
	public Inventory inventory;

	private void Start()
	{
		productionTimer = 5f;
		_productionTimerHolder = productionTimer;
		_isProducing = false;
		_hasEnoughFuel = false;
	}
	private void Update()
	{
		if (_isProducing) { StartProduction(); }
	}

	public void StartProduction()
	{
		if(productionItem == inventory.timberItem)
		{
			TimberProduction(inventory.timberItem, 1);
		}
		else if(productionItem == inventory.concreteItem){
			ConcreteProduction(inventory.concreteItem, 2);
		}
		else
		{
			ProductionSequence();
		}
		
	}

	private void TimberProduction(Item item, int requiredAmount = 1)
	{
		//timber production
		if (inventory.woodCount >= requiredAmount)
		{
			if (!_hasEnoughFuel)
			{
				inventory.RemoveItem(inventory.woodItem, requiredAmount);
				_hasEnoughFuel = true;
			}
		}
		if (_hasEnoughFuel)
		{
			ProductionSequence();
		}
		else
		{
			Debug.Log("yeterli odun yok");
		}

	}

	private void ConcreteProduction(Item item, int requiredAmount = 1)
	{
		//timber production
		if (inventory.stoneCount >= requiredAmount)
		{
			if (!_hasEnoughFuel)
			{
				inventory.RemoveItem(inventory.stoneItem, requiredAmount);
				_hasEnoughFuel = true;
			}
		}
		if (_hasEnoughFuel)
		{
			ProductionSequence();
		}
		else
		{
			Debug.Log("yeterli tas yok");
		}

	}

	private void ProductionSequence()
	{
		_isProducing = true;
		productionTimer -= Time.deltaTime;
		if (productionTimer <= 0)
		{
			productionTimer = _productionTimerHolder;
			ProduceItem(productionItem);
			_hasEnoughFuel = false;
			StartProduction();
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
