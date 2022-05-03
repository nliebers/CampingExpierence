using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using TMPro;

public class EndOfDayLaserPointer : MonoBehaviour
{
    public LayerMask whatIsClickable;
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources thisHand;
    public GameObject continueSign;
	public GameObject returnMenuSign;
    public GameObject player;
	public GameObject shelterText;
	public GameObject fishText;
	public GameObject survivedText;
	public GameObject waterText;
	public GameObject fireText;
	public GameObject foodText;
	public GameObject descriptiveText;
	public GameObject togglePageButton;
    public TextMeshProUGUI toggleText;
    public Material rightArrow;
	public Material leftArrow;
	
	private GameObject TaskManager;
	private int currentPage;
    private float maxDistance = 100f;
    private LineRenderer lr;
    private Vector3 clickPoint;
    private string signName;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
		currentPage = 1;
		TaskManager = GameObject.Find("TaskManager");
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetColors(Color.black, Color.black);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + transform.forward * 20f);
        if (grabPinch.GetStateDown(thisHand))
		{
            DetectHit();
		}
        if(SceneManager.GetActiveScene().name == "main")
        {
            lr.enabled = false;
        }
    }

	void  DetectHit()
	{
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, whatIsClickable))
        {
            clickPoint = hit.point;
            signName = hit.transform.gameObject.name;
            if (signName == "continue")
			{
                Continue();
			}
            else if (signName == "return")
			{
                ReturnMenu();
			}
			else if (signName == "togglePage") {
				Toggle();
			}

        }
    }

    void Continue()
	{
        // SceneManager.LoadScene("main");
		if (TaskManager.GetComponent<TaskManager>().day >= 4){
			continueSign.transform.Find("LoadLevelFinal").transform.gameObject.SetActive(true);
		}
		else {
			continueSign.transform.Find("LoadLevel").transform.gameObject.SetActive(true);
		}
        //StartCoroutine(LevelManager.Instance.ResetPlayer());
        //ResetPlayer();
    }

    IEnumerator ResetPlayer()
    {
        //player.SetActive(false);
        while(true)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "main")
            {
                player.SetActive(false);
                player = GameObject.Find("MainPlayer");
                player.SetActive(true);
                player.transform.position = new Vector3(0, 100, 0);
                yield return new WaitForSeconds(.5f);
            }
        }
    }

    void ReturnMenu()
	{
        TaskManager.GetComponent<TaskManager>().ResetGame();
        returnMenuSign.transform.Find("LoadLevel").transform.gameObject.SetActive(true);
	}
	
	void Toggle() {
		if (currentPage == 1){
			survivedText.SetActive(false);
			shelterText.SetActive(false);
			foodText.SetActive(false);
			waterText.SetActive(false);
			fireText.SetActive(false);
			fishText.SetActive(false);
			descriptiveText.SetActive(true);
            toggleText.text = "Back";
			currentPage = 2;
		}
		else {
			survivedText.SetActive(true);
			shelterText.SetActive(true);
			foodText.SetActive(true);
			waterText.SetActive(true);
			fireText.SetActive(true);
			fishText.SetActive(true);
			descriptiveText.SetActive(false);
            toggleText.text = "Next";
            currentPage = 1;
		}
	}

}
