using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{

	public float timeRemaining = 10;
	public GameObject loadScene;
	public TextMeshProUGUI timerText;
	private int minutesRemain;
	private int secondsRemain;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
			secondsRemain = (int) timeRemaining % 60;
			minutesRemain = (int) timeRemaining / 60;
			if(secondsRemain >= 10) {
				timerText.text = "Daylight Left " + minutesRemain.ToString() + ":" + secondsRemain.ToString();
			}
			else {
				timerText.text = "Daylight Left " + minutesRemain.ToString() + ":0" + secondsRemain.ToString();
			}
        }
		else {
			loadScene.SetActive(true);
		}
    }
}
