using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    public GameObject survivedText;
	public GameObject shelterText;
	public GameObject fishText;
	public GameObject waterText;
	public GameObject fireText;
	public GameObject foodText;
	public bool shelter;
	public bool fish;
	public bool water;
	public bool fire;
	public bool food;
	private GameObject TaskManager;
	
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager");
		water = TaskManager.GetComponent<TaskManager>().water;
		fish = TaskManager.GetComponent<TaskManager>().fish;
		
		if (fish){
			fishText.GetComponent<TextMeshPro>().text += "Yes";
		}
		else {
			fishText.GetComponent<TextMeshPro>().text += "No";
		}
		if (water){
			waterText.GetComponent<TextMeshPro>().text += "Yes";
		}
		else {
			waterText.GetComponent<TextMeshPro>().text += "No";
		}
		
    }

}
