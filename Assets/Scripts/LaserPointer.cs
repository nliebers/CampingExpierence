using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public LayerMask whatIsClickable;
    public SteamVR_Action_Boolean grabPinch;
    public SteamVR_Input_Sources thisHand;
    public GameObject playSign;

    private float maxDistance = 100f;
    private LineRenderer lr;
    private Vector3 clickPoint;
    private string signName;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
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
    }

	void  DetectHit()
	{
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, whatIsClickable))
        {
            clickPoint = hit.point;
            signName = hit.transform.gameObject.name;

            if (signName == "play")
			{
                PlayGame();
			}
            else if (signName == "exit")
			{
                ExitGame();
			}

        }
    }

    void PlayGame()
	{
        // SceneManager.LoadScene("main");
        playSign.transform.Find("LoadLevel").transform.gameObject.SetActive(true);
    }

    void ExitGame()
	{
        Application.Quit();
	}

}
