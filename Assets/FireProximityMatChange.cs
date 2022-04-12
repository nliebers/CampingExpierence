using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProximityMatChange : MonoBehaviour
{
	public float proximity;
	public Material builtMatieral;
	public GameObject fire;
	public GameObject stick1;
	public GameObject stick2;
	public GameObject stick3;
	public GameObject stick4;
	public string objectTagName;
	private GameObject objectUsed;
	private GameObject[] allPossibleObjects;
	private bool built = false;

	void Start()
	{
		allPossibleObjects = GameObject.FindGameObjectsWithTag(objectTagName);
	}

	public void UpdatePossibleObjects()
	{
		allPossibleObjects = GameObject.FindGameObjectsWithTag(objectTagName);
	}


	void Update()
	{
		foreach (GameObject obj in allPossibleObjects)
		{
			if (obj != null)
			{
				if (Vector3.Distance(obj.transform.position, transform.position) <= proximity && !fire.GetComponent<FireBuilder>().sticksUsed.Contains(obj) && !built)
				{
					stick1.GetComponent<Renderer>().material = builtMatieral;
					stick2.GetComponent<Renderer>().material = builtMatieral;
					stick3.GetComponent<Renderer>().material = builtMatieral;
					stick4.GetComponent<Renderer>().material = builtMatieral;
					fire.GetComponent<FireBuilder>().addStick(obj);
					obj.GetComponent<DestroyObjectManager>().needsToDestroy = true;
					built = true;
					//obj.SetActive(false);
				}
			}
		}
	}
}
