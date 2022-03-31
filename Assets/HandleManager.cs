using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleManager : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    private GameObject closestHand;
    private GameObject previousClosest;

    private void Start()
    {
        closestHand = leftHand;
        previousClosest = leftHand;
    }
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, leftHand.transform.position) + "LEFTHAND");
        Debug.Log(Vector3.Distance(transform.position, rightHand.transform.position) + "RIGHTHAND");
        if (Vector3.Distance(transform.position, leftHand.transform.position) < Vector3.Distance(transform.position, rightHand.transform.position))
        {
            Debug.Log("FLAG");
            closestHand = leftHand;
            if (previousClosest != closestHand)
            {
                Debug.Log("Switching hands rotation for the LEFT hand now.");
                
                previousClosest = leftHand;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        else {
            closestHand = rightHand;
            if (previousClosest != closestHand)
            {
                Debug.Log("Switching hands rotation for the RIGHT hand now.");
                previousClosest = leftHand;
                transform.rotation = new Quaternion(0, 0, 180, 0);
            }
        }
        //if (closestHand != previousClosest) {
        //    transform.rotation = new Quaternion(0, 0, 180, 0);
        //}
    }
}
