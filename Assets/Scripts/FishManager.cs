using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
		Debug.Log(other.transform.gameObject.name);
		if(other.transform.gameObject.tag == "Fish"){
			Debug.Log("Hit fish.");
			other.transform.gameObject.GetComponent<WanderingAI>().dead = true;
			other.transform.gameObject.GetComponent<WanderingAI>().setDeathDestination();
			other.transform.gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();
			StartCoroutine(fishDelay(other));
		}
	}
	
	private IEnumerator fishDelay(Collider other){
		yield return new WaitForSeconds(3);
		other.transform.gameObject.SetActive(false);
	}
}
