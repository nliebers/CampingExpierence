using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeft : MonoBehaviour
{
	public GameObject sail;
	
    void OnTriggerEnter(Collider other)
    {
		if (other.transform.gameObject.tag == "Player") {
			sail.transform.Rotate(0, -15, 0, Space.World);
		}
    }
}
