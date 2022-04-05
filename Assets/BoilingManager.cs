using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoilingManager : MonoBehaviour
{
	public GameObject Campfire;
	public GameObject fire;
	public int boilingDistanceThreshold;
	public GameObject boilingEffect;
	private int timer = 3000;
	private bool boiling = false;
	public TextMeshProUGUI waterJounralEntry;
	public GameObject TaskManager;
	
	void FixedUpdate() {
		if (boiling) {
			timer -= 1;
			Debug.Log(timer);
		}
	}
	
    void Update()
    {
        if (Vector3.Distance(Campfire.transform.position, transform.position) <= boilingDistanceThreshold && fire.activeInHierarchy) {
			boilingEffect.SetActive(true);
			boiling = true;
		}
		if (timer <= 0) {
			boiling = false;
			waterJounralEntry.text = "<s>-  Catch Fish</s>";
			TaskManager.GetComponent<TaskManager>().water = true;
		}
    }
}
