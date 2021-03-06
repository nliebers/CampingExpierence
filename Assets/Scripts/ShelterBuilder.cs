using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShelterBuilder : MonoBehaviour
{
    public int componentsPlaced = 0;
	public TextMeshProUGUI journalEntry;
	public TextMeshProUGUI jounralEntrySpecial;
	private GameObject TaskManager;
	
	void Start() {
		TaskManager = GameObject.Find("TaskManager");
	}

    public void componentPlaced() {
		componentsPlaced += 1;
		Debug.Log(componentsPlaced);
		if (componentsPlaced >= 9) {
			journalEntry.text = "<s>-  Build Shelter</s>";
			jounralEntrySpecial.text = "<s>-  Build Shelter</s>";
			TaskManager.GetComponent<TaskManager>().shelter = true;
		}
	}
}
