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
	public bool shelter;
	public bool fish;
	public bool water;
	public bool fire;
	public bool food;
	private GameObject TaskManager;
	public float timeRemaining = 10;
	public GameObject loadScene;
	
	void Update () {
		if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
		else {
			loadScene.SetActive(true);
		}
	}
	
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager");
		int score = CalculateSurvivalScore(TaskManager.GetComponent<TaskManager>().day,TaskManager.GetComponent<TaskManager>().shelter,TaskManager.GetComponent<TaskManager>().fish,
		TaskManager.GetComponent<TaskManager>().water,TaskManager.GetComponent<TaskManager>().fire, TaskManager.GetComponent<TaskManager>().food);
		water = TaskManager.GetComponent<TaskManager>().water;
		fish = TaskManager.GetComponent<TaskManager>().fish;
		if (score >= 200) {
			survivedText.GetComponent<TextMeshPro>().text = "YOU SURVIVED!";
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
		
    }
	
	private int CalculateSurvivalScore(int day, bool shelter, bool fish, bool water, bool fire, bool food){
		if (day == 1 && !shelter){
			return 0;
		}
		else if (day == 1){
			return (int) Convert.ToInt32(shelter) * 100 + (int) Convert.ToInt32(water) * 100 + (int) Convert.ToInt32(fish) * 100 + (int) Convert.ToInt32(fire) * 100 + (int) Convert.ToInt32(food) * 100;
		}
		return 0;
	}

}
