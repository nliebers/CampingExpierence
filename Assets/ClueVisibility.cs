using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueVisibility : MonoBehaviour
{
    private GameObject TaskManager;
	public GameObject clue;
	
    void Start()
    {
		TaskManager = GameObject.Find("TaskManager");
        if(clue.name == "PostCard") {
			clue.SetActive(!TaskManager.GetComponent<TaskManager>().postcard);
		}
		if(clue.name == "Vintage_Suitcase_LP") {
			clue.SetActive(!TaskManager.GetComponent<TaskManager>().suitcase);
		}
		if(clue.name == "flightmagazine") {
			clue.SetActive(!TaskManager.GetComponent<TaskManager>().flyer);
		}
		if(clue.name == "airplane") {
			clue.SetActive(!TaskManager.GetComponent<TaskManager>().plane);
		}
    }

}
