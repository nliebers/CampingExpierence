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
        if (!grabPinch.GetStateDown(leftHand))
		{
            journal.SetActive(false);
		}
    }
	
	void OnTriggerExit(Collider other){
		Debug.Log(grabPinch.GetStateDown(leftHand));
		Debug.Log(other.transform.gameObject.name);
		if (grabPinch.GetStateDown(leftHand) && other.transform.gameObject.tag == "Player"){
			journal.SetActive(true);
		}
	}
}
