using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
	public GameObject postCardJounalEntry;
	public GameObject suitcaseJournalEntry;
	public GameObject flightmagazineJournalEntry;
	public GameObject airplaneWingJournalEntry;
	private Dictionary<string, GameObject> clues = new Dictionary <string, GameObject>();
	
	public void Start() {
		clues.Add("postcard", postCardJounalEntry);
		clues.Add("suitcase", suitcaseJournalEntry);
		clues.Add("flightmagazine", flightmagazineJournalEntry);
		clues.Add("airplane", airplaneWingJournalEntry);
	}
	
	public void CompleteClue(string clue) {
		clues[clue].SetActive(true);
		gameObject.GetComponent<AudioSource>().Play();
	}
}
