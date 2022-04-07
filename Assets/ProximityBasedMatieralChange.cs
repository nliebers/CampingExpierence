using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProximityBasedMatieralChange : MonoBehaviour
{
    public float proximity;
	public Material builtMatieral;
	public GameObject objectToChange;
	public string objectTagName;
	private GameObject objectUsed;
	private GameObject[] allPossibleObjects;
	
	void Start() {
		allPossibleObjects = GameObject.FindGameObjectsWithTag(objectTagName);
	}

	public void UpdatePossibleObjects() {
		allPossibleObjects = GameObject.FindGameObjectsWithTag(objectTagName);
	}


    void Update()
    {
        foreach(GameObject obj in allPossibleObjects) {
			Debug.Log(allPossibleObjects);
			Debug.Log(obj.name);
			if (obj != null) {
				if (Vector3.Distance(obj.transform.position, transform.position) <= proximity){
					objectToChange.GetComponent<Renderer>().material = builtMatieral;
					obj.GetComponent<DestroyObjectManager>().needsToDestroy = true;
					//obj.SetActive(false);
				}
			}
		}
    }
}
