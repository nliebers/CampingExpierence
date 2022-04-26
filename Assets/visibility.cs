using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class visibility : MonoBehaviour
{
    private GameObject TaskManager;
    public TextMeshProUGUI shelterText;

    void Awake()
    {
        TaskManager = GameObject.Find("TaskManager");
        if (TaskManager.GetComponent<TaskManager>().shelter)
        {
            shelterText.text = "<s> Build Shelter </s>";
        }
        else {
            shelterText.text = "Build Shelter";
        }
    }
}
