using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingClue : MonoBehaviour
{
	public GameObject wingPoint;
	public GameObject player;
	public GameObject secretItems;
	private bool wingFound = false;

    void Update()
    {
        if (Vector3.Distance(wingPoint.transform.position, player.transform.position) <= 35.0f && !wingFound) {
			secretItems.GetComponent<ClueManager>().CompleteClue("airplane");
			wingFound = true;
		}
    }
}
