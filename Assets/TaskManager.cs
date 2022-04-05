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
	
    void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}
}
