using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSpear : MonoBehaviour
{
	public GameObject craftTable;
	public GameObject spear;
	public GameObject spawnLocation;
	
    void OnTriggerEnter(Collider other){
		if (other.transform.gameObject.name == "LeftHand" || other.transform.gameObject.name == "RightHand"){
			foreach(GameObject i in craftTable.GetComponent<CraftManager>().currentItems) {
				if (i.tag == "stick"){
					craftTable.GetComponent<CraftManager>().currentItems.Remove(i);
					Instantiate(spear, spawnLocation.transform.position, Quaternion.identity);
					craftTable.GetComponent<CraftManager>().containsStick = false;
					Destroy(i);
					craftTable.GetComponent<CraftManager>().UpdateBuildables();
					return;
				}
			}
		}
	}
}
