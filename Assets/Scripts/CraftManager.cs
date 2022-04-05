using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public GameObject stick;
	public GameObject spear;
	public GameObject spawnLocation;
	private HashSet<GameObject> currentItems = new HashSet<GameObject>();
	private bool containsStick;
	
	void OnTriggerEnter(Collider other) {
		if (other.transform.gameObject != null) {
			if (other.transform.gameObject.tag == "stick" && !containsStick){
				AddItem(other.transform.gameObject);
			}
		}
	}
	
	void AddItem(GameObject item){
		currentItems.Add(item);
		if (item.tag == "stick") {
			containsStick = true;
		}
		UpdateBuildables();
	}
	
	void UpdateBuildables(){
		if(containsStick) {
			foreach(GameObject i in currentItems) {
				if (i.tag == "stick"){
					currentItems.Remove(i);
					Instantiate(spear, spawnLocation.transform.position, Quaternion.identity);
					containsStick = false;
					Destroy(i);
					return;
				}
			}
		}
	}

}
