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
}