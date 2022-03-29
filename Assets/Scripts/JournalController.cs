using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class JournalController : MonoBehaviour
{
    public GameObject journal;
	public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources leftHand;

    void Update()
    {
        if (!grabPinch.GetState(leftHand))
		{
            journal.SetActive(false);
		}
    }
	
	void OnTriggerExit(Collider other){
		if (grabPinch.GetState(leftHand) && other.transform.gameObject.name == "LeftHand"){
			journal.SetActive(true);
		}
	}
}
