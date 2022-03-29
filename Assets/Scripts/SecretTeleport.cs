using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretTeleport : MonoBehaviour
{
    public GameObject player;
	public GameObject secretLocation;
    
	
    public void TeleportToLocation(){
		player.transform.position = secretLocation.transform.position;
	}
}
