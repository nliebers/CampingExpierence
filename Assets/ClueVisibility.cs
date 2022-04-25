using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueVisibility : MonoBehaviour
{
    private GameObject TaskManager;
	
    void Start()
    {
        if(this.gameObject.name == "PostCard") {
			this.gameObject.SetActive(!TaskManager.GetComponent<TaskManager>().postcard);
		}
		if(this.gameObject.name == "Vintage_Suitcase_LP") {
			this.gameObject.SetActive(!TaskManager.GetComponent<TaskManager>().suitcase);
		}
		if(this.gameObject.name == "flightmagazine") {
			this.gameObject.SetActive(!TaskManager.GetComponent<TaskManager>().flyer);
		}
		if(this.gameObject.name == "airplane") {
			this.gameObject.SetActive(!TaskManager.GetComponent<TaskManager>().plane);
		}
    }

}
