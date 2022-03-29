using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnItem : MonoBehaviour
{
	public GameObject item;
	
    public void Despawn(){
		item.SetActive(false);
	}
}
