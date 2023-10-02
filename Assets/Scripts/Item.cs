using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
[Serializable]
public class Item : ScriptableObject
{
	public string Name; // we can add variables that all items definetly has
}
