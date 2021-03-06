using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScreenManager : MonoBehaviour
{
    private GameObject TaskManager;
	public TextMeshProUGUI descriptionText;
	public TextMeshProUGUI pageTwoText;
	
    void Start()
    {
        TaskManager = GameObject.Find("TaskManager");
		descriptionText.text = "Great Job! You survived 3 days in the wilderness and a rescue team was able to find you.";
		if (TaskManager.GetComponent<TaskManager>().plane && TaskManager.GetComponent<TaskManager>().flyer && TaskManager.GetComponent<TaskManager>().postcard && TaskManager.GetComponent<TaskManager>().suitcase) {
			descriptionText.text += "Thankfully, you were able to find enough clues to remember you were on a flight before crashed and got lost in the forest.  Maybe you will be able to find more surivors with the help of the rescue team.";
		}
		else {
			descriptionText.text += "You still have no memory of why you were in the forest to begin with.  Regardless, it will be good to get back home.";
		}
		
		pageTwoText.text = "You did a great job surviving, here are some of your final stats.  You caught a total of " + TaskManager.GetComponent<TaskManager>().totalfishCaught.ToString() + " fish. ";
		pageTwoText.text += "You also finished with a final score of " + TaskManager.GetComponent<TaskManager>().totalScore.ToString() + " out of a possible 1800.";
    }

}
