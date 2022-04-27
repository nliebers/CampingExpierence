using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsUsed : MonoBehaviour
{
    private List<GameObject> shelterItemsUsed = new List<GameObject>();

    public void AddItem(GameObject obj){
		shelterItemsUsed.Add(obj);
	}
	
	public bool checkItem(GameObject obj){
		return shelterItemsUsed.Contains(obj);
	}
}
