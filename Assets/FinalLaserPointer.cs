using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using TMPro;

public class FinalLaserPointer : MonoBehaviour
{
    public LayerMask whatIsClickable;
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources thisHand;
    public GameObject continueSign;
	public GameObject returnMenuSign;
    public GameObject player;
	public GameObject titleText;
	public GameObject pageTwoText;
	public GameObject descriptiveText;
	public GameObject togglePageButton;
    public TextMeshProUGUI toggleText;
	
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
            if (signName == "return")
			{
                ReturnMenu();
			}
			else if (signName == "togglePage") {
				Toggle();
			}

        }
    }
	
	void ReturnMenu()
	{
        returnMenuSign.transform.Find("LoadLevel").transform.gameObject.SetActive(true);
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

	
	void Toggle() {
		if (currentPage == 1){
			pageTwoText.SetActive(true);
			descriptiveText.SetActive(false);
			titleText.SetActive(false);
            toggleText.text = "Back";
			currentPage = 2;
		}
		else {
			pageTwoText.SetActive(false);
			descriptiveText.SetActive(true);
			titleText.SetActive(true);
            toggleText.text = "Next";
            toggleText.text = "Next";
            currentPage = 1;
		}
	}

}
