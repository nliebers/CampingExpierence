using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{

	public float timeRemaining = 10;
	public GameObject loadScene;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
		else {
			loadScene.SetActive(true);
		}
    }
}
