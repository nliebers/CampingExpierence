using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStakes : MonoBehaviour
{
	public GameObject craftTable;
	public GameObject stake;
	public GameObject spawnLocation;
	public GameObject[] stakes;
	
    void OnTriggerEnter(Collider other){
		if (other.transform.gameObject.name == "LeftHand" || other.transform.gameObject.name == "RightHand"){
			foreach(GameObject i in craftTable.GetComponent<CraftManager>().currentItems) {
				if (i.tag == "stick"){
					craftTable.GetComponent<CraftManager>().currentItems.Remove(i);
					Instantiate(stake, spawnLocation.transform.position, Quaternion.identity);
					Instantiate(stake, spawnLocation.transform.position, Quaternion.identity);
					Instantiate(stake, spawnLocation.transform.position, Quaternion.identity);
					Instantiate(stake, spawnLocation.transform.position, Quaternion.identity);
					Instantiate(stake, spawnLocation.transform.position, Quaternion.identity);
					Instantiate(stake, spawnLocation.transform.position, Quaternion.identity);
					craftTable.GetComponent<CraftManager>().containsStick = false;
					Destroy(i);
					craftTable.GetComponent<CraftManager>().UpdateBuildables();
					foreach (GameObject stake in stakes) {
						stake.GetComponent<ProximityBasedMatieralChange>().UpdatePossibleObjects();
					}
					return;
				}
			}
		}
	}
}
