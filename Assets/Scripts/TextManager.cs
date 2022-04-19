using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private GameObject TaskManager;
	public GameObject urgentText;
	public GameObject normalText;
	public int dayWanted;
	
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager");
		if (TaskManager.GetComponent<TaskManager>().day == dayWanted) {
			normalText.SetActive(false);
			urgentText.SetActive(true);
		}
		else {
			normalText.SetActive(true);
			urgentText.SetActive(false);
		}
    }

}
