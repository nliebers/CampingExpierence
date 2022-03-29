using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
	public GameObject postCardJounalEntry;
	public GameObject suitcaseJournalEntry;
	private Dictionary<string, GameObject> clues;
	
	public void Start() {
		clues.Add("postcard", postCardJounalEntry);
		clues.Add("suitcase", suitcaseJournalEntry);
	}
	
	public void CompleteClue(string clue) {
		clues[clue].SetActive(true);
	}
}
