using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShelterBuilder : MonoBehaviour
{
    public int componentsPlaced = 0;
	public TextMeshProUGUI journalEntry;
	public GameObject TaskManager;

    public void componentPlaced() {
		componentsPlaced += 1;
		if (componentsPlaced >= 9) {
			journalEntry.text = "<s>-  Catch Fish</s>";
			TaskManager.GetComponent<TaskManager>().shelter = true;
		}
	}
}
