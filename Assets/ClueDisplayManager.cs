using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueDisplayManager : MonoBehaviour
{
	public GameObject postcardClue;
	public GameObject suitcaseClue;
	public GameObject flyerClue;
	public GameObject planeClue;

	private GameObject TaskManager;
	
    void Start()
    {
		TaskManager = GameObject.Find("TaskManager");
		postcardClue.SetActive(TaskManager.GetComponent<TaskManager>().postcard);
		suitcaseClue.SetActive(TaskManager.GetComponent<TaskManager>().suitcase);
		flyerClue.SetActive(TaskManager.GetComponent<TaskManager>().flyer);
		planeClue.SetActive(TaskManager.GetComponent<TaskManager>().plane);		
    }

}
