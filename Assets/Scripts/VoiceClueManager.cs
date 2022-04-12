using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceClueManager : MonoBehaviour
{
	public GameObject fishingClueAudio;
	public GameObject spearClueAudio;
	public GameObject drinkingWaterClueAudio;
	public GameObject fireClueAudio;
	public GameObject cookingClueAudio;
	public GameObject buildShelterClueAudio;
	public GameObject fishingClueProximity;
	public bool spearPickedUp;
	public bool bucketPickedUp;
	public GameObject fireClueProximity;
	public GameObject cookingClueProximity;
	public GameObject buildShelterClueProximity;
	public GameObject fishingJournal;
	public GameObject waterJournal;
	public GameObject fireJournal;
	public GameObject shelterJournal;
	public GameObject cookingJournal;
	public GameObject player;
	
	private bool fishingPlayed;
	private bool firePlayed;
	private bool cookingPlayed;
	private bool shelterPlayed;
	
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, fishingClueProximity.transform.position) < 35.0f && !fishingPlayed && !fishingJournal.activeInHierarchy) {
			Debug.Log("should go fishign");
			fishingPlayed = true;
		}
		if (Vector3.Distance(player.transform.position, buildShelterClueProximity.transform.position) < 10.0f && !shelterPlayed && !shelterJournal.activeInHierarchy) {
			Debug.Log("I wonder if I could build a shelter here.");
			shelterPlayed = true;
		}
		if (Vector3.Distance(player.transform.position, fireClueProximity.transform.position) < 5.0f && !firePlayed && !fireJournal.activeInHierarchy) {
			Debug.Log("I should probably build a fire before it gets late.");
			firePlayed = true;
		}
    }
	
	public void spearPicked(){
		if (!spearPickedUp){
			Debug.Log("I could make a spear");
			spearPickedUp = true;
		}
	}
	
	public void bucketPicked() {
		if (!bucketPickedUp) {
			Debug.Log("I should probably get some water from the river.");
			bucketPickedUp = true;
		}
	}
}
