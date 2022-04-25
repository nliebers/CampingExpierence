using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueDisplayManager : MonoBehaviour
{
    public GameObject journalClue;
	private GameObject TaskManager;
	
    void Start()
    {
		TaskManager = GameObject.Find("TaskManager");
		if (journalClue.name == "PostCardClue"){
			journalClue.SetActive(TaskManager.GetComponent<TaskManager>().postcard);
		}
        if (journalClue.name == "SuitcaseClue"){
			journalClue.SetActive(TaskManager.GetComponent<TaskManager>().suitcase);
		}
		if (journalClue.name == "FlightMagazineClue"){
			journalClue.SetActive(TaskManager.GetComponent<TaskManager>().flyer);
		}
		if (journalClue.name == "AirplaneClue"){
			journalClue.SetActive(TaskManager.GetComponent<TaskManager>().plane);
		}
		
    }

}
