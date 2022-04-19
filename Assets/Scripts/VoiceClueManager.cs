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

	AudioSource fishingAudioSource;
	AudioSource shelterAudioSource;
	AudioSource fireAudioSource;
	AudioSource spearAudioSource;
	AudioSource waterAudioSource;
	AudioSource cookingAudioSource;

	GameObject fishingChild;
	GameObject shelterChild;
	GameObject fireChild;
	GameObject spearChild;
	GameObject waterChild;
	GameObject cookingChild;
	private void Start()
	{
		fishingChild = gameObject.transform.Find("FishingClue").gameObject;
		shelterChild = gameObject.transform.Find("BuildShelterClue").gameObject;
		fireChild = gameObject.transform.Find("FireClue").gameObject;
		spearChild = gameObject.transform.Find("SpearClue").gameObject;
		waterChild = gameObject.transform.Find("DrinkingWaterClue").gameObject;
		cookingChild = gameObject.transform.Find("CookingClue").gameObject;

		fishingAudioSource = fishingChild.GetComponent<AudioSource>();
		shelterAudioSource = shelterChild.GetComponent<AudioSource>();
		fireAudioSource = fireChild.GetComponent<AudioSource>();
		spearAudioSource = spearChild.GetComponent<AudioSource>();
		waterAudioSource = waterChild.GetComponent<AudioSource>();
		cookingAudioSource = cookingChild.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Vector3.Distance(player.transform.position, fishingClueProximity.transform.position) < 35.0f && !fishingPlayed && !fishingJournal.activeInHierarchy)
		{
			Debug.Log("should go fishign");
			fishingAudioSource.Play(0);
			fishingPlayed = true;
		}
		if (Vector3.Distance(player.transform.position, buildShelterClueProximity.transform.position) < 10.0f && !shelterPlayed && !shelterJournal.activeInHierarchy)
		{
			Debug.Log("I wonder if I could build a shelter here.");
			shelterAudioSource.Play(0);
			shelterPlayed = true;
		}
		if (Vector3.Distance(player.transform.position, fireClueProximity.transform.position) < 5.0f && !firePlayed && !fireJournal.activeInHierarchy)
		{
			Debug.Log("I should probably build a fire before it gets late.");
			fireAudioSource.Play(0);
			firePlayed = true;
		}
	}

		public void spearPicked(){
		if (!spearPickedUp){
			Debug.Log("I could make a spear");
			spearAudioSource.Play(0);
			spearPickedUp = true;
		}
	}
	
	public void bucketPicked() {
		if (!bucketPickedUp) {
			Debug.Log("I should probably get some water from the river.");
			waterAudioSource.Play(0);
			bucketPickedUp = true;
		}
	}
}
