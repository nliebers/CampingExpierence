using System.Collections;
using System;
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
	public GameObject descriptiveText;
	public GameObject continueButton;
	public bool shelter;
	public bool fish;
	public bool water;
	public bool fire;
	public bool food;
	private GameObject TaskManager;
	
	
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager");
		int score = CalculateSurvivalScore(TaskManager.GetComponent<TaskManager>().day,TaskManager.GetComponent<TaskManager>().shelter,TaskManager.GetComponent<TaskManager>().fish,
		TaskManager.GetComponent<TaskManager>().water,TaskManager.GetComponent<TaskManager>().fire, TaskManager.GetComponent<TaskManager>().food);
		descriptiveText.GetComponent<TextMeshPro>().text += "Your total survival score was " + score.ToString() + " out of a possible 600 points.";
		water = TaskManager.GetComponent<TaskManager>().water;
		fish = TaskManager.GetComponent<TaskManager>().fish;
		shelter = TaskManager.GetComponent<TaskManager>().shelter;
		if (score >= 200) {
			survivedText.GetComponent<TextMeshPro>().text = "YOU SURVIVED!";
			continueButton.SetActive(true);
		}
		else {
			survivedText.GetComponent<TextMeshPro>().text = "YOU DIED!";
		}
		
		
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
		if (shelter){
			shelterText.GetComponent<TextMeshPro>().text += "Yes";
		}
		else {
			shelterText.GetComponent<TextMeshPro>().text += "No";
		}
		
    }
	
	private int CalculateSurvivalScore(int day, bool shelter, bool fish, bool water, bool fire, bool food){
		if (day == 1 && !shelter){
			descriptiveText.GetComponent<TextMeshPro>().text += "Unfortunately you were unable to build sufficient shelter to make it through the first night.";
			return 0;
		}
		else if (day == 1){
			return (int) Convert.ToInt32(shelter) * 200 + (int) Convert.ToInt32(water) * 100 + (int) Convert.ToInt32(fish) * 100 + (int) Convert.ToInt32(fire) * 100 + (int) Convert.ToInt32(food) * 100;
		}
		return 0;
	}

}
