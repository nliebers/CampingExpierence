using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GripPointTracker : MonoBehaviour
{
	public GameObject rightHand;
	public GameObject leftHand;
	private GameObject closestHand;
	private GameObject previousHand;
	
	void Start(){
		closestHand = rightHand;
	}
	
    void Update()
    {
		previousHand = closestHand;
        if(Vector3.Distance(transform.position, leftHand.transform.position) <= Vector3.Distance(transform.position, rightHand.transform.position)) {
			closestHand = leftHand;
		}
		else{
			closestHand = rightHand;
		}
		if (previousHand != closestHand) {
			transform.Rotate(0, 0, 180, Space.World);
		}
    }
}
