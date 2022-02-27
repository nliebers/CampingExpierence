using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
		Debug.Log(other.transform.gameObject.name);
		if(other.transform.gameObject.tag == "Fish"){
			Debug.Log("Hit fish.");
			other.transform.gameObject.SetActive(false);
		}
	}
}
