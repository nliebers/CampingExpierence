using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
	public GameObject postCardJounalEntry;
	public GameObject suitcaseJournalEntry;
	public GameObject flightmagazineJournalEntry;
	public GameObject airplaneWingJournalEntry;
	private GameObject TaskManager;
	private Dictionary<string, GameObject> clues = new Dictionary <string, GameObject>();
	
	public void Start() {
		TaskManager = GameObject.Find("TaskManager");
		clues.Add("postcard", postCardJounalEntry);
		clues.Add("suitcase", suitcaseJournalEntry);
		clues.Add("flightmagazine", flightmagazineJournalEntry);
		clues.Add("airplane", airplaneWingJournalEntry);
	}
	
	public void CompleteClue(string clue) {
		clues[clue].SetActive(true);
		if (clue == "postcard"){
			TaskManager.GetComponent<TaskManager>().postcard = true;
		}
		if (clue == "suitcase"){
			TaskManager.GetComponent<TaskManager>().suitcase = true;
		}
		if (clue == "flightmagazine"){
			TaskManager.GetComponent<TaskManager>().flyer = true;
		}
		if (clue == "airplane"){
			TaskManager.GetComponent<TaskManager>().plane = true;
		}
		gameObject.GetComponent<AudioSource>().Play();
	}
}
