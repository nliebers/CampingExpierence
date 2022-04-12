using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingManager : MonoBehaviour
{

    public GameObject pan;
    public GameObject fire;
    public int radius;
    public Material cookedMaterial;
    public Material burntMaterial;
    private float timer;
    public TextMeshProUGUI cookedJounralEntry;
    public GameObject TaskManager;
    private bool cookedCorrectly;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fire.activeInHierarchy)
        {
            if ((Vector3.Distance(this.gameObject.transform.position, fire.transform.position) < radius) && this.gameObject.transform.IsChildOf(pan.transform))
            {
                timer += Time.deltaTime;
                if (timer > 5)
                {
                    this.gameObject.transform.GetChild(1).GetComponent<Renderer>().material = cookedMaterial;
                    cookedCorrectly = true;
                }
                if (timer > 20)
                {
                    this.gameObject.transform.GetChild(1).GetComponent<Renderer>().material = burntMaterial;
                    cookedCorrectly = false;
                }
            }
        }

    }

    public void checkCooked()
    {
        Debug.Log("checking cook");
        if (cookedCorrectly)
        {
            Debug.Log("right matieral");
            cookedJounralEntry.text = "<s>-  Cook food</s>";
            TaskManager.GetComponent<TaskManager>().fish = true;
        }
        else {
            cookedJounralEntry.text = "-  Cook food";
            TaskManager.GetComponent<TaskManager>().fish = false;
        }
    }
}
