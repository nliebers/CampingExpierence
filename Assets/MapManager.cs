using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MapManager : MonoBehaviour
{
    public GameObject map;
	public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources rightHand;

    void Update()
    {
        if (!grabPinch.GetState(rightHand))
		{
            map.SetActive(false);
		}
    }
	
	void OnTriggerExit(Collider other){
		if (grabPinch.GetState(rightHand) && other.transform.gameObject.name == "RightHand"){
			map.SetActive(true);
		}
	}
}
