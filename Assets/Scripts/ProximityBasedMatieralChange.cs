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
	public bool useSpecialPoint;
	public GameObject specialPoint;
	public bool updateShelterProgress;
	public GameObject shelter;
	public bool useAudio;
	public AudioSource audio;
	private GameObject objectUsed;
	private GameObject TaskManager;
	private GameObject[] allPossibleObjects;
	private bool placed;

	
	void Start() {
		allPossibleObjects = GameObject.FindGameObjectsWithTag(objectTagName);
		TaskManager = GameObject.Find("TaskManager");
		if (updateShelterProgress && TaskManager.GetComponent<TaskManager>().shelter) {
			objectToChange.GetComponent<Renderer>().material = builtMatieral;
			placed = true;
		}
	}

	public void UpdatePossibleObjects() {
		allPossibleObjects = GameObject.FindGameObjectsWithTag(objectTagName);
	}


    void Update()
    {
        foreach(GameObject obj in allPossibleObjects) {
			if (obj != null) {
				if ((Vector3.Distance(obj.transform.position, transform.position) <= proximity && !useSpecialPoint || (useSpecialPoint && 
				Vector3.Distance(obj.transform.position, specialPoint.transform.position) <= proximity)) && !placed){
					objectToChange.GetComponent<Renderer>().material = builtMatieral;
					if (useAudio) {
						audio.Play(); 
					}
					obj.GetComponent<DestroyObjectManager>().needsToDestroy = true;
					if (updateShelterProgress) {
						shelter.GetComponent<ShelterBuilder>().componentPlaced();
						placed = true;
					}
				}
			}
		}
    }
}
