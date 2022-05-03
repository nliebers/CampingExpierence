using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public bool shelter;
	public bool fish;
	public bool water;
	public bool fire;
	public bool food;
	public bool postcard;
	public bool plane;
	public bool flyer;
	public bool suitcase;
	public int fishCaught;
	public int totalfishCaught;
	public int totalScore;
	private static TaskManager taskManagerInstance;
	public int day = 1;
	
    void Awake() {
		DontDestroyOnLoad(this.gameObject);
		if (taskManagerInstance == null) {
			taskManagerInstance = this;
		}
		else {
			Destroy(gameObject);
		}
	}
	
	public void ResetDay() {
		day += 1;
		fishCaught = 0;
		fish = false;
		water = false;
		fire = false;
		food = false;
	}

	public void ResetGame()
	{
		day = 1;
		fishCaught = 0;
		fish = false;
		shelter = false;
		water = false;
		food = false;
		fire = false;
		postcard = false;
		plane = false;
		flyer = false;
		suitcase = false;
		totalScore = 0;
	}
}
