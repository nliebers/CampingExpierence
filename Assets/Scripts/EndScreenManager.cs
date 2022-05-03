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
	public GameObject continueText;
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
		food = TaskManager.GetComponent<TaskManager>().food;
		fire = TaskManager.GetComponent<TaskManager>().fire;
		TaskManager.GetComponent<TaskManager>().totalScore += score;
		if (score >= 200) {
			survivedText.GetComponent<TextMeshPro>().text = "YOU SURVIVED!";
			TaskManager.GetComponent<TaskManager>().ResetDay();
			continueButton.SetActive(true);
			continueText.SetActive(true);
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
		if (food){
			foodText.GetComponent<TextMeshPro>().text += "Yes";
		}
		else {
			foodText.GetComponent<TextMeshPro>().text += "No";
		}
		if (fire){
			fireText.GetComponent<TextMeshPro>().text += "Yes";
		}
		else {
			fireText.GetComponent<TextMeshPro>().text += "No";
		}
		
    }
	
	private int CalculateSurvivalScore(int day, bool shelter, bool fish, bool water, bool fire, bool food){
		if (day == 1 && !shelter)
		{
			descriptiveText.GetComponent<TextMeshPro>().text += "Unfortunately you were unable to build sufficient shelter to make it through the first night.  Return to the main menu and see if you can survive for 3 days.";
			return 0;
		}
		else if (day == 1)
		{
			descriptiveText.GetComponent<TextMeshPro>().text += "Great, you were able to build a shelter and survived the first night!";
			if (water) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You were also able to get some drinking water, you will probably have to get more tomorrow.";
			}
			if (fire) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You also found enough wood to build a fire, unfortunately it burned out late in the night.";
			}
			if (fish) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You used your great skill to catch " +  TaskManager.GetComponent<TaskManager>().fishCaught.ToString() + "fish.";
			}
			if (food) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You cooked some of that fish for food.";
			}
			return (int)Convert.ToInt32(shelter) * 200 + (int)Convert.ToInt32(water) * 100 + (int)Convert.ToInt32(fish) * 100 + (int)Convert.ToInt32(fire) * 100 + (int)Convert.ToInt32(food) * 100;
		}
		else {
			if (water) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You were also able to get some drinking water, you will probably have to get more tomorrow.";
			}
			if (fire) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You also found enough wood to build a fire, unfortunately it burned out late in the night.";
			}
			if (fish) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You used your great skill to catch " +  TaskManager.GetComponent<TaskManager>().fishCaught.ToString() + " fish.";
			}
			if (food) {
				descriptiveText.GetComponent<TextMeshPro>().text += "You cooked some of that fish for food.";
			}
			return (int)Convert.ToInt32(water) * 150 + (int)Convert.ToInt32(fish) * 150 + (int)Convert.ToInt32(fire) * 150 + (int)Convert.ToInt32(food) * 150;
		}
		return 0;
	}

}
